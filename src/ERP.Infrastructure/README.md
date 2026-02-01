# 📙 ERP.Infrastructure — Technical Implementations

## Purpose
The Infrastructure layer provides technical implementations for persistence and other technical concerns.

## Responsibilities
- Provide implementations for Application-layer abstractions (e.g. repositories, `IUnitOfWork`).
- Register infrastructure services via an extension method.

## Boundaries
- No business rules or domain logic.
- Depend inward on Application/Domain abstractions only.

## Current implementation (project state)
This project currently provides an in-memory persistence implementation used for development/testing:

- DI registrations: `InfrastructureModule.AddInfrastructure(IServiceCollection)`
  - `IUnitOfWork` -> `InMemoryUnitOfWork` (scoped)
  - `IJournalRepository` -> `InMemoryJournalRepository` (singleton)

### Notes
- `InMemoryJournalRepository` stores journals in-process. Data is not persisted between runs.
- This layer should remain swappable: real persistence (e.g. EF Core + SQL) can replace the in-memory implementation without changing the Application layer.

## Build
From the repository root:

```bash
dotnet build -c Release src/ERP.Infrastructure
```

## Extension points (next)
- Replace in-memory persistence with a database-backed implementation (EF Core), keeping the same Application interfaces.
- Add integrations (messaging, files, external services) behind Application abstractions.
