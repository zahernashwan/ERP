# ERP.Application.Setup — Setup Use Cases (Application Facade)

`ERP.Application.Setup` يحتوي فقط على **Use Cases لتكوين السياسات الدومينية** (Create / Change / Lock / Validate)،
ويعمل كـ **طبقة تنسيق (Orchestration)** بين UI و `ERP.Domain.Setup` بدون أي منطق أعمال داخله.

---

## 1) دور ERP.Application.Setup (بدقة)

**ERP.Application.Setup = Application Facade فوق Domain Setup**

مسؤوليته:

* استقبال أوامر التهيئة من الواجهة
* تحميل Aggregate/Policy من الدومين
* استدعاء سلوك الدومين (State + Invariants)
* حفظ التغييرات
* نشر Domain Events (إن وجدت)

❌ لا Business Rules
❌ لا Invariants
❌ لا Validation أعمال
❌ لا EF logic

---

## 2) الهيكل النهائي لـ `ERP.Application.Setup`

> ملاحظة مهمة: هذا الهيكل مبني على ما هو موجود **فعليًا** داخل `ERP.Domain.Setup` حاليًا.
> أي Module غير موجود في `ERP.Domain.Setup` لا يجب أن يظهر هنا كمجلد/Use Cases.

### قواعد تنظيم (مهمة جدًا)

1) **نفس Boundaries الموجودة في الدومين**

كل مجلد في `ERP.Application.Setup` يجب أن يقابل مجلدًا/Bounded Context موجودًا في `ERP.Domain.Setup`.

2) **Entity vs ValueObject**

- إذا كان الموديل في الدومين `Entity<TId>`: غالبًا ستجد Use Cases من نوع (Create/Rename/ChangeCode/Deactivate/Activate).
- إذا كان الموديل `ValueObject`: عادةً سيكون عندك Use Case واحد مثل `Define*` أو `Set*` يقوم ببناء الـ ValueObject عبر `Create(...)` ثم حفظه في مخزن إعدادات/Policy.

3) **Policies داخل الدومين، Orchestration داخل التطبيق**

أي شرط أعمال أو قاعدة يجب أن تكون داخل الدومين. الـ Handler هنا لا يفعل سوى:
Load → Call Domain → Save → Publish Events.

```plaintext
ERP.Application
└─ Setup
   │
   ├─ System
   │  ├─ GeneralSettings
   │  │  └─ Commands
   │  │     ├─ Create
   │  │     │  ├─ CreateGeneralSettingsCommand.cs
   │  │     │  └─ CreateGeneralSettingsHandler.cs
   │  │     ├─ SetPostingPolicy
   │  │     │  ├─ SetPostingPolicyCommand.cs
   │  │     │  └─ SetPostingPolicyHandler.cs
   │  │     └─ ChangeBaseCurrency
   │  │        ├─ ChangeBaseCurrencyCommand.cs
   │  │        └─ ChangeBaseCurrencyHandler.cs
   │  ├─ FiscalPeriods
   │  │  └─ Commands
   │  │     ├─ Open
   │  │     │  ├─ OpenFiscalPeriodCommand.cs
   │  │     │  └─ OpenFiscalPeriodHandler.cs
   │  │     └─ Close
   │  │        ├─ CloseFiscalPeriodCommand.cs
   │  │        └─ CloseFiscalPeriodHandler.cs
   │  ├─ Currencies
   │  │  └─ Commands
   │  │     ├─ Register
   │  │     │  ├─ RegisterCurrencyCommand.cs
   │  │     │  └─ RegisterCurrencyHandler.cs
   │  │     ├─ Rename
   │  │     │  ├─ RenameCurrencyCommand.cs
   │  │     │  └─ RenameCurrencyHandler.cs
   │  │     ├─ Deactivate
   │  │     │  ├─ DeactivateCurrencyCommand.cs
   │  │     │  └─ DeactivateCurrencyHandler.cs
   │  │     └─ Activate
   │  │        ├─ ActivateCurrencyCommand.cs
   │  │        └─ ActivateCurrencyHandler.cs
   │  ├─ InventoryExpiryPolicy
   │  │  └─ Commands
   │  │     └─ DefineInventoryExpiryPolicy
   │  │        ├─ DefineInventoryExpiryPolicyCommand.cs
   │  │        └─ DefineInventoryExpiryPolicyHandler.cs
   │  ├─ Geography
   │  │  └─ Commands
   │  │     ├─ RegisterCountry
   │  │     ├─ RegisterGovernorate
   │  │     ├─ RegisterCity
   │  │     └─ RegisterArea
   │  ├─ Company
   │  │  └─ Commands
   │  │     ├─ Create
   │  │     ├─ Rename
   │  │     ├─ SetTaxRegistrationNumber
   │  │     ├─ Deactivate
   │  │     └─ Activate
   │  ├─ Branch
   │  │  └─ Commands
   │  │     ├─ Register
   │  │     ├─ Rename
   │  │     ├─ ChangeCode
   │  │     ├─ Deactivate
   │  │     └─ Activate
   │  ├─ ChartOfAccounts
   │  │  └─ Commands
   │  │     ├─ Create
   │  │     │  ├─ CreateChartOfAccountsCommand.cs
   │  │     │  └─ CreateChartOfAccountsHandler.cs
   │  │     ├─ Rename
   │  │     ├─ Deactivate
   │  │     └─ AddAccount
   │  └─ CostCenters
   │     └─ Commands
   │        ├─ Register
   │        ├─ Rename
   │        ├─ ChangeCode
   │        ├─ Deactivate
   │        └─ Activate
   │
   ├─ Accounting
   │  └─ GeneralLedgerPolicy
   │     └─ Commands
   │        └─ DefineGeneralLedgerPolicy
   │           ├─ DefineGeneralLedgerPolicyCommand.cs
   │           └─ DefineGeneralLedgerPolicyHandler.cs
   │
   ├─ Inventory
   │  ├─ InventoryPolicy
   │  │  └─ Commands
   │  │     └─ DefineInventoryPolicy
   │  ├─ PricingPolicy
   │  │  └─ Commands
   │  │     └─ DefinePricingPolicy
   │  ├─ UnitOfMeasure
   │  │  └─ Commands
   │  │     ├─ Register
   │  │     ├─ Rename
   │  │     ├─ ChangeCode
   │  │     ├─ Deactivate
   │  │     └─ Activate
   │  ├─ SupplyType
   │  │  └─ Commands
   │  │     ├─ Register
   │  │     ├─ Rename
   │  │     ├─ ChangeCode
   │  │     ├─ Deactivate
   │  │     └─ Activate
   │  ├─ IssueType
   │  │  └─ Commands
   │  │     ├─ Register
   │  │     ├─ Rename
   │  │     ├─ ChangeCode
   │  │     ├─ Deactivate
   │  │     └─ Activate
   │  └─ TransferType
   │     └─ Commands
   │        ├─ Register
   │        ├─ Rename
   │        ├─ ChangeCode
   │        ├─ Deactivate
   │        └─ Activate
   │
   ├─ Suppliers
   │  ├─ SupplierPolicy
   │  │  └─ Commands
   │  │     └─ DefineSupplierPolicy
   │  ├─ PurchasingPolicy
   │  │  └─ Commands
   │  │     └─ DefinePurchasingPolicy
   │  └─ CostingMethod
   │     └─ Commands
   │        └─ DefineCostingMethod
   │
   └─ Customers
      └─ CustomerPolicy
         └─ Commands
            └─ DefineCustomerPolicy

```

---

## 3) شكل الـ Use Case (Pattern ثابت)

### Command

* DTO فقط
* لا منطق
* لا Validation أعمال

```csharp
public sealed record SetPostingPolicyCommand(
    bool AllowBackdatedPosting,
    bool AllowFutureDatedPosting
);

```

---

### Handler (Orchestrator فقط)

```csharp
public sealed class SetPostingPolicyHandler
{
    private readonly IGeneralSettingsRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public async Task Handle(SetPostingPolicyCommand command, CancellationToken cancellationToken)
    {
        var settings = await _repository.GetAsync(cancellationToken);

        settings.SetPostingPolicy(
            allowBackdatedPosting: command.AllowBackdatedPosting,
            allowFutureDatedPosting: command.AllowFutureDatedPosting);

        await _repository.SaveAsync(settings, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

```

✔ لا شرط أعمال
✔ لا if تجاري
✔ كل القواعد داخل `settings.SetPostingPolicy(...)`

---

## 4) Use Cases الأساسية (Checklist)

```plaintext
ERP.Application.Setup
├─ System
│  ├─ GeneralSettings        # Create / SetPostingPolicy / ChangeBaseCurrency
│  ├─ FiscalPeriods          # Open / Close
│  ├─ Currencies             # Register / Rename / Deactivate / Activate
│  ├─ Geography              # RegisterCountry / RegisterGovernorate / RegisterCity / RegisterArea
│  ├─ Company                # Create / Rename / SetTaxRegistrationNumber / Deactivate / Activate
│  ├─ Branch                 # Register / Rename / ChangeCode / Deactivate / Activate
│  ├─ ChartOfAccounts        # Create / Rename / Deactivate / AddAccount
│  └─ CostCenters            # Register / Rename / ChangeCode / Deactivate / Activate
├─ Accounting
│  └─ GeneralLedgerPolicy    # DefineGeneralLedgerPolicy
├─ Inventory
│  ├─ InventoryPolicy        # DefineInventoryPolicy
│  ├─ PricingPolicy          # DefinePricingPolicy
│  ├─ InventoryExpiryPolicy  # DefineInventoryExpiryPolicy
│  ├─ UnitOfMeasure          # Register / Rename / ChangeCode / Deactivate / Activate
│  ├─ SupplyType             # Register / Rename / ChangeCode / Deactivate / Activate
│  ├─ IssueType              # Register / Rename / ChangeCode / Deactivate / Activate
│  └─ TransferType           # Register / Rename / ChangeCode / Deactivate / Activate
├─ Suppliers
│  ├─ SupplierPolicy         # DefineSupplierPolicy
│  ├─ PurchasingPolicy       # DefinePurchasingPolicy
│  └─ CostingMethod          # DefineCostingMethod
└─ Customers
   └─ CustomerPolicy         # DefineCustomerPolicy
```

---

## 5) أخطاء ممنوعة (Strict)

❌ Handler يحتوي قواعد
❌ Handler يتحقق من Business Validation
❌ Handler يعرف تفاصيل EF
❌ Handler يستدعي Service Locator
❌ Handler يخلق Entities مباشرة بدون Domain Factory

---

## 6) القاعدة الذهبية

> **Application = ترتيب الخطوات
> Domain = اتخاذ القرار**

إذا شعرت أن Handler أصبح “ذكي” → أنت في المكان الخطأ.

---

## 7) الخلاصة النهائية

✔ `ERP.Application.Setup` = طبقة Use Cases نظيفة
✔ كل Policy تُدار عبر Command واحد واضح
✔ الدومين يبقى محميًا
✔ UI يصبح بسيطًا

---

### الخطوة التالية المثالية:

* اختيار **Policy واحدة** (مثلاً `GeneralLedgerPolicy`)
* تصميم **Command + Handler + Domain Model** لها بالكامل
* أو رسم **Sequence Diagram: Screen → Command → Domain → Save**

قل لي أي Policy نبدأ بها.
