# Use Cases — حالات الاستخدام

> 📂 `docs/application/` · [↑ خريطة التوثيق](../documentation-map.md)

## الوصف العام

حالة الاستخدام تنسّق تدفق العمل بين الـ Domain والـ Infrastructure عبر واجهات محددة.

## الموقع في الكود

```
src/ERP.Application/
```

## الحالة الحالية

- يوجد MediatR مسجّل عبر `ApplicationModule.AddApplication(IServiceCollection)`.
- لكن الـ use-case handlers حاليًا **لا تطبّق** `IRequestHandler`؛ يتم استدعاء `HandleAsync(...)` مباشرة.

## القواعد

- كل Use Case يقابل Command أو Query واحد.
- Handler يستخدم `IUnitOfWork` لضمان حدود المعاملة.
- لا يحتوي منطق أعمال — يفوّضه للـ Domain.

## Failure Modes

- التحول الكامل إلى MediatR (إرسال Commands/Queries عبر `ISender`) غير منفّذ بعد.

_Last Updated: 2026-02-10_
