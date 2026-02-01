# 🧪 ERP.Domain.Tests — Domain Unit Tests

## Purpose
Unit tests for `ERP.Domain`.

## What is tested
- Aggregate behavior and invariants (e.g. Journals balancing and posting rules).
- Domain exceptions thrown for invalid operations.

## Guidelines
- Tests are written using xUnit.
- Focus on testing domain behavior through public APIs.
- Avoid infrastructure/IO dependencies.

## Run
```bash
dotnet test -c Release
```
