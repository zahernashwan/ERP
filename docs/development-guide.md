# دليل التطوير — Development Guide

> 📂 `docs/` · [↑ خريطة التوثيق](documentation-map.md)

## الوصف العام

يوضح هذا الدليل كيفية المساهمة في المشروع، إضافة كيانات جديدة، ومعايير الكود المتّبعة.

## 🏗️ إضافة كيان جديد — Adding a New Entity

اتبع الخطوات التالية بالترتيب لإضافة كيان (Entity/Aggregate) جديد مع الحفاظ على Clean Architecture:

### 1. طبقة النطاق (Domain)

```
src/ERP.Domain/{Module}/Aggregates/{EntityName}/{EntityName}.cs
src/ERP.Domain/{Module}/ValueObjects/{ValueObjectName}.cs        # إن لزم
src/ERP.Domain/{Module}/Events/{EventName}.cs                    # إن لزم
src/ERP.Domain/{Module}/Exceptions/{ExceptionName}.cs            # إن لزم
```

- الكيان يرث من `Entity` ويُفرض فيه الـ invariants.
- القيم الثابتة (مثل `Money`, `AccountNumber`) تكون Value Objects.
- الأحداث تُصاغ بصيغة الماضي (`OrderPlaced`, `InvoiceIssued`).

### 2. طبقة التطبيق (Application)

```
src/ERP.Application/{Module}/{EntityName}/
├── I{EntityName}Repository.cs            # واجهة المستودع (write)
├── I{EntityName}ReadRepository.cs        # واجهة القراءة (read)
├── Create{Entity}/
│   ├── Create{Entity}Command.cs          # Command DTO
│   └── Create{Entity}Handler.cs          # Handler
├── Get{Entity}ById/
│   ├── Get{Entity}ByIdQuery.cs           # Query DTO
│   ├── Get{Entity}ByIdHandler.cs         # Handler
│   └── {Entity}DetailsDto.cs             # DTO للعرض
└── List{Entities}/
    ├── List{Entities}Query.cs
    ├── List{Entities}Handler.cs
    └── {Entity}ListItemDto.cs
```

- **Commands** تُغيّر الحالة — **Queries** لا تُغيّر الحالة (R-APP-01).
- Handler يفوّض منطق الأعمال للـ Domain (R-APP-07).

### 3. طبقة البنية التحتية (Infrastructure)

```
src/ERP.Infrastructure/Persistence/Repositories/InMemory{EntityName}Repository.cs
```

- ينفّذ الواجهات المعرّفة في Application (R-INF-01).
- يُسجَّل في `InfrastructureModule.cs` (R-INF-05).

### 4. طبقة العرض (Presentation)

```
src/ERP.Presentation.WinForms/{Module}/{EntityName}/
├── {EntityName}ListForm.cs
└── {EntityName}DetailsForm.cs
```

- لا منطق أعمال — عرض فقط (R-PRE-01).

### 5. الاختبارات (Tests)

```
tests/ERP.Domain.Tests/{Module}/{EntityName}/{EntityName}Tests.cs
tests/ERP.Application.Tests/{Module}/{EntityName}/{HandlerName}Tests.cs
```

- كل invariant يجب أن يكون له اختبار (R-TST-01).
- كل Handler يجب أن يكون له اختبار (R-TST-02).

### 6. التوثيق (Documentation)

```
docs/modules/{EntityName}.md
```

- كل تغيير في `src/` يجب أن يرافقه تحديث في `docs/` (R-DOC-04).

## 📏 معايير الكود — Code Standards

### تسمية C# — Naming Conventions

| العنصر | النمط | مثال |
| --- | --- | --- |
| Classes / Records | PascalCase | `ChartOfAccounts`, `PostJournalCommand` |
| Interfaces | I + PascalCase | `IJournalRepository`, `IUnitOfWork` |
| Methods | PascalCase | `RegisterAccount()`, `HandleAsync()` |
| Private fields | _camelCase | `_repository`, `_unitOfWork` |
| Parameters | camelCase | `chartId`, `journalNumber` |
| Constants | PascalCase | `MaxLineCount` |

### مبادئ الكود النظيف — Clean Code Principles

- ✅ اتبع مبادئ **SOLID**
- ✅ استخدم **Dependency Injection** عبر الـ constructor
- ✅ أضف **XML comments** على الأعضاء العامة
- ✅ ارمِ **Domain Exceptions** واضحة عند انتهاك invariant
- ✅ اكتب **اختبارات وحدة** لكل قاعدة تجارية
- ❌ لا تستخدم **Service Locator** خارج Bootstrapper
- ❌ لا تضع **منطق أعمال** خارج طبقة Domain
- ❌ لا تعتمد على **بنية تحتية** في Domain أو Application

### نمط الاختبار — Test Pattern (AAA)

```csharp
[Fact]
public async Task HandleAsync_WhenCalled_ExpectedBehavior()
{
    // Arrange — تجهيز البيانات والاعتمادات
    var repository = new InMemoryRepository();
    var handler = new MyHandler(repository, unitOfWork);

    // Act — تنفيذ العملية
    await handler.HandleAsync(new MyCommand(...));

    // Assert — التحقق من النتيجة
    Assert.NotNull(result);
}
```

## 🔄 سير عمل التطوير — Development Workflow

```
1. أنشئ فرع:     git checkout -b feature/my-feature
2. نفّذ التغيير:   (اتبع الخطوات أعلاه)
3. افحص محلياً:   bash scripts/check-architecture.sh
4. شغّل الاختبارات: dotnet test
5. حدّث التوثيق:   (عدّل docs/ ثم شغّل scripts/generate-readme.sh)
6. ادفع وافتح PR:  git push origin feature/my-feature
```

> ⚠️ CI Gate سيرفض PR تلقائياً إذا خالف أي قاعدة معمارية.

_Last Updated: 2026-02-21_
