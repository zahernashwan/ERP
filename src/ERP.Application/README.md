# 📗 ERP.Application — Use Cases Layer

## Purpose
The Application layer orchestrates use cases and coordinates work between domain aggregates and infrastructure.

## Responsibilities
- Implement use cases using lightweight CQRS (commands mutate; queries do not).
- Define transaction boundaries and consistency policies across aggregates.
- Consume domain events to trigger application-level workflows.

## Current implementation (project state)
The solution currently focuses on Accounting/Journals use cases.

### CQRS building blocks
- Marker abstractions:
  - `ICommand<TResult>`
  - `IQuery<TResult>`
- Transaction boundary:
  - `IUnitOfWork`
- Persistence abstractions:
  - `Accounting.Journals.IJournalRepository`
  - `Accounting.Journals.IJournalReadRepository`
  - `Accounting.ChartOfAccounts.IChartOfAccountsRepository`
  - `Accounting.ChartOfAccounts.IChartOfAccountsReadRepository`
  - `Accounting.Ledgers.ILedgerRepository`
  - `Accounting.Ledgers.ILedgerReadRepository`

### Journals use cases
- Start:
  - `StartJournalCommand`
  - `StartJournalHandler.HandleAsync(StartJournalCommand, CancellationToken)`
- Add line:
  - `AddJournalLineCommand`
  - `AddJournalLineHandler.HandleAsync(AddJournalLineCommand, CancellationToken)`
- Post:
  - `PostJournalCommand`
  - `PostJournalHandler.HandleAsync(PostJournalCommand, CancellationToken)`

### Chart of Accounts use cases
- Open chart:
  - `OpenChartCommand`
  - `OpenChartHandler.HandleAsync(OpenChartCommand, CancellationToken)`
- Register account:
  - `RegisterAccountCommand`
  - `RegisterAccountHandler.HandleAsync(RegisterAccountCommand, CancellationToken)`

### Ledgers use cases
- Open ledger:
  - `OpenLedgerCommand`
  - `OpenLedgerHandler.HandleAsync(OpenLedgerCommand, CancellationToken)`
- Register journal:
  - `RegisterJournalCommand`
  - `RegisterJournalHandler.HandleAsync(RegisterJournalCommand, CancellationToken)`
- Close ledger:
  - `CloseLedgerCommand`
  - `CloseLedgerHandler.HandleAsync(CloseLedgerCommand, CancellationToken)`

## Read use cases (queries)
Queries return DTOs/read models and do not mutate domain state.

### Journals queries
- Get by id:
  - `GetJournalByIdQuery`
  - `GetJournalByIdHandler.HandleAsync(GetJournalByIdQuery, CancellationToken)`
- List:
  - `ListJournalsQuery`
  - `ListJournalsHandler.HandleAsync(ListJournalsQuery, CancellationToken)`

### Chart of Accounts queries
- Get by id:
  - `GetChartByIdQuery`
  - `GetChartByIdHandler.HandleAsync(GetChartByIdQuery, CancellationToken)`
- List:
  - `ListChartsQuery`
  - `ListChartsHandler.HandleAsync(ListChartsQuery, CancellationToken)`

### Ledgers queries
- Get by id:
  - `GetLedgerByIdQuery`
  - `GetLedgerByIdHandler.HandleAsync(GetLedgerByIdQuery, CancellationToken)`
- List:
  - `ListLedgersQuery`
  - `ListLedgersHandler.HandleAsync(ListLedgersQuery, CancellationToken)`

### Dependency Injection
`ApplicationModule.AddApplication(IServiceCollection)` registers MediatR and scans this assembly.

Important: the current handlers are plain classes and do **not** implement MediatR `IRequestHandler` yet. Use cases are currently invoked by calling `HandleAsync(...)` directly on the handler instance.

## Build
From the repository root:

```bash
dotnet build -c Release src/ERP.Application
```

## Notes
- Application code should remain framework-light and depend on abstractions.
- Infrastructure provides implementations of repositories and `IUnitOfWork`.

## Extension points (next)
- Move to a stricter CQRS execution model by implementing MediatR `IRequest` / `IRequestHandler` and sending commands via `ISender`.
- Introduce queries (`IQuery<TResult>`) and query handlers when read models are added.
- Add domain event handling at the application level when workflows are introduced.

## Boundaries
- No core business rules; those live in the Domain.
- No direct infrastructure implementations or UI concerns.
