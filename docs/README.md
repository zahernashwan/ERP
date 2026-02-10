# فهرس التوثيق العام (Documentation Index)

هذا الملف يُمثل الفهرس الرئيسي لجميع ملفات التوثيق في المستودع.

## توثيق المشاريع (`docs/projects/`)

| الملف | الوصف |
| --- | --- |
| [Domain.md](projects/Domain.md) | طبقة النطاق — النموذج والقواعد التجارية |
| [Application.md](projects/Application.md) | طبقة التطبيق — حالات الاستخدام CQRS |
| [Infrastructure.md](projects/Infrastructure.md) | طبقة البنية التحتية — التنفيذات التقنية |
| [WinForms.md](projects/WinForms.md) | طبقة العرض — واجهة WinForms |

## توثيق الموديلات (`docs/modules/`)

| الملف | الوصف |
| --- | --- |
| [Account.md](modules/Account.md) | الحسابات المالية |
| [ChartOfAccounts.md](modules/ChartOfAccounts.md) | الدليل المحاسبي |
| [CostCenters.md](modules/CostCenters.md) | مراكز التكلفة |
| [Inventory.md](modules/Inventory.md) | المخزون |
| [Journal.md](modules/Journal.md) | القيود اليومية |
| [Ledger.md](modules/Ledger.md) | دفتر الأستاذ |
| [Purchases.md](modules/Purchases.md) | المشتريات |
| [Sales.md](modules/Sales.md) | المبيعات |

## ملفات التوثيق الأخرى

| الملف | الوصف |
| --- | --- |
| [overview.md](overview.md) | نظرة عامة على حل ERP |
| [architecture.md](architecture.md) | البنية المعمارية — Clean Architecture + DDD + CQRS |
| [documentation-map.md](documentation-map.md) | خريطة التوثيق الشاملة |

## أقسام التوثيق المتخصصة

| المجلد | الوصف |
| --- | --- |
| [`domain/`](domain/) | توثيق مفاهيم طبقة النطاق (Aggregates, Events, Invariants) |
| [`application/`](application/) | توثيق مفاهيم طبقة التطبيق (Commands, Queries, Use Cases) |
| [`infrastructure/`](infrastructure/) | توثيق البنية التحتية (Persistence, Integrations) |
| [`accounting/`](accounting/) | توثيق وحدة المحاسبة |
