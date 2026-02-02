# 📘 ERP.Domain — Core Business Layer

## Purpose
The Domain layer contains the core business model and rules. It must remain pure, framework-free, and independent from infrastructure or UI concerns.

## Responsibilities
- Model business concepts using entities, value objects, and aggregates where justified.
- Enforce business invariants within aggregate boundaries.
- Raise domain events that describe meaningful business occurrences.

## Current model (project state)
This project is restricted to **setup/configuration** domain models only.

Primary namespace: `ERP.Domain.Accounting.*` (setup only)

### Building blocks
- Base types:
  - `Entity<TId>`
  - `ValueObject`
  - `DomainEvent`

### Aggregates and entities
- Chart of Accounts (Setup)
  - Aggregate Root: `Accounting.Aggregates.ChartOfAccounts.ChartOfAccounts`
    - Enforces invariants:
      - Chart must be Open to mutate
      - Account numbers must be unique within the chart
  - Entity: `Accounting.Aggregates.Accounts.Account`
    - Lifecycle: Active/Inactive

### Value Objects
- `Money` + `Currency`
- Identifiers: `AccountId`, `ChartOfAccountsId`, `ProjectId`
- Business values: `AccountNumber`, `AccountName`, `ChartName`, `AccountingPeriod`

### Domain Events
- `ChartOpened(ChartOfAccountsId)`
- `AccountRegistered(AccountId, AccountNumber)`
- `AccountDeactivated(AccountId)`

### Domain Exceptions (invariants)
- `ChartClosedException`
- `DuplicateAccountNumberException`, `AccountNotFoundException`
- `InvalidAccountException`

## Conventions
- Prefer enforcing invariants inside aggregates/entities (throw domain exceptions under `Accounting.Exceptions`).
- Keep domain model framework-free (no EF Core attributes, no DI, no UI types).
- Publish meaningful domain events when business state changes.

## Boundaries
- No persistence, frameworks, or UI dependencies.
- No application orchestration or use-case flow logic.

## Testing
Domain behaviors are verified in `tests/ERP.Domain.Tests`.

## Build
From the repository root:

```bash
dotnet build -c Release src/ERP.Domain/ERP.Domain.csproj
```
