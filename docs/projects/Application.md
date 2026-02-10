# طبقة التطبيق (Application Layer)

## الوصف العام

مشروع `ERP.Application` يحتوي على حالات الاستخدام (Use Cases) بصيغة CQRS خفيفة، واجهات المستودعات، وحدود المعاملات (`IUnitOfWork`). ينسّق بين طبقة النطاق والبنية التحتية.

## المسار

```
src/ERP.Application/
```

## البنية الداخلية

```
ERP.Application/
├── Accounting/
│   ├── Journals/
│   │   ├── StartJournal/
│   │   ├── AddJournalLine/
│   │   ├── PostJournal/
│   │   ├── GetJournalById/
│   │   ├── ListJournals/
│   │   ├── IJournalRepository.cs
│   │   └── IJournalReadRepository.cs
│   ├── ChartOfAccounts/
│   │   ├── OpenChart/
│   │   ├── RegisterAccount/
│   │   ├── GetChartById/
│   │   ├── ListCharts/
│   │   ├── IChartOfAccountsRepository.cs
│   │   └── IChartOfAccountsReadRepository.cs
│   └── Ledgers/
│       ├── OpenLedger/
│       ├── RegisterJournal/
│       ├── CloseLedger/
│       ├── GetLedgerById/
│       ├── ListLedgers/
│       ├── ILedgerRepository.cs
│       └── ILedgerReadRepository.cs
├── ICommand.cs
├── IQuery.cs
└── IUnitOfWork.cs
```

## المسؤوليات

- تنسيق حالات الاستخدام (Use Cases) وحدود المعاملات.
- تطبيق CQRS خفيف: **Commands تُغيّر الحالة**، **Queries لا تُغيّر الحالة**.
- تعريف واجهات المستودعات (Repository interfaces) للبنية التحتية.

## الحدود الصارمة

- لا قواعد أعمال جوهرية (توجد في Domain فقط).
- لا تنفيذات تقنية أو تعامل مباشر مع البنية التحتية.

## الاعتماديات

- `ERP.Domain` — النموذج والقواعد التجارية.
- MediatR — لإرسال Commands/Queries (مسجّل عبر `ApplicationModule`).

## الاختبارات

```
tests/ERP.Application.Tests/
```
