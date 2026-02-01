# 📗 ERP.Application — Use Cases Layer

## Purpose
The Application layer orchestrates use cases and coordinates work between domain aggregates and infrastructure.

## Responsibilities
- Implement use cases using lightweight CQRS (commands mutate; queries do not).
- Define transaction boundaries and consistency policies across aggregates.
- Consume domain events to trigger application-level workflows.

## Boundaries
- No core business rules; those live in the Domain.
- No direct infrastructure implementations or UI concerns.
