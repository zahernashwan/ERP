# 🧪 ERP.Application.Tests — Application Layer Tests

## Purpose
Tests for `ERP.Application` use cases (CQRS handlers).

## What is tested
- Command handler orchestration (repository + unit of work calls).
- Error handling and null-guard behavior.

## Notes
- Use xUnit.
- Prefer fakes over mocks where practical.

## Run
From the repository root:

```bash
dotnet test -c Release tests/ERP.Application.Tests
```
