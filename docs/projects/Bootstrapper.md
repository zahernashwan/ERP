# نقطة التشغيل (Bootstrapper — Composition Root)

## الوصف العام

مشروع `ERP.Bootstrapper` هو نقطة التشغيل والـ Composition Root للتطبيق. يقوم بتهيئة حاوية الحقن (DI Container) وتسجيل جميع الطبقات ثم تشغيل واجهة WinForms.

## المسار

```
src/ERP.Bootstrapper/
```

## البنية الداخلية

```
ERP.Bootstrapper/
├── Program.cs
└── ContainerConfiguration.cs
```

## المسؤوليات

- تهيئة `IServiceCollection` وتسجيل جميع الطبقات:
  - طبقة التطبيق (`AddApplication`)
  - طبقة البنية التحتية (`AddInfrastructure`)
  - طبقة العرض (WinForms Forms + Controllers)
- إنشاء DI scope للتطبيق.
- استدعاء وتشغيل `MainForm`.

## الحدود الصارمة

- لا منطق أعمال، لا قواعد نطاق.
- يقتصر على التهيئة والتسجيل والتشغيل فقط.
- لا يُنشئ كائنات UI يدوياً — يتم تسجيلها عبر مشروع Presentation.

## الملفات الرئيسية

| الملف | الوصف |
| --- | --- |
| `Program.cs` | نقطة البداية — يبدأ التطبيق ويشغّل `MainForm` من DI |
| `ContainerConfiguration.cs` | التسجيل المركزي لجميع الطبقات في DI Container |

## التشغيل

```bash
dotnet run --project src/ERP.Bootstrapper
```

## الاعتماديات

- `ERP.Application` — تسجيل حالات الاستخدام.
- `ERP.Infrastructure` — تسجيل التنفيذات التقنية.
- `ERP.Presentation.WinForms` — تسجيل الواجهات والـ Controllers.

_Last Updated: 2026-02-10_
