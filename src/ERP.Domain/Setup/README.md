# ERP.Domain.Setup

هذا المجلد مخصص **فقط** لموديلات التهيئة (Setup/Configuration) على مستوى الدومين.

## الهدف
- `ERP.Domain` يحتوي على **قواعد الأعمال الأساسية** (Business Rules) والقيود غير القابلة للكسر (Invariants).
- `Setup` لا يحتوي أي تنفيذ تشغيلي (لا Use-Cases، لا Repositories، لا UI، لا Infrastructure).
- الهدف من `Setup` هو بناء **سياسات + قيود** تحكم النظام لاحقًا.

## قرار التسمية (نهائي)

لتجنّب أي تداخل مستقبلي، نعتمد تسمية تعتمد على **المعنى الدوميني** وليس “اسم الشاشة”.

داخل `ERP.Domain.Setup` نستخدم أسماء ثابتة تعكس:
- `Policy` / `Rule` عندما يكون الكيان عبارة عن سياسة تحكم السلوك
- `Entity` عندما يوجد هوية (Identity)
- `ValueObject` عندما لا يوجد هوية

ولا نستخدم مصطلحات تشغيلية أو UI مثل: `Setup`, `Add`, `Manage`, `Screen`, `Form`.

## الهيكل التفصيلي الحالي (الموجود فعليًا في المستودع)

```
src/ERP.Domain/Setup
├─ README.md
├─ SetupNamespace.cs
│
├─ System
│  ├─ SystemNamespace.cs
│  ├─ GeneralSettings
│  │  └─ GeneralSettingsNamespace.cs
│  ├─ FiscalPeriods
│  │  ├─ FiscalPeriodsNamespace.cs
│  │  └─ FiscalPeriod
│  │     └─ FiscalPeriodNamespace.cs
│  ├─ Currencies
│  │  ├─ CurrenciesNamespace.cs
│  │  └─ Currency
│  │     └─ CurrencyNamespace.cs
│  ├─ InventoryExpiryPolicy
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
│  │  └─ CompanyNamespace.cs
│  ├─ Branch
│  │  └─ BranchNamespace.cs
│  ├─ ChartOfAccounts
│  │  ├─ ChartOfAccountsNamespace.cs
│  │  └─ Account
│  │     └─ AccountNamespace.cs
│  └─ CostCenters
│     ├─ CostCentersNamespace.cs
│     └─ CostCenter
│        └─ CostCenterNamespace.cs
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
│  ├─ UnitOfMeasure
│  │  └─ UnitOfMeasureNamespace.cs
│  ├─ PricingPolicy
│  │  └─ PricingPolicyNamespace.cs
│  ├─ SupplyType
│  │  └─ SupplyTypeNamespace.cs
│  ├─ IssueType
│  │  └─ IssueTypeNamespace.cs
│  └─ TransferType
│     └─ TransferTypeNamespace.cs
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

> ملاحظة: الملفات `*Namespace.cs` هي placeholder لتثبيت الـ namespaces والمجلدات (بدون أي تنفيذ تشغيلي).

eters | `CustomerPolicy` |

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
