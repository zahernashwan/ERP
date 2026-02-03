# 🧩 ERP.ArchitectureGuard — Architecture Tests

## Purpose
Guards architectural boundaries across the solution (layering rules, forbidden dependencies, etc.).

```plaintext
tests/ERP.ArchitectureGuard
└─ *.cs  # architecture boundary tests
```

## How it fits
- Runs as part of the test suite.
- Fails the build if the dependency graph violates the intended architecture.

## Run
From the repository root:

```bash
dotnet test -c Release tests/ERP.ArchitectureGuard/ERP.ArchitectureGuard.csproj
```
