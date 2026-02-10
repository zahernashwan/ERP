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

_Last Updated: 2026-02-10_
