# فهرس التوثيق العام (Documentation Index)

هذا الملف يُمثل الفهرس الرئيسي لجميع ملفات التوثيق في المستودع.

> ⚠️ المرجع الحاكم لمراجعات PR: [`ARCHITECTURE_RULES.md`](ARCHITECTURE_RULES.md)

## ملفات التوثيق الرئيسية (`docs/`)

| الملف | الوصف |
| --- | --- |
| [overview.md](overview.md) | نظرة عامة على حل ERP وشجرة الوظائف |
| [architecture.md](architecture.md) | البنية المعمارية — Clean Architecture + DDD + CQRS |
| [ARCHITECTURE_RULES.md](ARCHITECTURE_RULES.md) | ⚠️ القواعد المعمارية الإلزامية — المرجع الحاكم |
| [documentation-map.md](documentation-map.md) | خريطة التوثيق الشاملة |

## توثيق المشاريع (`docs/projects/`)

| الملف | الوصف |
| --- | --- |
| [Domain.md](projects/Domain.md) | طبقة النطاق — النموذج والقواعد التجارية |
| [Application.md](projects/Application.md) | طبقة التطبيق — حالات الاستخدام CQRS |
| [Infrastructure.md](projects/Infrastructure.md) | طبقة البنية التحتية — التنفيذات التقنية |
| [WinForms.md](projects/WinForms.md) | طبقة العرض — واجهة WinForms |
| [Bootstrapper.md](projects/Bootstrapper.md) | نقطة التشغيل — Composition Root |

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

## أقسام التوثيق المتخصصة

| المجلد | الوصف |
| --- | --- |
| [`domain/`](domain/) | توثيق مفاهيم طبقة النطاق (Aggregates, Events, Invariants) |
| [`application/`](application/) | توثيق مفاهيم طبقة التطبيق (Commands, Queries, Use Cases) |
| [`infrastructure/`](infrastructure/) | توثيق البنية التحتية (Persistence, Integrations) |
