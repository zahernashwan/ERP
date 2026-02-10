<!-- AUTO-GENERATED — do not edit manually. Run scripts/generate-readme.sh -->

# NoufexERP Documentation

## Table of Contents

- [نظرة عامة — ERP Solution](docs/overview.md)
- [البنية المعمارية — Clean Architecture + DDD + CQRS](docs/architecture.md)
- [خريطة التوثيق (Documentation Map)](docs/documentation-map.md)
- [طبقة التطبيق (Application Layer)](docs/projects/Application.md)
- [طبقة النطاق (Domain Layer)](docs/projects/Domain.md)
- [طبقة البنية التحتية (Infrastructure Layer)](docs/projects/Infrastructure.md)
- [طبقة العرض — WinForms (Presentation Layer)](docs/projects/WinForms.md)
- [الحسابات (Account)](docs/modules/Account.md)
- [الدليل المحاسبي (Chart of Accounts)](docs/modules/ChartOfAccounts.md)
- [مراكز التكلفة (Cost Centers)](docs/modules/CostCenters.md)
- [المخزون (Inventory)](docs/modules/Inventory.md)
- [القيود اليومية (Journal)](docs/modules/Journal.md)
- [دفتر الأستاذ (Ledger)](docs/modules/Ledger.md)
- [المشتريات (Purchases)](docs/modules/Purchases.md)
- [المبيعات (Sales)](docs/modules/Sales.md)
- [Aggregates](docs/domain/aggregates.md)
- [Domain Events](docs/domain/domain-events.md)
- [Invariants (القيود الجوهرية)](docs/domain/invariants.md)
- [Commands](docs/application/commands.md)
- [Queries](docs/application/queries.md)
- [Use Cases (حالات الاستخدام)](docs/application/use-cases.md)
- [Integrations (التكاملات الخارجية)](docs/infrastructure/integrations.md)
- [Persistence (التخزين)](docs/infrastructure/persistence.md)
- [الدليل المحاسبي (Chart of Accounts)](docs/accounting/chart-of-accounts.md)
- [مراكز التكلفة (Cost Centers)](docs/accounting/cost-centers.md)
- [القيود اليومية (Journals)](docs/accounting/journals.md)

---

# نظرة عامة — ERP Solution

هذا المستودع عبارة عن حل (.NET 8) مبني بأسلوب **Clean Architecture** مع WinForms كواجهة مستخدم.

## هدف حل ERP

هدف هذا الحل هو بناء نظام ERP مكتبي (WinForms) قابل للتوسع والصيانة، يغطي دورة العمل الأساسية للشركات عبر وحدات مترابطة تشمل:

- **التهيئة**: إعداد متغيرات النظام، الفترات، العملات، الدول/المدن، بيانات الشركة والفروع، الدليل المحاسبي، مراكز التكلفة، وإعدادات المخزون/الموردين/العملاء.
- **المدخلات**: إدخال البيانات المرجعية (الموظفين، الصناديق والبنوك، الأرصدة الافتتاحية، الأصناف والمخازن، الموردين والعملاء…).
- **العمليات**: تنفيذ العمليات اليومية (قيود/سندات/إشعارات، أوامر توريد/صرف/تحويل، مشتريات/مبيعات، ترحيل/إقفال…).
- **التقارير**: تقارير الحسابات والمخزون والمشتريات والمبيعات.
- **إدارة النظام**: المستخدمون والصلاحيات والنسخ الاحتياطي/الاسترجاع.

## شجرة الوظائف (Functional Map)

> ملاحظة: هذه الشجرة تُستخدم كمرجع نطاق (Scope) للمنتج. التنفيذ الحالي قد يغطي جزءًا منها ويتوسع تدريجيًا.

```
ERP
│
├─ التهيئة
│  │
│  ├─ تهيئة النظام
│  │  ├─ المتغيرات العامة
│  │  ├─ فترات النظام
│  │  ├─ العملات
│  │  │  ├─ تهيئة العملات
│  │  │  └─ إضافة عملة أجنبية
│  │  ├─ صلاحية المخزون
│  │  ├─ الأقاليم والدول
│  │  │  ├─ الدول
│  │  │  ├─ المحافظات
│  │  │  ├─ المدن
│  │  │  └─ المناطق
│  │  ├─ بيانات الشركة
│  │  ├─ بيانات الفروع
│  │  ├─ الدليل المحاسبي
│  │  └─ مراكز التكلفة
│  │
│  ├─ تهيئة أنظمة الحسابات
│  │  └─ متغيرات الأستاذ العام
│  │
│  ├─ تهيئة أنظمة المخازن
│  │  ├─ متغيرات المخزون
│  │  ├─ وحدات القياس
│  │  ├─ مستويات التسعيرة
│  │  ├─ أنواع التوريد
│  │  ├─ أنواع الصرف
│  │  └─ أنواع التحويل
│  │
│  ├─ تهيئة أنظمة الموردين
│  │  ├─ متغيرات الموردين
│  │  ├─ تهيئة المشتريات
│  │  └─ طرق التكاليف
│  │
│  └─ تهيئة نظام العملاء
│     └─ متغيرات العملاء
│
├─ المدخلات
│  │
│  ├─ مدخلات النظام
│  │  ├─ الهيكل الإداري
│  │  ├─ بيانات الموظفين
│  │  ├─ الحسابات الوسيطة
│  │  └─ مراكز التكلفة
│  │
│  ├─ مدخلات الحسابات
│  │  ├─ الصناديق
│  │  ├─ البنوك
│  │  └─ الأرصدة الافتتاحية (حسابات)
│  │
│  ├─ مدخلات المخازن
│  │  ├─ المجموعات الرئيسية
│  │  ├─ مجموعات المخازن
│  │  ├─ المخازن
│  │  ├─ الأرفف
│  │  ├─ الأصناف
│  │  ├─ ملحقات الأصناف
│  │  ├─ الأصناف المركبة
│  │  ├─ تسعيرة الأصناف
│  │  ├─ المخزون الافتتاحي
│  │  └─ ربط المخزون بالأستاذ العام
│  │
│  ├─ مدخلات الموردين
│  │  ├─ مجموعات الموردين
│  │  └─ الموردين
│  │
│  └─ مدخلات العملاء
│     ├─ مجموعات العملاء
│     └─ العملاء
│
├─ العمليات
│  │
│  ├─ عمليات الحسابات
│  │  ├─ سند صرف نقدي
│  │  ├─ سند صرف شيك
│  │  ├─ سند قبض نقدي
│  │  ├─ سند قبض شيك
│  │  ├─ القيود اليومية
│  │  ├─ طلب قيد يومية
│  │  ├─ إشعار مدين
│  │  ├─ إشعار دائن
│  │  └─ صرف عملة
│  │
│  ├─ عمليات المخزون
│  │  ├─ أمر توريد مخزني
│  │  ├─ أمر صرف مخزني
│  │  ├─ تحويل مخزني
│  │  ├─ استلام تحويل
│  │  ├─ تسوية مخزون
│  │  └─ جرد المخزون
│  │
│  ├─ إدارة المشتريات
│  │  ├─ فاتورة مشتريات محلية
│  │  ├─ فاتورة مشتريات خارجية
│  │  ├─ أوامر الشراء
│  │  ├─ مرتجع مشتريات
│  │  └─ اعتماد مستندي
│  │
│  ├─ إدارة المبيعات
│  │  ├─ فاتورة مبيعات
│  │  └─ مردود مبيعات
│  │
│  └─ المراجعة والترحيلات
│     ├─ اعتماد الوثائق
│     ├─ الترحيل
│     ├─ إلغاء الترحيل
│     └─ الإقفال الشهري
│
├─ التقارير
│  ├─ تقارير الحسابات
│  │  ├─ الأستاذ العام
│  │  └─ ميزان المراجعة
│  ├─ تقارير المخزون
│  ├─ تقارير المشتريات
│  └─ تقارير المبيعات
│
└─ إدارة النظام
   ├─ المستخدمون
   ├─ الصلاحيات
   │  ├─ صلاحيات الشاشات
   │  └─ صلاحيات العمليات
   ├─ تغيير كلمة المرور
   ├─ النسخ الاحتياطي
   └─ استرجاع نسخة احتياطية
```

## Quick Start

المتطلبات: .NET SDK 8

### Build

```bash
dotnet build -c Release
```

### Run

نقطة التشغيل المفضلة (Composition Root):

```bash
dotnet run --project src/ERP.Bootstrapper
```

### Test

```bash
dotnet test -c Release
```

---

# البنية المعمارية — Clean Architecture + DDD + CQRS

هذا الحل يتبع **Clean Architecture** بشكل صارم، ويقسم النظام إلى أربع طبقات واضحة. كل طبقة لها مسؤوليات محددة وحدود صارمة، واتجاه الاعتمادات يكون نحو الداخل فقط.

## خريطة المشاريع (أين تضع الكود؟)

| المشروع | المسار | ماذا يحتوي؟ |
| --- | --- | --- |
| `ERP.Domain` | `src/ERP.Domain` | نموذج الأعمال: Aggregates/Entities/Value Objects/Domain Events + invariants |
| `ERP.Application` | `src/ERP.Application` | حالات الاستخدام (Use Cases) بصيغة CQRS خفيفة + حدود المعاملات (`IUnitOfWork`) + واجهات المستودعات |
| `ERP.Infrastructure` | `src/ERP.Infrastructure` | تنفيذات تقنية لواجهات Application (حاليًا In-Memory) + تسجيلها بالـ DI |
| `ERP.Presentation.WinForms` | `src/ERP.Presentation.WinForms` | الواجهة WinForms (Forms + Controllers) بدون منطق أعمال |
| `ERP.Bootstrapper` | `src/ERP.Bootstrapper` | نقطة التشغيل/Composition Root: تجميع الطبقات (DI) ثم تشغيل `MainForm` |

## اتجاه الاعتمادات (المسموح فقط)

```
Presentation  -> Application -> Domain
Infrastructure -> Application -> Domain
```

قواعد سريعة:
- `Domain` لا يعتمد على أي طبقة.
- `Application` يعتمد على `Domain` فقط ويعرّف واجهات البنية التحتية (مثل Repositories و `IUnitOfWork`).
- `Infrastructure` ينفّذ هذه الواجهات.
- `Presentation.WinForms` يتعامل مع `Application` عبر Handlers/Use Cases، ولا يصل للبنية التحتية مباشرة.

## الطبقات الأربع

### 1) Domain (ERP.Domain)

**المسؤوليات**
- تمثيل نموذج الأعمال (Entities / Value Objects / Aggregates عند الحاجة).
- فرض القواعد والقيود الجوهرية داخل حدود الـ Aggregate فقط.
- إصدار Domain Events لوصف أحداث الأعمال ذات المعنى.

**الحدود الصارمة**
- لا أطر عمل، لا بنية تحتية، لا واجهات مستخدم، ولا تخزين بيانات.
- لا يحتوي على منطق حالات استخدام أو تنسيق عمليات.

### 2) Application (ERP.Application)

**المسؤوليات**
- تنسيق حالات الاستخدام (Use Cases) وحدود المعاملات.
- تطبيق CQRS خفيف: **Commands تُغيّر الحالة**، **Queries لا تُغيّر الحالة**.
- الحفاظ على الاتساق بين الـ Aggregates واستهلاك Domain Events لتفعيل سير العمل.

**الحدود الصارمة**
- لا قواعد أعمال جوهرية (توجد في Domain فقط).
- لا تنفيذات تقنية أو تعامل مباشر مع البنية التحتية.

### 3) Infrastructure (ERP.Infrastructure)

**المسؤوليات**
- تنفيذ التفاصيل التقنية: قواعد البيانات، الرسائل، نظام الملفات، والخدمات الخارجية.
- توفير تطبيقات الواجهات (Interfaces) المعرفة في الداخل.

**الحدود الصارمة**
- لا منطق أعمال أو قواعد نطاق.
- تعتمد للداخل فقط ويمكن استبدالها بسهولة.

### 4) Presentation (ERP.Presentation.WinForms)

**المسؤوليات**
- عرض البيانات للمستخدم عبر WinForms.
- اتباع Supervising Controller / Passive View.
- الـ Controllers تنسق حالات الاستخدام وتحدّث الـ Views.

**الحدود الصارمة**
- لا منطق أعمال، لا قواعد نطاق، ولا وصول مباشر للبنية التحتية.

## نقطة التشغيل (Entrypoint)

المشروع المعتمد للتشغيل هو `ERP.Bootstrapper` لأنه الـ Composition Root.

```bash
dotnet run --project src/ERP.Bootstrapper
```

## الاختبارات

| المشروع | ماذا يختبر؟ |
| --- | --- |
| `tests/ERP.Domain.Tests` | سلوك الـ Domain والـ invariants |
| `tests/ERP.Application.Tests` | تنسيق حالات الاستخدام (handlers) والتكامل مع الـ repositories/UnitOfWork |
| `tests/ERP.ArchitectureGuard` | حراسة الحدود المعمارية (منع اعتمادات غير مسموحة بين الطبقات) |

تشغيل الكل:

```bash
dotnet test -c Release
```

## ملاحظات معمارية أساسية

- القواعد التجارية دائماً في Domain.
- التغييرات في البنية التحتية أو الواجهة لا يجب أن تؤثر على Domain.
- يتم حقن جميع الاعتمادات صراحةً دون Service Locators.

---

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
| [`docs/domain/domain-events.md`](domain/domain-events.md) | أحداث النطاق (Domain Events) |
| [`docs/domain/invariants.md`](domain/invariants.md) | القيود الجوهرية (Invariants) |

## توثيق طبقة التطبيق (`docs/application/`)

| الملف | الوصف |
| --- | --- |
| [`docs/application/commands.md`](application/commands.md) | الأوامر (Commands) — نية تغيير الحالة |
| [`docs/application/queries.md`](application/queries.md) | الاستعلامات (Queries) — طلب قراءة بدون تعديل |
| [`docs/application/use-cases.md`](application/use-cases.md) | حالات الاستخدام (Use Cases) |

## توثيق طبقة البنية التحتية (`docs/infrastructure/`)

| الملف | الوصف |
| --- | --- |
| [`docs/infrastructure/integrations.md`](infrastructure/integrations.md) | التكاملات الخارجية (Integrations) |
| [`docs/infrastructure/persistence.md`](infrastructure/persistence.md) | التخزين (Persistence) |

## توثيق وحدة المحاسبة (`docs/accounting/`)

| الملف | الوصف |
| --- | --- |
| [`docs/accounting/chart-of-accounts.md`](accounting/chart-of-accounts.md) | الدليل المحاسبي (Chart of Accounts) |
| [`docs/accounting/cost-centers.md`](accounting/cost-centers.md) | مراكز التكلفة (Cost Centers) |
| [`docs/accounting/journals.md`](accounting/journals.md) | القيود اليومية (Journals) |

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

---

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

---

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

---

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

---

# طبقة العرض — WinForms (Presentation Layer)

## الوصف العام

مشروع `ERP.Presentation.WinForms` يمثّل واجهة المستخدم المكتبية المبنية بـ Windows Forms. يتبع نمط Supervising Controller / Passive View، حيث الـ Forms تعرض البيانات والـ Controllers تنسّق حالات الاستخدام.

## المسار

```
src/ERP.Presentation.WinForms/
```

## البنية الداخلية

```
ERP.Presentation.WinForms/
├── Accounting/
│   └── Journals/
│       ├── JournalsListForm.cs
│       └── ...
├── MainForm.cs
└── ...
```

## المسؤوليات

- عرض البيانات للمستخدم عبر WinForms.
- اتباع Supervising Controller / Passive View.
- الـ Controllers تنسّق حالات الاستخدام وتحدّث الـ Views.

## الحدود الصارمة

- لا منطق أعمال، لا قواعد نطاق.
- لا وصول مباشر للبنية التحتية.
- تتعامل مع طبقة Application فقط عبر Handlers/Use Cases.

## الاعتماديات

- `ERP.Application` — حالات الاستخدام والاستعلامات.
- Windows Forms SDK (`<UseWindowsForms>true</UseWindowsForms>`).

## نقطة التشغيل

يتم تشغيل التطبيق عبر `ERP.Bootstrapper` (Composition Root):

```bash
dotnet run --project src/ERP.Bootstrapper
```

## الاختبارات

> لا يوجد مشروع اختبارات مستقل لطبقة العرض حاليًا.

---

# الحسابات (Account)

## الوصف العام

وحدة الحسابات تُمثل الحسابات المالية الفردية داخل الدليل المحاسبي. كل حساب يحمل رقمًا فريدًا ومستوى في الشجرة المحاسبية، ويُستخدم لتسجيل الحركات المالية (مدين/دائن).

## الموقع في الكود

```
src/ERP.Domain/Accounting/Aggregates/Accounts/
src/ERP.Application/Accounting/ChartOfAccounts/
```

## الكيانات والـ Value Objects

| العنصر | النوع | الوصف |
| --- | --- | --- |
| `Account` | Entity | الحساب المالي داخل الدليل المحاسبي |
| `AccountId` | Value Object | معرّف الحساب |
| `AccountNumber` | Value Object | رقم الحساب الفريد |
| `AccountName` | Value Object | اسم الحساب |

## القواعد (Invariants)

- كل حساب له رقم فريد (`AccountNumber`) داخل الدليل المحاسبي.
- الحسابات الأبوية لا تقبل قيودًا مباشرة.
- لا يمكن تعطيل حساب له أرصدة نشطة.

## أحداث النطاق (Domain Events)

| الحدث | الوصف |
| --- | --- |
| `AccountRegistered` | يُصدر عند تسجيل حساب جديد في الدليل |
| `AccountDeactivated` | يُصدر عند تعطيل حساب |

## حالات الاستخدام

| الأمر / الاستعلام | النوع | الوصف |
| --- | --- | --- |
| `RegisterAccount` | Command | تسجيل حساب جديد في الدليل المحاسبي |

## الاعتماديات

- ينتمي إلى Aggregate الدليل المحاسبي (`ChartOfAccounts`).
- يُستخدم في سطور القيود اليومية (`JournalLine`).

---

# الدليل المحاسبي (Chart of Accounts)

## الوصف العام

الدليل المحاسبي هو الهيكل الشجري للحسابات الذي يُنظّم جميع العمليات المالية. يمكن فتحه وتسجيل حسابات فيه، ولا يمكن تعديله بعد الإغلاق.

## الموقع في الكود

```
src/ERP.Domain/Accounting/Aggregates/ChartOfAccounts/
src/ERP.Application/Accounting/ChartOfAccounts/
```

## الكيانات والـ Value Objects

| العنصر | النوع | الوصف |
| --- | --- | --- |
| `ChartOfAccounts` | Aggregate Root | الدليل المحاسبي |
| `Account` | Entity | الحساب داخل الدليل |
| `ChartOfAccountsId` | Value Object | معرّف الدليل |
| `ChartName` | Value Object | اسم الدليل |

## القواعد (Invariants)

- لا يمكن تسجيل حساب برقم مكرر (`DuplicateAccountNumberException`).
- لا يمكن تعديل دليل مُغلق (`ChartClosedException`).
- كل حساب له رقم فريد ومستوى في الشجرة.

## أحداث النطاق (Domain Events)

| الحدث | الوصف |
| --- | --- |
| `ChartOpened` | يُصدر عند فتح دليل محاسبي جديد |
| `AccountRegistered` | يُصدر عند تسجيل حساب في الدليل |

## حالات الاستخدام

| الأمر / الاستعلام | النوع | الوصف |
| --- | --- | --- |
| `OpenChart` | Command | فتح دليل محاسبي جديد |
| `RegisterAccount` | Command | تسجيل حساب في الدليل |
| `GetChartById` | Query | استعلام عن دليل بمعرّفه |
| `ListCharts` | Query | عرض قائمة الأدلة المحاسبية |

## الاعتماديات

- يحتوي على كيانات `Account`.
- يُستخدم كمرجع لسطور القيود اليومية.

---

# مراكز التكلفة (Cost Centers)

## الوصف العام

مراكز التكلفة تسمح بتتبع المصاريف والإيرادات على مستوى أدق من الحساب (مثل: فرع، قسم، مشروع). تُستخدم في التقارير التحليلية وربط القيود بأبعاد إضافية.

## الموقع في الكود

```
src/ERP.Domain/Accounting/
```

## الكيانات والـ Value Objects

| العنصر | النوع | الوصف |
| --- | --- | --- |
| `ProjectId` | Value Object | معرّف مركز التكلفة/المشروع |

## القواعد (Invariants)

- كل مركز تكلفة له رقم فريد.
- يمكن ربطه بسطور القيود اليومية.
- يُستخدم في التقارير التحليلية.

## أحداث النطاق (Domain Events)

> لم تُنفَّذ بعد — سيتم إضافتها عند بناء Aggregate مستقل لمراكز التكلفة.

## حالات الاستخدام

> لم تُنفَّذ بعد — مخطط لها ضمن التوسعات المستقبلية.

## الاعتماديات

- يُربط بسطور القيود اليومية (`JournalLine`) عبر `ProjectId`.

---

# المخزون (Inventory)

## الوصف العام

وحدة المخزون تغطي إدارة المخازن والأصناف وحركات المخزون: توريد، صرف، تحويل، تسوية، وجرد. تتضمن إعداد وحدات القياس، مستويات التسعيرة، والمخزون الافتتاحي.

## الموقع في الكود

> لم تُنفَّذ بعد — مخطط لها ضمن التوسعات المستقبلية.

```
src/ERP.Domain/Inventory/          (مخطط)
src/ERP.Application/Inventory/     (مخطط)
```

## الكيانات والـ Value Objects

> سيتم تعريفها عند التنفيذ. المتوقع:

| العنصر | النوع | الوصف |
| --- | --- | --- |
| `Warehouse` | Aggregate Root | المخزن |
| `Item` | Aggregate Root | الصنف |
| `StockMovement` | Entity | حركة مخزنية |
| `StockAdjustment` | Entity | تسوية مخزون |

## القواعد (Invariants)

- لا يمكن صرف كمية أكبر من الرصيد المتاح.
- التحويل بين المخازن يتطلب استلامًا مطابقًا.
- التسوية تُعدّل الرصيد مع توثيق السبب.
- الجرد يُطابق الأرصدة الفعلية مع الدفترية.

## أحداث النطاق (Domain Events)

> سيتم تعريفها عند التنفيذ.

## حالات الاستخدام

> من شجرة الوظائف:

| العملية | الوصف |
| --- | --- |
| أمر توريد مخزني | استلام أصناف في المخزن |
| أمر صرف مخزني | صرف أصناف من المخزن |
| تحويل مخزني | نقل أصناف بين المخازن |
| استلام تحويل | تأكيد استلام التحويل |
| تسوية مخزون | تعديل أرصدة المخزون |
| جرد المخزون | مطابقة الأرصدة الفعلية والدفترية |

## الاعتماديات

- تعتمد على وحدة الحسابات لربط المخزون بالأستاذ العام.
- تُستخدم من وحدتي المبيعات والمشتريات.

---

# القيود اليومية (Journal)

## الوصف العام

القيد اليومي هو الوحدة الأساسية للتسجيل المحاسبي. كل قيد يحتوي سطورًا مدينة ودائنة يجب أن تتوازن. يُدار ضمن دفتر أستاذ (`Ledger`) ويمر بمراحل: إنشاء ← إضافة سطور ← ترحيل.

## الموقع في الكود

```
src/ERP.Domain/Accounting/Aggregates/Journals/
src/ERP.Application/Accounting/Journals/
```

## الكيانات والـ Value Objects

| العنصر | النوع | الوصف |
| --- | --- | --- |
| `Journal` | Aggregate Root | القيد اليومي |
| `JournalLine` | Entity | سطر القيد (مدين أو دائن) |
| `JournalId` | Value Object | معرّف القيد |
| `JournalNumber` | Value Object | رقم القيد التسلسلي |
| `Money` | Value Object | المبلغ المالي |
| `Currency` | Value Object | العملة |

## القواعد (Invariants)

- مجموع المدين = مجموع الدائن (invariant أساسي).
- القيد يحتوي سطرًا واحدًا على الأقل.
- بعد الترحيل لا يمكن التعديل.
- لا يمكن ترحيل قيد غير متوازن.

## أحداث النطاق (Domain Events)

| الحدث | الوصف |
| --- | --- |
| `JournalPosted` | يُصدر عند ترحيل القيد |

## حالات الاستخدام

| الأمر / الاستعلام | النوع | الوصف |
| --- | --- | --- |
| `StartJournal` | Command | بدء قيد يومية جديد |
| `AddJournalLine` | Command | إضافة سطر مدين أو دائن |
| `PostJournal` | Command | ترحيل القيد |
| `GetJournalById` | Query | استعلام عن قيد بمعرّفه |
| `ListJournals` | Query | عرض قائمة القيود |

## الاعتماديات

- يُسجَّل في دفتر الأستاذ (`Ledger`) عبر `RegisterJournal`.
- يستخدم `AccountId` لربط السطور بالحسابات.

---

# دفتر الأستاذ (Ledger)

## الوصف العام

دفتر الأستاذ هو الحاوية الزمنية للقيود اليومية. يرتبط بفترة محاسبية محددة ويمكن إقفاله لمنع أي تعديلات إضافية.

## الموقع في الكود

```
src/ERP.Domain/Accounting/Aggregates/Ledgers/
src/ERP.Application/Accounting/Ledgers/
```

## الكيانات والـ Value Objects

| العنصر | النوع | الوصف |
| --- | --- | --- |
| `Ledger` | Aggregate Root | دفتر الأستاذ |
| `LedgerId` | Value Object | معرّف الدفتر |
| `AccountingPeriod` | Value Object | الفترة المحاسبية |

## القواعد (Invariants)

- لا يمكن تسجيل قيد في دفتر مُقفل (`LedgerClosedException`).
- القيد يجب أن يكون ضمن الفترة المحاسبية للدفتر (`JournalOutsidePeriodException`).
- لا يمكن تسجيل قيد مكرر (`DuplicateJournalRegistrationException`).

## أحداث النطاق (Domain Events)

| الحدث | الوصف |
| --- | --- |
| `LedgerClosed` | يُصدر عند إقفال الدفتر |

## حالات الاستخدام

| الأمر / الاستعلام | النوع | الوصف |
| --- | --- | --- |
| `OpenLedger` | Command | فتح دفتر أستاذ جديد |
| `RegisterJournal` | Command | تسجيل قيد في الدفتر |
| `CloseLedger` | Command | إقفال الدفتر |
| `GetLedgerById` | Query | استعلام عن دفتر بمعرّفه |
| `ListLedgers` | Query | عرض قائمة الدفاتر |

## الاعتماديات

- يحتوي على مراجع للقيود اليومية (`Journal`).
- يعتمد على `AccountingPeriod` لتحديد صلاحية التسجيل.

---

# المشتريات (Purchases)

## الوصف العام

وحدة المشتريات تغطي إدارة فواتير المشتريات المحلية والخارجية، أوامر الشراء، مرتجعات المشتريات، والاعتمادات المستندية.

## الموقع في الكود

> لم تُنفَّذ بعد — مخطط لها ضمن التوسعات المستقبلية.

```
src/ERP.Domain/Purchases/          (مخطط)
src/ERP.Application/Purchases/     (مخطط)
```

## الكيانات والـ Value Objects

> سيتم تعريفها عند التنفيذ. المتوقع:

| العنصر | النوع | الوصف |
| --- | --- | --- |
| `PurchaseInvoice` | Aggregate Root | فاتورة المشتريات |
| `PurchaseOrder` | Aggregate Root | أمر الشراء |
| `PurchaseReturn` | Aggregate Root | مرتجع المشتريات |

## القواعد (Invariants)

- الفاتورة يجب أن تحتوي سطرًا واحدًا على الأقل.
- أمر الشراء يجب أن يُعتمد قبل التنفيذ.
- المرتجع يجب أن يرتبط بفاتورة أصلية.
- الاعتماد المستندي يرتبط بعملية استيراد خارجية.

## أحداث النطاق (Domain Events)

> سيتم تعريفها عند التنفيذ.

## حالات الاستخدام

> من شجرة الوظائف:

| العملية | الوصف |
| --- | --- |
| فاتورة مشتريات محلية | تسجيل فاتورة شراء محلية |
| فاتورة مشتريات خارجية | تسجيل فاتورة شراء خارجية (استيراد) |
| أوامر الشراء | إنشاء واعتماد أوامر شراء |
| مرتجع مشتريات | تسجيل مرتجع على فاتورة سابقة |
| اعتماد مستندي | إدارة الاعتمادات المستندية |

## الاعتماديات

- تعتمد على وحدة الحسابات لتوليد القيود المحاسبية.
- تعتمد على وحدة المخزون لتحديث الأرصدة.
- تعتمد على بيانات الموردين.

---

# المبيعات (Sales)

## الوصف العام

وحدة المبيعات تغطي إدارة فواتير المبيعات ومردودات المبيعات. تشمل العمليات: إصدار فاتورة مبيعات، تسجيل مردود مبيعات، وربط الحركات بالحسابات والمخزون.

## الموقع في الكود

> لم تُنفَّذ بعد — مخطط لها ضمن التوسعات المستقبلية.

```
src/ERP.Domain/Sales/          (مخطط)
src/ERP.Application/Sales/     (مخطط)
```

## الكيانات والـ Value Objects

> سيتم تعريفها عند التنفيذ. المتوقع:

| العنصر | النوع | الوصف |
| --- | --- | --- |
| `SalesInvoice` | Aggregate Root | فاتورة المبيعات |
| `SalesReturn` | Aggregate Root | مردود المبيعات |

## القواعد (Invariants)

- الفاتورة يجب أن تحتوي سطرًا واحدًا على الأقل.
- مجموع الفاتورة يجب أن يتوافق مع سطورها.
- المردود يجب أن يرتبط بفاتورة أصلية.

## أحداث النطاق (Domain Events)

> سيتم تعريفها عند التنفيذ.

## حالات الاستخدام

> من شجرة الوظائف:

| العملية | الوصف |
| --- | --- |
| فاتورة مبيعات | إصدار فاتورة بيع للعميل |
| مردود مبيعات | تسجيل مردود على فاتورة سابقة |

## الاعتماديات

- تعتمد على وحدة الحسابات لتوليد القيود المحاسبية.
- تعتمد على وحدة المخزون لتحديث الأرصدة.

---

# Aggregates

## المبدأ

الـ Aggregate هو حدود الاتساق (Consistency Boundary) في نموذج الأعمال. كل Aggregate يحمي قواعده الداخلية (invariants) ولا يُعدَّل إلا عبر جذره (Aggregate Root).

## الموقع في الكود

```
src/ERP.Domain/
```

## القواعد

- كل Aggregate Root يرث من `Entity` أو يطبّق هوية فريدة.
- التعديل يتم فقط عبر methods على الـ Root.
- لا يُسمح بالوصول المباشر للكيانات الداخلية من خارج الـ Aggregate.

---

# Domain Events

## المبدأ

أحداث النطاق تصف **شيئاً حدث بالفعل** في سياق الأعمال. تُستخدم للتواصل بين الـ Aggregates بدون اقتران مباشر.

## الموقع في الكود

```
src/ERP.Domain/
```

## القواعد

- الحدث يُصاغ بصيغة الماضي (مثل `JournalPosted`، `AccountCreated`).
- الحدث لا يحتوي منطق أعمال — بيانات فقط.
- يتم إصداره من داخل الـ Aggregate Root.

---

# Invariants (القيود الجوهرية)

## المبدأ

الـ Invariants هي القواعد التي يجب أن تكون صحيحة **دائماً** داخل حدود الـ Aggregate. أي عملية تكسر invariant يجب أن تُرفض فوراً.

## الموقع في الكود

```
src/ERP.Domain/
```

## القواعد

- يتم فرض الـ invariants داخل الـ Aggregate Root (في constructor أو methods).
- عند الانتهاك يُرمى Exception واضح.
- الاختبارات في `tests/ERP.Domain.Tests` تتحقق من كل invariant.

---

# Commands

## المبدأ

الـ Command يمثّل **نية لتغيير الحالة**. كل Command يقابله Handler واحد ينسّق العملية.

## الموقع في الكود

```
src/ERP.Application/
```

## القواعد

- Command = كائن بيانات (DTO) يصف العملية المطلوبة.
- Handler يستدعي الـ Domain ثم يحفظ عبر Repository.
- لا يُرجع بيانات (أو يرجع ID فقط عند الضرورة).

---

# Queries

## المبدأ

الـ Query يمثّل **طلب قراءة بيانات** بدون تغيير الحالة. يفصل مسار القراءة عن مسار الكتابة (CQRS).

## الموقع في الكود

```
src/ERP.Application/
```

## القواعد

- Query = كائن بيانات يصف ما نريد قراءته.
- Handler يقرأ من Repository ويُرجع DTO.
- لا يُغيّر حالة أي Aggregate.

---

# Use Cases (حالات الاستخدام)

## المبدأ

حالة الاستخدام تنسّق تدفق العمل بين الـ Domain والـ Infrastructure عبر واجهات محددة.

## الموقع في الكود

```
src/ERP.Application/
```

## الحالة الحالية

- يوجد MediatR مسجّل عبر `ApplicationModule.AddApplication(IServiceCollection)`.
- لكن الـ use-case handlers حاليًا **لا تطبّق** `IRequestHandler`؛ يتم استدعاء `HandleAsync(...)` مباشرة.
- عند التحول لاحقًا إلى MediatR بشكل كامل، الهدف هو إرسال Commands/Queries عبر `ISender`.

## القواعد

- كل Use Case يقابل Command أو Query واحد.
- Handler يستخدم `IUnitOfWork` لضمان حدود المعاملة.
- لا يحتوي منطق أعمال — يفوّضه للـ Domain.

---

# Integrations (التكاملات الخارجية)

## المبدأ

أي تكامل مع أنظمة خارجية (APIs, Message Brokers, File Systems) يُنفَّذ في طبقة Infrastructure.

## الموقع في الكود

```
src/ERP.Infrastructure/
```

## القواعد

- كل تكامل يطبّق واجهة معرّفة في Application.
- لا يعتمد على طبقة Presentation.
- يُسجَّل في DI Container عبر `InfrastructureModule`.

---

# Persistence (التخزين)

## المبدأ

طبقة البنية التحتية تنفّذ واجهات التخزين المعرّفة في Application. التنفيذ الحالي يستخدم In-Memory.

## الموقع في الكود

```
src/ERP.Infrastructure/
```

## القواعد

- Repository يطبّق واجهة من Application.
- لا يحتوي منطق أعمال.
- يمكن استبداله بتنفيذ آخر (EF Core, Dapper, etc.) بدون تأثير على الطبقات الأخرى.

---

# الدليل المحاسبي (Chart of Accounts)

## المبدأ

الدليل المحاسبي هو الهيكل الشجري للحسابات الذي يُنظم جميع العمليات المالية.

## الموقع في الكود

```
src/ERP.Domain/Accounting/
```

## القواعد

- كل حساب له رقم فريد ومستوى في الشجرة.
- الحسابات الأبوية لا تقبل قيوداً مباشرة.
- يتم ربط الحسابات بمراكز التكلفة عند الحاجة.

---

# مراكز التكلفة (Cost Centers)

## المبدأ

مراكز التكلفة تسمح بتتبع المصاريف والإيرادات على مستوى أدق من الحساب (مثل: فرع، قسم، مشروع).

## الموقع في الكود

```
src/ERP.Domain/Accounting/
```

## القواعد

- كل مركز تكلفة له رقم فريد.
- يمكن ربطه بسطور القيود اليومية.
- يُستخدم في التقارير التحليلية.

---

# القيود اليومية (Journals)

## المبدأ

القيد اليومي هو الوحدة الأساسية للتسجيل المحاسبي. كل قيد يحتوي سطوراً مدينة ودائنة يجب أن تتوازن.

## الموقع في الكود

```
src/ERP.Domain/Accounting/
```

## القواعد

- مجموع المدين = مجموع الدائن (invariant أساسي).
- القيد يحتوي سطراً واحداً على الأقل.
- بعد الترحيل لا يمكن التعديل.

---

_Last generated: 2026-02-10 00:41:56 UTC_
