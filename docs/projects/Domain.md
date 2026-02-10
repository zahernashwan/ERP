# طبقة النطاق (Domain Layer)

## الوصف العام

مشروع `ERP.Domain` يحتوي على نموذج الأعمال الأساسي: Aggregates، Entities، Value Objects، Domain Events، والقواعد الجوهرية (Invariants). هذه الطبقة لا تعتمد على أي طبقة أخرى.

## المسار

```
src/ERP.Domain/
```

## البنية الداخلية

```
ERP.Domain/
├── Accounting/
│   ├── Aggregates/
│   │   ├── Accounts/
│   │   ├── ChartOfAccounts/
│   │   ├── Journals/
│   │   └── Ledgers/
│   ├── ValueObjects/
│   ├── Events/
│   └── Exceptions/
├── Entity.cs
├── ValueObject.cs
├── DomainEvent.cs
└── AssemblyMarker.cs
```

## المسؤوليات

- تمثيل نموذج الأعمال (Entities / Value Objects / Aggregates).
- فرض القواعد والقيود الجوهرية داخل حدود الـ Aggregate.
- إصدار Domain Events لوصف أحداث الأعمال.

## الحدود الصارمة

- لا أطر عمل، لا بنية تحتية، لا واجهات مستخدم، ولا تخزين بيانات.
- لا يحتوي على منطق حالات استخدام أو تنسيق عمليات.
- لا يعتمد على أي مشروع آخر في الحل.

## الاعتماديات

لا يوجد — طبقة مستقلة تمامًا (innermost layer).

## الاختبارات

```
tests/ERP.Domain.Tests/
```

_Last Updated: 2026-02-10_
