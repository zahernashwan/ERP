# ERP.Domain.Accounting — Accounting Domain (Aggregates + Invariants)

هذا المجلد يحتوي على نموذج الدومين الخاص بالمحاسبة داخل مشروع `ERP.Domain`.

> هذا الكود **Domain فقط**:
> - يعرّف **الحقيقة** (State + Invariants + Domain Events)
> - ولا يشغّل الحقيقة (لا Use Cases، لا Repositories، لا EF Core، لا UI)

---

## 1) ماذا يوجد هنا؟

المجلد `ERP.Domain/Accounting` يحتوي على:

```plaintext
src/ERP.Domain/Accounting
├─ Aggregates/    # Aggregates + Entities (مثل ChartOfAccounts و Account)
├─ ValueObjects/  # Value Objects (مثل AccountNumber, Money, ...)
├─ Events/        # Domain Events
└─ Exceptions/    # Domain Exceptions (invariants)
```

---

## 2) الهيكل الفعلي الحالي (كما هو موجود في المستودع)

```plaintext
src/ERP.Domain/Accounting
├─ Aggregates
│  ├─ Accounts
│  │  └─ Account.cs
│  └─ ChartOfAccounts
│     └─ ChartOfAccounts.cs
│
├─ Events
│  ├─ ChartOpened.cs
│  ├─ AccountRegistered.cs
│  └─ AccountDeactivated.cs
│
├─ Exceptions
│  ├─ DomainException.cs
│  ├─ ChartClosedException.cs
│  ├─ DuplicateAccountNumberException.cs
│  ├─ AccountNotFoundException.cs
│  └─ InvalidAccountException.cs
│
└─ ValueObjects
   ├─ Money.cs
   ├─ Currency.cs
   ├─ AccountingPeriod.cs
   ├─ AccountId.cs
   ├─ ChartOfAccountsId.cs
   ├─ ProjectId.cs
   ├─ AccountNumber.cs
   ├─ AccountName.cs
   └─ ChartName.cs
```

---

## 3) Concepts & Boundaries

### Aggregate Root
الـ **Aggregate Root** هو نقطة الدخول الوحيدة لتغيير حالة التجمع. أي تعديل على الكيانات الداخلية يجب أن يمر عبره.

### Entity
كيان له هوية (مثل `AccountId`).

### Value Object
قيمة بدون هوية، مساواتها تعتمد على القيمة (مثل `AccountNumber`, `Money`).

### Domain Event
حدث يصف شيئًا ذا معنى في الأعمال، يتم إطلاقه عند تغير مهم في الحالة.

### Domain Exception
استثناء يدل على كسر invariant (قانون غير قابل للكسر) داخل الدومين.

---

## 4) Aggregates & Invariants (ما الذي يحميه الدومين؟)

### 4.1) `ChartOfAccounts` (Aggregate Root)
الملف: `Aggregates/ChartOfAccounts/ChartOfAccounts.cs`

**الحالة (State):**
- `Name` (`ChartName`)
- `Status` (`ChartStatus`: `Open` / `Closed`)
- قائمة الحسابات `Accounts`
- قائمة أحداث الدومين `DomainEvents`

**السلوك (Behavior):**
- `Open(id, name)`
- `RegisterAccount(number, name, type)`
- `RenameAccount(accountId, name)`
- `ChangeAccountNumber(accountId, number)`
- `DeactivateAccount(accountId)`
- `ActivateAccount(accountId)`
- `Rename(name)`
- `Close()`

**Invariants المطبقة فعليًا داخل الكود:**
- لا يسمح بأي تعديل إذا كان `Status != Open`.
- رقم الحساب يجب أن يكون **Unique** داخل نفس الدليل (`DuplicateAccountNumberException`).
- لا يمكن تعديل/تعطيل حساب غير موجود داخل الدليل (`AccountNotFoundException`).

**Domain Events المضافة فعليًا:**
- عند فتح الدليل: `ChartOpened`
- عند تسجيل حساب: `AccountRegistered`
- عند تعطيل حساب: `AccountDeactivated`

### 4.2) `Account` (Entity داخل Aggregate)
الملف: `Aggregates/Accounts/Account.cs`

> ملاحظة: الكلاس `Account` يتم إنشاؤه وتعديله عبر `ChartOfAccounts` فقط، لأن `Create/Rename/ChangeNumber/...` معرفة كـ `internal`.

**الحالة:**
- `Number` (`AccountNumber`)
- `Name` (`AccountName`)
- `Type` (`AccountType`)
- `IsActive`

**Life-cycle:**
- `Activate()` / `Deactivate()`

---

## 5) Value Objects (تفصيل الموجود فعليًا)

### Identifiers
- `AccountId`: GUID non-empty
- `ChartOfAccountsId`: GUID non-empty
- `ProjectId`: GUID non-empty

### Business Values
- `AccountNumber`: string trimmed + non-empty
- `AccountName`: string trimmed + non-empty
- `ChartName`: string trimmed + non-empty

### Money & Currency
- `Currency.FromCode(code)`: كود 3 أحرف (ISO-like) بعد trim + upper
- `Money(amount, currency)`:
  - `amount` يجب أن يكون `>= 0`
  - يمنع الجمع/الطرح لعملتين مختلفتين (throws `InvalidOperationException`)

### AccountingPeriod
- `AccountingPeriod.Create(start, end)`:
  - `start` و `end` يجب ألا تكون default
  - `end` لا يمكن أن يكون قبل `start`
- `Contains(date)` للتحقق أن التاريخ داخل الفترة

---

## 6) Domain Events

المجلد: `Events/*`

- `ChartOpened(ChartOfAccountsId ChartId)`
- `AccountRegistered(AccountId AccountId, AccountNumber Number)`
- `AccountDeactivated(AccountId AccountId)`

---

## 7) Domain Exceptions

المجلد: `Exceptions/*`

- `DomainException`: الأساس لكل Exceptions الدومين داخل Accounting
- `ChartClosedException`: محاولة تعديل دليل مغلق
- `DuplicateAccountNumberException`: تكرار رقم حساب داخل نفس الدليل
- `AccountNotFoundException`: الحساب غير موجود داخل الدليل
- `InvalidAccountException`: أخطاء تحقق مرتبطة بالحساب (حسب الاستخدام)

---

## 8) قواعد مهمة عند التوسعة

- أي قاعدة أعمال جديدة تخص الدليل/الحساب يجب أن توضع داخل `ChartOfAccounts` أو Value Objects، وليس في Application.
- إذا احتجت تحقق يعتمد على بيانات خارج الـ Aggregate (مثال: uniqueness عبر قاعدة بيانات)، فمكانه يكون **Policy Interface** في الدومين ويتم تمريره من Application.
- إذا أضفت Domain Events جديدة، اجعلها تصف حدث أعمال بمعنى واضح، وليس تفاصيل تقنية.

---

## 9) Tests

سلوك الدومين يتم اختباره في: `tests/ERP.Domain.Tests`.
