# 📘 ERP.Domain — Core Business Layer (Domain Model + Invariants)

## Purpose
The Domain layer contains the core business model and rules. It must remain pure, framework-free, and independent from infrastructure or UI concerns.

> Important
>
> `ERP.Domain` is **truth-definition** only (state + invariants + domain events), not truth-execution.
> Use cases/workflows/persistence belong to `ERP.Application` and `ERP.Infrastructure`.

## What exists in this project (real structure)

This project currently contains (source folders):

```plaintext
src/ERP.Domain
├─ Accounting/        # accounting domain model (aggregates + value objects + events + exceptions)
└─ Setup/             # setup/configuration domain model (state + policies + invariants)
```

Generated output folders like `bin/` and `obj/` are not part of the domain model.

## Responsibilities
- Model business concepts using entities, value objects, and aggregates where justified.
- Enforce business invariants within aggregate boundaries.
- Raise domain events that describe meaningful business occurrences.

## Current model (project state)
This project currently contains two domain areas:

```plaintext
ERP.Domain
├─ ERP.Domain.Accounting.*  # accounting aggregates + invariants (chart of accounts + accounts)
└─ ERP.Domain.Setup.*       # setup/configuration truth (state + policies + invariants)
```

### Building blocks
- Base types:
  - `Entity<TId>`
  - `ValueObject`
  - `DomainEvent`

## Domain areas (high-level content map)

### 1) Accounting (`ERP.Domain.Accounting.*`)

Direct documentation: `Accounting/README.md`.

High-level map (what to expect):

```plaintext
ERP.Domain.Accounting
├─ Aggregates/
│  └─ ChartOfAccounts (AR)
│     └─ Account (Entity)
├─ ValueObjects/      # Money/Currency + ids + business values
├─ Events/            # ChartOpened, AccountRegistered, AccountDeactivated
└─ Exceptions/        # invariant exceptions
```

### 2) Setup (`ERP.Domain.Setup.*`)

Direct documentation: `Setup/README.md`.

High-level map (what to expect):

```plaintext
ERP.Domain.Setup
├─ System/       # bounded contexts (implemented + placeholders)
├─ Inventory/    # bounded contexts (implemented + placeholders)
├─ Accounting/   # currently placeholders in some areas
├─ Suppliers/    # currently placeholders
└─ Customers/    # currently placeholders
```

```plaintext
Setup module pattern
├─ <Module>/
│  ├─ <Entity|ValueObject>.cs
│  ├─ <Id|Code|Name>.cs
│  ├─ Policies/          # optional
│  └─ *Namespace.cs      # placeholders where applicable
```

## Accounting domain (`ERP.Domain.Accounting.*`)

Documentation: `Accounting/README.md`.

### Aggregates
- Chart of accounts
  - Aggregate Root: `ERP.Domain.Accounting.Aggregates.ChartOfAccounts.ChartOfAccounts`
  - Enforces invariants:
    - the chart must be Open to mutate (otherwise `ChartClosedException`)
    - account numbers must be unique within the chart (otherwise `DuplicateAccountNumberException`)

### Entities (inside the aggregate)
- `ERP.Domain.Accounting.Aggregates.Accounts.Account`
  - lifecycle: `Activate()` / `Deactivate()`

### Value Objects
- `Money`
- `Currency`
- Identifiers: `AccountId`, `ChartOfAccountsId`, `ProjectId`
- Business values: `AccountNumber`, `AccountName`, `ChartName`, `AccountingPeriod`

### Domain Events
- `ChartOpened(ChartOfAccountsId)`
- `AccountRegistered(AccountId, AccountNumber)`
- `AccountDeactivated(AccountId)`

### Domain Exceptions (invariants)
- `ChartClosedException`: mutation attempted while chart is closed
- `DuplicateAccountNumberException`: duplicate account number within the chart
- `AccountNotFoundException`: account id not part of the chart
- `InvalidAccountException`: account validation failure (as used by the domain)

## Setup domain (`ERP.Domain.Setup.*`)

Setup models are in `Setup`. This area defines configuration state/policies/invariants (not use cases).

Documentation: `Setup/README.md`.

## Boundaries (non-negotiable)

- No persistence (no EF Core, no SQL, no repositories implementations).
- No application orchestration (no workflows/use-case logic).
- No UI types.
- No dependency injection.

Domain code may *define* domain events and domain policies/interfaces, but it does not *execute* application flows.

Dependency direction (allowed):

`Presentation` -> `Application` -> `Domain`

`Infrastructure` -> `Application` -> `Domain`

## Conventions
- Prefer enforcing invariants inside aggregates/entities (throw domain exceptions under the relevant `*.Exceptions` namespace).
- Keep domain model framework-free (no EF Core attributes, no DI, no UI types).
- Publish meaningful domain events when business state changes.

## Testing
Domain behaviors are verified in `tests/ERP.Domain.Tests`.

## Build
From the repository root:

```bash
dotnet build -c Release src/ERP.Domain/ERP.Domain.csproj
```
