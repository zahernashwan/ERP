# طبقة البنية التحتية (Infrastructure Layer)

## الوصف العام

مشروع `ERP.Infrastructure` ينفّذ التفاصيل التقنية: تنفيذات المستودعات، التخزين، التكاملات الخارجية، وتسجيل الخدمات في DI Container. التنفيذ الحالي يستخدم In-Memory.

## المسار

```
src/ERP.Infrastructure/
```

## البنية الداخلية

```
ERP.Infrastructure/
├── Accounting/
│   ├── Journals/
│   ├── ChartOfAccounts/
│   └── Ledgers/
└── InfrastructureModule.cs
```

## المسؤوليات

- تنفيذ واجهات المستودعات المعرّفة في طبقة Application.
- توفير تطبيقات التخزين (حاليًا In-Memory، مستقبلاً EF Core أو Dapper).
- تسجيل الخدمات في DI Container عبر `InfrastructureModule`.

## الحدود الصارمة

- لا منطق أعمال أو قواعد نطاق.
- تعتمد للداخل فقط (على Application و Domain).
- يمكن استبدالها بسهولة دون تأثير على الطبقات الأخرى.

## الاعتماديات

- `ERP.Application` — واجهات المستودعات و `IUnitOfWork`.
- `ERP.Domain` — الكيانات والـ Value Objects.

## الاختبارات

> لا يوجد مشروع اختبارات مستقل للبنية التحتية حاليًا. يُختبر عبر اختبارات التكامل في `ERP.Application.Tests`.

_Last Updated: 2026-02-10_
