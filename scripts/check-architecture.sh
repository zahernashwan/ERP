#!/usr/bin/env bash
set -euo pipefail

# ─────────────────────────────────────────────────────────────────────────────
# Architecture Rules Enforcement — CI Gate
# Validates that the codebase complies with docs/ARCHITECTURE_RULES.md.
# Any violation causes a non-zero exit → PR is blocked.
#
# Usage: ./scripts/check-architecture.sh
# ─────────────────────────────────────────────────────────────────────────────

REPO_ROOT="$(cd "$(dirname "$0")/.." && pwd)"
SRC="$REPO_ROOT/src"
DOCS="$REPO_ROOT/docs"
RULES="$DOCS/ARCHITECTURE_RULES.md"

violations=0

fail() {
  echo "❌ $1"
  violations=$((violations + 1))
}

pass() {
  echo "✅ $1"
}

info() {
  echo "── $1"
}

# ─────────────────────────────────────────────────────────────────────────────
# Helper: extract ProjectReference names from a .csproj
# ─────────────────────────────────────────────────────────────────────────────
get_project_refs() {
  local csproj="$1"
  grep -oP 'Include="[^"]*\.csproj"' "$csproj" 2>/dev/null \
    | sed 's/Include="//;s/\.csproj"//;s|.*[/\\]||' \
    || true
}

# ═════════════════════════════════════════════════════════════════════════════
echo ""
echo "🏗️  Architecture Rules Enforcement (CI Gate)"
echo "    Reference: docs/ARCHITECTURE_RULES.md"
echo ""
# ═════════════════════════════════════════════════════════════════════════════

# ── 0. Prerequisite: ARCHITECTURE_RULES.md must exist ───────────────────────
info "Checking ARCHITECTURE_RULES.md exists..."
if [ ! -f "$RULES" ]; then
  fail "R-DOC: docs/ARCHITECTURE_RULES.md is missing — the governing architecture rules file must exist."
else
  pass "docs/ARCHITECTURE_RULES.md exists."
fi

# ── 1. R-DEP-01: Domain has no project references ──────────────────────────
info "R-DEP-01: Domain must not depend on any other layer..."
domain_refs=$(get_project_refs "$SRC/ERP.Domain/ERP.Domain.csproj")
if [ -n "$domain_refs" ]; then
  fail "R-DEP-01: ERP.Domain references: $domain_refs (must have zero project references)"
else
  pass "R-DEP-01: ERP.Domain has no project references."
fi

# ── 2. R-DEP-02: Application depends on Domain only ────────────────────────
info "R-DEP-02: Application must depend on Domain only..."
app_refs=$(get_project_refs "$SRC/ERP.Application/ERP.Application.csproj")
for ref in $app_refs; do
  if [ "$ref" != "ERP.Domain" ]; then
    fail "R-DEP-02: ERP.Application references '$ref' — only ERP.Domain is allowed."
  fi
done
if ! echo "$app_refs" | grep -q "ERP.Domain"; then
  fail "R-DEP-02: ERP.Application does not reference ERP.Domain (expected)."
else
  pass "R-DEP-02: ERP.Application depends on ERP.Domain only."
fi

# ── 3. R-DEP-03: Infrastructure depends on Application + Domain only ───────
info "R-DEP-03: Infrastructure must depend on Application and Domain only..."
infra_refs=$(get_project_refs "$SRC/ERP.Infrastructure/ERP.Infrastructure.csproj")
allowed_infra="ERP.Application ERP.Domain"
for ref in $infra_refs; do
  if ! echo "$allowed_infra" | grep -qw "$ref"; then
    fail "R-DEP-03: ERP.Infrastructure references '$ref' — only ERP.Application and ERP.Domain are allowed."
  fi
done
pass_infra=true
for expected in ERP.Application ERP.Domain; do
  if ! echo "$infra_refs" | grep -q "$expected"; then
    # Domain can be transitive, so only warn if Application is missing
    if [ "$expected" = "ERP.Application" ]; then
      fail "R-DEP-03: ERP.Infrastructure does not reference ERP.Application (expected)."
      pass_infra=false
    fi
  fi
done
if $pass_infra; then
  pass "R-DEP-03: ERP.Infrastructure dependencies are valid."
fi

# ── 4. R-DEP-04: Presentation depends on Application only ──────────────────
info "R-DEP-04: Presentation must depend on Application only..."
pres_refs=$(get_project_refs "$SRC/ERP.Presentation.WinForms/ERP.Presentation.WinForms.csproj")
for ref in $pres_refs; do
  if [ "$ref" != "ERP.Application" ]; then
    fail "R-DEP-04: ERP.Presentation.WinForms references '$ref' — only ERP.Application is allowed."
  fi
done
if echo "$pres_refs" | grep -q "ERP.Application"; then
  pass "R-DEP-04: ERP.Presentation.WinForms depends on ERP.Application only."
else
  fail "R-DEP-04: ERP.Presentation.WinForms does not reference ERP.Application (expected)."
fi

# ── 5. R-DEP-05: Bootstrapper is the Composition Root ──────────────────────
info "R-DEP-05: Bootstrapper must be the Composition Root..."
if [ ! -f "$SRC/ERP.Bootstrapper/ERP.Bootstrapper.csproj" ]; then
  fail "R-DEP-05: ERP.Bootstrapper project not found."
else
  pass "R-DEP-05: ERP.Bootstrapper exists as Composition Root."
fi

# ── 6. R-DOM-09: Domain must not reference infrastructure packages ──────────
info "R-DOM-09: Domain must not contain infrastructure/framework references..."
domain_csproj="$SRC/ERP.Domain/ERP.Domain.csproj"
forbidden_domain_pkgs='PackageReference Include="(EntityFramework|Dapper|Microsoft\.Extensions\.DependencyInjection|System\.Data\.|Newtonsoft|Microsoft\.AspNetCore)'
if grep -qP "$forbidden_domain_pkgs" "$domain_csproj" 2>/dev/null; then
  fail "R-DOM-09: ERP.Domain contains forbidden infrastructure/framework package references."
else
  pass "R-DOM-09: ERP.Domain is free from infrastructure/framework packages."
fi

# ── 7. R-APP-09: Application must not reference Infrastructure ─────────────
info "R-APP-09: Application must not reference infrastructure packages..."
app_csproj="$SRC/ERP.Application/ERP.Application.csproj"
forbidden_app_pkgs='PackageReference Include="(EntityFramework|Dapper|System\.Data\.SqlClient|Microsoft\.Extensions\.DependencyInjection")'
if grep -qP "$forbidden_app_pkgs" "$app_csproj" 2>/dev/null; then
  fail "R-APP-09: ERP.Application contains forbidden infrastructure package references."
else
  pass "R-APP-09: ERP.Application is free from infrastructure packages."
fi

# ── 8. R-DOC-01: Every doc file starts with # Title ────────────────────────
info "R-DOC-01: Every docs/*.md file must start with '# Title'..."
doc_fail=0
for f in $(find "$DOCS" -name '*.md' ! -name 'README.template.md'); do
  if ! grep -qm1 '^# ' "$f"; then
    fail "R-DOC-01: Missing '# Title' in $f"
    doc_fail=1
  fi
done
if [ "$doc_fail" -eq 0 ]; then
  pass "R-DOC-01: All doc files have titles."
fi

# ── 9. R-DOC-02: README.md is auto-generated ───────────────────────────────
info "R-DOC-02: README.md must be auto-generated and up-to-date..."
readme_check_output=$(bash "$REPO_ROOT/scripts/generate-readme.sh" --check 2>&1) || true
if echo "$readme_check_output" | grep -q "up-to-date"; then
  pass "R-DOC-02: README.md is up-to-date."
else
  fail "R-DOC-02: README.md is out of date. Run: scripts/generate-readme.sh"
  echo "    $readme_check_output"
fi

# ── 10. R-BST-02: No Service Locator patterns in src/ ──────────────────────
info "R-BST-02: No Service Locator patterns in source code..."
sl_pattern='IServiceProvider\.GetService|IServiceProvider\.GetRequiredService|ServiceLocator'
sl_violations=""
while IFS= read -r cs_file; do
  # Skip obj/bin directories
  if [[ "$cs_file" == *"/obj/"* ]] || [[ "$cs_file" == *"/bin/"* ]]; then
    continue
  fi
  # Skip Designer files
  if [[ "$cs_file" == *".Designer.cs" ]]; then
    continue
  fi
  # Skip Bootstrapper (composition root is allowed to resolve)
  if [[ "$cs_file" == *"ERP.Bootstrapper"* ]]; then
    continue
  fi
  if grep -qE "$sl_pattern" "$cs_file" 2>/dev/null; then
    sl_violations="$sl_violations $cs_file"
  fi
done < <(find "$SRC" -name '*.cs' -type f 2>/dev/null)

if [ -n "$sl_violations" ]; then
  fail "R-BST-02: Service Locator pattern found in:$sl_violations"
else
  pass "R-BST-02: No Service Locator patterns found outside Bootstrapper."
fi

# ═════════════════════════════════════════════════════════════════════════════
echo ""
echo "════════════════════════════════════════════════════"
if [ "$violations" -gt 0 ]; then
  echo "🚫 FAILED: $violations architecture violation(s) found."
  echo "   Fix violations above, then re-run."
  echo "   Reference: docs/ARCHITECTURE_RULES.md"
  echo "════════════════════════════════════════════════════"
  exit 1
else
  echo "✅ PASSED: All architecture rules validated."
  echo "════════════════════════════════════════════════════"
  exit 0
fi
