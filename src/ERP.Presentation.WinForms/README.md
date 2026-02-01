# 📕 ERP.Presentation.WinForms — UI Layer

## Purpose
WinForms Presentation layer for ERP.

`MainForm` is the application shell (entry UI) and provides navigation only.

## Architecture
- Pattern: Application Shell + Controller (Passive View)
- `MainForm` delegates navigation to `INavigationController`
- Work screens are separate Forms

The UI follows a Supervising Controller style:
- Forms are views (passive)
- Controllers coordinate Application use cases (commands/queries) and update the views

## Current UI components
- `MainForm`
  - Shell/Navigation only
  - Contains menus that trigger navigation actions
  - Does not instantiate forms directly and does not call Application Use Cases
- `INavigationController` / `NavigationController`
  - Responsible for opening work Forms via DI
  - Owns navigation decisions (e.g. modal vs non-modal)

### Accounting module (current screens)
- Journals
  - `Accounting.Journals.JournalsListForm`
  - `Accounting.Journals.JournalDetailsForm`
  - `Accounting.Journals.JournalsController`

- Chart of Accounts
  - `Accounting.ChartOfAccounts.ChartsListForm`
  - `Accounting.ChartOfAccounts.ChartDetailsForm`
  - `Accounting.ChartOfAccounts.ChartsController`

- Ledgers
  - `Accounting.Ledgers.LedgersListForm`
  - `Accounting.Ledgers.LedgerDetailsForm`
  - `Accounting.Ledgers.LedgersController`

## Dependency Injection and startup
The DI-backed entrypoint is `ERP.Bootstrapper` which resolves `MainForm` from the container.

`ERP.Presentation.WinForms/Program.cs` exists for local runs as a fallback, but it is not the intended entrypoint for production.

## Project verification (deep check)
- `dotnet build` succeeded
- `dotnet test` succeeded (including `ERP.ArchitectureGuard`)
- Duplicate Journals work screen was removed; the canonical entry screen is `ERP.Presentation.WinForms.Accounting.Journals.JournalsListForm`

## Feature screen conventions

| Item | Role |
| --- | --- |
| `*ListForm` | Show list + selection |
| `*DetailsForm` | Show details (read-only) |
| `*Controller` | Execute queries and update the view |

## Boundaries
- No business logic, domain rules, or direct infrastructure access in Forms.
- `MainForm` must not:
  - create other Forms using `new`
  - call Commands/Queries/Use Cases
  - access repositories or infrastructure

Controllers must not:
- access Infrastructure implementations directly
- implement domain rules (use Domain + Application)
