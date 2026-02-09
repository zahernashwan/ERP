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
