# ERP.Domain.Setup — تعريف الحقيقة (Setup Definitions: State + Policies + Invariants)

هذا المجلد مخصص **فقط** لموديلات التهيئة (Setup/Configuration) على مستوى الدومين.

> أهم نقطة تأكيد (مهمة جدًا)
>
> كل ما في `ERP.Domain.Setup` هو **تعريف الحقيقة** (State + Policies + Invariants)
> وليس **تشغيل الحقيقة** (Use Cases / Workflows / Persistence / UI).

## الهدف
```plaintext
ERP.Domain
└─ Setup
   ├─ defines: State + Policies + Invariants
   └─ excludes: Use Cases / Repositories / UI / Infrastructure
```

## قرار التسمية (نهائي)

لتجنّب أي تداخل مستقبلي، نعتمد تسمية تعتمد على **المعنى الدوميني** وليس “اسم الشاشة”.

داخل `ERP.Domain.Setup` نستخدم أسماء ثابتة تعكس:
- `Policy` / `Rule` عندما يكون الكيان عبارة عن سياسة تحكم السلوك
- `Entity` عندما يوجد هوية (Identity)
- `ValueObject` عندما لا يوجد هوية

ولا نستخدم مصطلحات تشغيلية أو UI مثل: `Setup`, `Add`, `Manage`, `Screen`, `Form`.

## الهيكل التفصيلي الحالي (الموجود فعليًا في المستودع)

> الهدف من الشجرة التالية هو عكس **الموجود فعليًا**. قد تحتوي بعض المجلدات على `*Namespace.cs` فقط كبنية/placeholder، بينما مجلدات أخرى تحتوي موديلات حقيقية + سياسات.

> ملاحظة مهمة: `System/Geography/*` حاليًا يحتوي على ملفات `*Namespace.cs` فقط (Placeholders) بدون موديلات دومين فعلية حتى الآن.

> ملاحظة مهمة: `Accounting/GeneralLedgerPolicy` حاليًا يحتوي على `GeneralLedgerPolicyNamespace.cs` فقط (Placeholder) بدون Policy فعلية.

> ملاحظة مهمة: `Inventory/InventoryPolicy` حاليًا يحتوي على `InventoryPolicyNamespace.cs` فقط (Placeholder) بدون Policy فعلية.

> ملاحظة مهمة: `Suppliers/*` و `Customers/CustomerPolicy` حاليًا تحتوي على ملفات `*Namespace.cs` فقط (Placeholders) بدون موديلات/Policies فعلية.

```
src/ERP.Domain/Setup
├─ README.md
├─ SetupNamespace.cs
├─ Exceptions
│  ├─ SetupDomainException.cs
│  ├─ InvalidAccountException.cs
│  ├─ InvalidBranchException.cs
│  ├─ InvalidChartOfAccountsException.cs
│  ├─ InvalidCompanyException.cs
│  ├─ InvalidCostCenterException.cs
│  ├─ InvalidCurrencyException.cs
│  ├─ InvalidFiscalPeriodException.cs
│  ├─ InvalidGeneralSettingsException.cs
│  ├─ InvalidInventoryExpiryPolicyException.cs
│  ├─ InvalidIssueTypeException.cs
│  ├─ InvalidPricingPolicyException.cs
│  ├─ InvalidSupplyTypeException.cs
│  ├─ InvalidTransferTypeException.cs
│  └─ InvalidUnitOfMeasureException.cs
│
├─ System
│  ├─ SystemNamespace.cs
│  ├─ GeneralSettings
│  │  ├─ GeneralSettings.cs
│  │  ├─ GeneralSettingsId.cs
│  │  └─ GeneralSettingsNamespace.cs
│  ├─ FiscalPeriods
│  │  ├─ FiscalPeriodsNamespace.cs
│  │  ├─ FiscalPeriod
│  │  │  ├─ FiscalPeriod.cs
│  │  │  ├─ FiscalPeriodId.cs
│  │  │  └─ FiscalPeriodNamespace.cs
│  │  └─ Policies
│  │     └─ FiscalPeriodOverlapPolicy.cs
│  ├─ Currencies
│  │  ├─ CurrenciesNamespace.cs
│  │  └─ Currency
│  │     ├─ Currency.cs
│  │     ├─ CurrencyId.cs
│  │     └─ CurrencyNamespace.cs
│  ├─ InventoryExpiryPolicy
│  │  ├─ InventoryExpiryPolicy.cs
│  │  └─ InventoryExpiryPolicyNamespace.cs
│  ├─ Geography
│  │  ├─ GeographyNamespace.cs
│  │  ├─ Country
│  │  │  └─ CountryNamespace.cs
│  │  ├─ Governorate
│  │  │  └─ GovernorateNamespace.cs
│  │  ├─ City
│  │  │  └─ CityNamespace.cs
│  │  └─ Area
│  │     └─ AreaNamespace.cs
│  ├─ Company
│  │  ├─ Company.cs
│  │  ├─ CompanyId.cs
│  │  ├─ CompanyName.cs
│  │  ├─ TaxRegistrationNumber.cs
│  │  ├─ CompanyNamespace.cs
│  │  └─ Policies
│  │     ├─ BranchCodeUniquenessPolicy.cs
│  │     └─ CompanyPolicy.cs
│  ├─ Branch
│  │  ├─ Branch.cs
│  │  ├─ BranchId.cs
│  │  ├─ BranchCode.cs
│  │  ├─ BranchName.cs
│  │  └─ BranchNamespace.cs
│  ├─ ChartOfAccounts
│  │  ├─ ChartOfAccounts.cs
│  │  ├─ ChartOfAccountsId.cs
│  │  ├─ ChartName.cs
│  │  ├─ ChartOfAccountsNamespace.cs
│  │  ├─ Account
│  │  │  ├─ Account.cs
│  │  │  ├─ AccountId.cs
│  │  │  ├─ AccountNumber.cs
│  │  │  ├─ AccountName.cs
│  │  │  ├─ AccountType.cs
│  │  │  └─ AccountNamespace.cs
│  │  └─ Policies
│  │     └─ AccountNumberUniquenessPolicy.cs
│  └─ CostCenters
│     ├─ CostCentersNamespace.cs
│     ├─ CostCenter
│     │  ├─ CostCenter.cs
│     │  ├─ CostCenterId.cs
│     │  ├─ CostCenterCode.cs
│     │  ├─ CostCenterName.cs
│     │  └─ CostCenterNamespace.cs
│     └─ Policies
│        └─ CostCenterCodeUniquenessPolicy.cs
│
├─ Accounting
│  ├─ AccountingNamespace.cs
│  └─ GeneralLedgerPolicy
│     └─ GeneralLedgerPolicyNamespace.cs
│
├─ Inventory
│  ├─ InventoryNamespace.cs
│  ├─ InventoryPolicy
│  │  └─ InventoryPolicyNamespace.cs
│  ├─ PricingPolicy
│  │  ├─ PricingPolicy.cs
│  │  └─ PricingPolicyNamespace.cs
│  ├─ UnitOfMeasure
│  │  ├─ UnitOfMeasure.cs
│  │  ├─ UnitOfMeasureId.cs
│  │  ├─ UnitOfMeasureCode.cs
│  │  ├─ UnitOfMeasureName.cs
│  │  └─ UnitOfMeasureNamespace.cs
│  ├─ SupplyType
│  │  ├─ SupplyType.cs
│  │  ├─ SupplyTypeId.cs
│  │  ├─ SupplyTypeCode.cs
│  │  ├─ SupplyTypeName.cs
│  │  └─ SupplyTypeNamespace.cs
│  ├─ IssueType
│  │  ├─ IssueType.cs
│  │  ├─ IssueTypeId.cs
│  │  ├─ IssueTypeCode.cs
│  │  ├─ IssueTypeName.cs
│  │  └─ IssueTypeNamespace.cs
│  ├─ TransferType
│  │  ├─ TransferType.cs
│  │  ├─ TransferTypeId.cs
│  │  ├─ TransferTypeCode.cs
│  │  ├─ TransferTypeName.cs
│  │  └─ TransferTypeNamespace.cs
│  └─ Policies
│     ├─ UnitOfMeasureCodeUniquenessPolicy.cs
│     ├─ SupplyTypeCodeUniquenessPolicy.cs
│     ├─ IssueTypeCodeUniquenessPolicy.cs
│     └─ TransferTypeCodeUniquenessPolicy.cs
│
├─ Suppliers
│  ├─ SuppliersNamespace.cs
│  ├─ SupplierPolicy
│  │  └─ SupplierPolicyNamespace.cs
│  ├─ PurchasingPolicy
│  │  └─ PurchasingPolicyNamespace.cs
│  └─ CostingMethod
│     └─ CostingMethodNamespace.cs
│
└─ Customers
   ├─ CustomersNamespace.cs
   └─ CustomerPolicy
      └─ CustomerPolicyNamespace.cs
```

> ملاحظة: بعض المجلدات (مثل `Accounting/GeneralLedgerPolicy` و `Suppliers/*` و `Customers/CustomerPolicy` و `Inventory/InventoryPolicy`) تحتوي حاليًا على placeholders فقط.
> بينما مجلدات أخرى (مثل `System/*` و `Inventory/*`) تحتوي على موديلات دومين فعلية (Entities/ValueObjects) وسياسات (`Policies`).

## Rules
- كل موديل هنا يجب أن يعبّر عن **حالة + قيود** (State + Invariants).
- أي سلوك يقوم بتنفيذ عمليات (Create/Update flows) مكانه في `ERP.Application` وليس هنا.

### قواعد تسمية نهائية
1. لا أفعال في الدومين
2. الاسم يعكس معنى أعمال
3. استخدم `Policy` عند وجود قواعد تحكم السلوك
4. استخدم `Entity` عند وجود هوية
5. استخدم `ValueObject` عند عدم وجود هوية
6. Folder يمثل Bounded Context مصغّر
7. لا تكرار أسماء بين Contexts
