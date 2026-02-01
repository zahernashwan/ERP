# 🧱 ERP.Bootstrapper — Composition Root

## Purpose
`ERP.Bootstrapper` is the application entrypoint and **composition root**.

It wires up Dependency Injection and starts the UI.

## Responsibilities
- Configure the `IServiceCollection` by registering:
  - Application layer (`AddApplication`)
  - Infrastructure layer (`AddInfrastructure`)
  - Presentation (WinForms Forms + controllers)
- Create a DI scope for the running application.
- Resolve and run `MainForm`.

## Key files
- `Program.cs`
  - Starts the application and runs `MainForm` resolved from DI.
- `ContainerConfiguration.cs`
  - Central place for DI registrations for all layers.

## Boundaries
- No business logic.
- No domain rules.
- Keep only wiring/registration and startup concerns.
