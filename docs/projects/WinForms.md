# طبقة العرض — WinForms (Presentation Layer)

> 📂 `docs/projects/` · [↑ خريطة التوثيق](../documentation-map.md)

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
│   ├── ChartOfAccounts/
│   │   ├── ChartsController.cs
│   │   ├── ChartsListForm.cs
│   │   └── ChartDetailsForm.cs
│   ├── Journals/
│   │   ├── JournalsController.cs
│   │   ├── JournalsListForm.cs
│   │   ├── JournalDetailsForm.cs
│   │   └── JournalForm.cs
│   └── Ledgers/
│       ├── LedgersController.cs
│       ├── LedgersListForm.cs
│       └── LedgerDetailsForm.cs
├── Navigation/
│   ├── INavigationController.cs
│   └── NavigationController.cs
├── Shell/
│   ├── IMainShell.cs
│   └── MainForm.cs
├── Program.cs
└── AssemblyMarker.cs
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

_Last Updated: 2026-02-10_
