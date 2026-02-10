# خريطة التوثيق (Documentation Map)

يعرض هذا الملف قائمة شاملة بجميع ملفات التوثيق الموجودة حالياً في المستودع.

## ملفات التوثيق الرئيسية (`docs/`)

| الملف | الوصف |
| --- | --- |
| [`docs/overview.md`](overview.md) | نظرة عامة على حل ERP وشجرة الوظائف |
| [`docs/architecture.md`](architecture.md) | البنية المعمارية — Clean Architecture + DDD + CQRS |
| [`docs/README.template.md`](README.template.md) | قالب توليد README.md وقواعد التوثيق |
| [`docs/documentation-map.md`](documentation-map.md) | هذا الملف — فهرس ملفات التوثيق |

## توثيق المشاريع (`docs/projects/`)

| الملف | الوصف |
| --- | --- |
| [`docs/projects/Domain.md`](projects/Domain.md) | طبقة النطاق — النموذج والقواعد التجارية |
| [`docs/projects/Application.md`](projects/Application.md) | طبقة التطبيق — حالات الاستخدام CQRS |
| [`docs/projects/Infrastructure.md`](projects/Infrastructure.md) | طبقة البنية التحتية — التنفيذات التقنية |
| [`docs/projects/WinForms.md`](projects/WinForms.md) | طبقة العرض — واجهة WinForms |
| [`docs/projects/Bootstrapper.md`](projects/Bootstrapper.md) | نقطة التشغيل — Composition Root |

## توثيق الموديلات (`docs/modules/`)

| الملف | الوصف |
| --- | --- |
| [`docs/modules/Account.md`](modules/Account.md) | الحسابات المالية |
| [`docs/modules/ChartOfAccounts.md`](modules/ChartOfAccounts.md) | الدليل المحاسبي |
| [`docs/modules/CostCenters.md`](modules/CostCenters.md) | مراكز التكلفة |
| [`docs/modules/Inventory.md`](modules/Inventory.md) | المخزون |
| [`docs/modules/Journal.md`](modules/Journal.md) | القيود اليومية |
| [`docs/modules/Ledger.md`](modules/Ledger.md) | دفتر الأستاذ |
| [`docs/modules/Purchases.md`](modules/Purchases.md) | المشتريات |
| [`docs/modules/Sales.md`](modules/Sales.md) | المبيعات |

## توثيق طبقة النطاق (`docs/domain/`)

| الملف | الوصف |
| --- | --- |
| [`docs/domain/aggregates.md`](domain/aggregates.md) | الـ Aggregates — حدود الاتساق في نموذج الأعمال |
| [`docs/domain/domain-events.md`](domain/domain-events.md) | أحداث النطاق — التواصل بين الكيانات المجمّعة |
| [`docs/domain/invariants.md`](domain/invariants.md) | القيود الجوهرية — القواعد الثابتة داخل الـ Aggregate |

## توثيق طبقة التطبيق (`docs/application/`)

| الملف | الوصف |
| --- | --- |
| [`docs/application/commands.md`](application/commands.md) | الأوامر — نية تغيير الحالة |
| [`docs/application/queries.md`](application/queries.md) | الاستعلامات — طلب قراءة بدون تعديل |
| [`docs/application/use-cases.md`](application/use-cases.md) | حالات الاستخدام — تنسيق تدفق العمل |

## توثيق طبقة البنية التحتية (`docs/infrastructure/`)

| الملف | الوصف |
| --- | --- |
| [`docs/infrastructure/integrations.md`](infrastructure/integrations.md) | التكاملات الخارجية — الأنظمة والخدمات الخارجية |
| [`docs/infrastructure/persistence.md`](infrastructure/persistence.md) | التخزين — تنفيذ واجهات التخزين |

## ملفات README للمشاريع (`src/`)

| الملف | الوصف |
| --- | --- |
| [`src/ERP.Domain/README.md`](../src/ERP.Domain/README.md) | توثيق طبقة النطاق — النموذج والقواعد التجارية |
| [`src/ERP.Application/README.md`](../src/ERP.Application/README.md) | توثيق طبقة التطبيق — حالات الاستخدام CQRS |
| [`src/ERP.Infrastructure/README.md`](../src/ERP.Infrastructure/README.md) | توثيق طبقة البنية التحتية — التنفيذات التقنية |
| [`src/ERP.Presentation.WinForms/README.md`](../src/ERP.Presentation.WinForms/README.md) | توثيق طبقة العرض — واجهة WinForms |
| [`src/ERP.Bootstrapper/README.md`](../src/ERP.Bootstrapper/README.md) | توثيق نقطة التشغيل — Composition Root |

## ملفات README للاختبارات (`tests/`)

| الملف | الوصف |
| --- | --- |
| [`tests/ERP.Domain.Tests/README.md`](../tests/ERP.Domain.Tests/README.md) | اختبارات وحدة النطاق |
| [`tests/ERP.Application.Tests/README.md`](../tests/ERP.Application.Tests/README.md) | اختبارات طبقة التطبيق |
| [`tests/ERP.ArchitectureGuard/README.md`](../tests/ERP.ArchitectureGuard/README.md) | حراسة الحدود المعمارية |

## ملفات أخرى في جذر المستودع

| الملف | الوصف |
| --- | --- |
| [`README.md`](../README.md) | ملف التوثيق الرئيسي (يُولَّد تلقائياً من `docs/`) |
| [`SECURITY.md`](../SECURITY.md) | سياسة الأمان والإبلاغ عن الثغرات |

## أدوات التوثيق

| الملف | الوصف |
| --- | --- |
| [`scripts/generate-readme.sh`](../scripts/generate-readme.sh) | سكربت توليد README.md تلقائياً من ملفات `docs/` |
| [`.github/workflows/docs-check.yml`](../.github/workflows/docs-check.yml) | سير عمل CI للتحقق من تحديث README.md |

_Last Updated: 2026-02-10_
