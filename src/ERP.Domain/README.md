# 📘 ERP.Domain — Core Business Layer

## Purpose
The Domain layer contains the core business model and rules. It must remain pure, framework-free, and independent from infrastructure or UI concerns.

## Responsibilities
- Model business concepts using entities, value objects, and aggregates where justified.
- Enforce business invariants within aggregate boundaries.
- Raise domain events that describe meaningful business occurrences.

## Current model (project state)
This project currently focuses on Accounting as the initial bounded context.

Primary namespace: `ERP.Domain.Accounting.*`

### Building blocks
- Base types:
  - `Entity<TId>`
  - `ValueObject`
  - `DomainEvent`

### Aggregates and entities
- Journals
  - Aggregate Root: `Accounting.Aggregates.Journals.Journal`
    - Holds `JournalLine` entries
    - Enforces invariants:
      - Only Draft journals can be modified
      - On `Post()`: must have at least one line
      - On `Post()`: total debit must equal total credit
      - All lines must share the same currency
  - Entity: `Accounting.Aggregates.Journals.JournalLine`
    - Enforces invariants:
      - Account is required
      - Amount is required
      - Debit/Credit amount must be > 0

- Ledgers
  - Aggregate Root: `Accounting.Aggregates.Ledgers.Ledger`
    - Enforces invariants when registering journals:
      - Ledger must be Open
      - Journal must be Posted
      - Journal accounting date must be within ledger period
      - Journal must not be registered twice

- Chart of Accounts
  - Aggregate Root: `Accounting.Aggregates.ChartOfAccounts.ChartOfAccounts`
    - Enforces invariants:
      - Chart must be Open to mutate
      - Account numbers must be unique within the chart
  - Entity: `Accounting.Aggregates.Accounts.Account`
    - Lifecycle: Active/Inactive

### Value Objects
- `Money` + `Currency`
- Identifiers: `AccountId`, `JournalId`, `LedgerId`, `ChartOfAccountsId`, `ProjectId`
- Business values: `JournalNumber`, `AccountNumber`, `AccountName`, `ChartName`, `AccountingPeriod`

### Domain Events
- `JournalPosted(JournalId)`
- `LedgerClosed(LedgerId)`
- `ChartOpened(ChartOfAccountsId)`
- `AccountRegistered(AccountId, AccountNumber)`
- `AccountDeactivated(AccountId)`

### Domain Exceptions (invariants)
- `InvalidJournalLineException`, `UnbalancedJournalException`, `UnpostedJournalException`
- `JournalOutsidePeriodException`
- `LedgerClosedException`, `ChartClosedException`
- `DuplicateAccountNumberException`, `DuplicateJournalRegistrationException`, `AccountNotFoundException`
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
