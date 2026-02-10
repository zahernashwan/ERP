#!/usr/bin/env bash
set -euo pipefail

# Generate README.md from /docs/**/*.md files.
# Usage: ./scripts/generate-readme.sh [--check]
#   --check  Verify that README.md is up-to-date (CI mode); exits non-zero if stale.

REPO_ROOT="$(cd "$(dirname "$0")/.." && pwd)"
DOCS_DIR="$REPO_ROOT/docs"
README="$REPO_ROOT/README.md"
MARKER="<!-- AUTO-GENERATED — do not edit manually. Run scripts/generate-readme.sh -->"

# ── helpers ──────────────────────────────────────────────────────────────────

die() { echo "ERROR: $*" >&2; exit 1; }

validate_title() {
  local file="$1"
  if ! grep -qm1 '^# ' "$file"; then
    die "File '$file' is missing a top-level '# Title' heading."
  fi
}

# ── collect doc files in defined order ───────────────────────────────────────

collect_files() {
  local files=()

  # Top-level docs first (fixed order)
  for f in "$DOCS_DIR/overview.md" "$DOCS_DIR/architecture.md" "$DOCS_DIR/ARCHITECTURE_RULES.md" "$DOCS_DIR/critical-recommendations.md" "$DOCS_DIR/documentation-map.md"; do
    [ -f "$f" ] && files+=("$f")
  done

  # Sub-directories in fixed order
  for dir in projects modules domain application infrastructure; do
    if [ -d "$DOCS_DIR/$dir" ]; then
      while IFS= read -r f; do
        files+=("$f")
      done < <(find "$DOCS_DIR/$dir" -name '*.md' | LC_ALL=C sort)
    fi
  done

  printf '%s\n' "${files[@]}"
}

# ── build README content ────────────────────────────────────────────────────

build_readme() {
  local files
  files=$(collect_files)

  [ -z "$files" ] && die "No documentation files found in $DOCS_DIR"

  # Header
  echo "$MARKER"
  echo ""
  echo "# NoufexERP Documentation"
  echo ""

  # Table of Contents (grouped by section)
  echo "## Table of Contents"
  echo ""

  local current_section=""
  while IFS= read -r file; do
    validate_title "$file"
    local title
    title=$(grep -m1 '^# ' "$file" | sed 's/^# //')
    local rel
    rel=$(python3 -c "import os.path; print(os.path.relpath('$file', '$REPO_ROOT'))")

    # Determine section from path and emit group header when it changes
    local section=""
    case "$file" in
      */projects/*) section="المشاريع (Projects)" ;;
      */modules/*)  section="الوحدات (Modules)" ;;
      */domain/*)   section="مفاهيم طبقة النطاق (Domain Concepts)" ;;
      */application/*) section="مفاهيم طبقة التطبيق (Application Concepts)" ;;
      */infrastructure/*) section="مفاهيم البنية التحتية (Infrastructure Concepts)" ;;
    esac

    if [ -n "$section" ] && [ "$section" != "$current_section" ]; then
      echo ""
      echo "### $section"
      echo ""
      current_section="$section"
    fi

    echo "- [$title]($rel)"
  done <<< "$files"
  echo ""

  # Separator
  echo "---"
  echo ""

  # Content sections
  while IFS= read -r file; do
    cat "$file"
    echo ""
    echo "---"
    echo ""
  done <<< "$files"

  # Footer
  echo "_Last generated: $(date -u '+%Y-%m-%d %H:%M:%S UTC')_"
}

# ── main ─────────────────────────────────────────────────────────────────────

check_mode=false
if [[ "${1:-}" == "--check" ]]; then
  check_mode=true
fi

generated=$(build_readme)

if $check_mode; then
  if [ ! -f "$README" ]; then
    die "README.md does not exist. Run: scripts/generate-readme.sh"
  fi

  # Compare ignoring the timestamp line (last line changes every run)
  existing_no_ts=$(sed '$d' "$README")
  generated_no_ts=$(echo "$generated" | sed '$d')

  if [ "$existing_no_ts" != "$generated_no_ts" ]; then
    die "README.md is out of date. Run: scripts/generate-readme.sh"
  fi

  echo "✅ README.md is up-to-date."
  exit 0
fi

echo "$generated" > "$README"
echo "✅ README.md generated successfully."
