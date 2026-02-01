# 📘 ERP.Domain — Core Business Layer

## Purpose
The Domain layer contains the core business model and rules. It must remain pure, framework-free, and independent from infrastructure or UI concerns.

## Responsibilities
- Model business concepts using entities, value objects, and aggregates where justified.
- Enforce business invariants within aggregate boundaries.
- Raise domain events that describe meaningful business occurrences.

## Boundaries
- No persistence, frameworks, or UI dependencies.
- No application orchestration or use-case flow logic.
