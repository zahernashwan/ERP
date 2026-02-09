# Invariants (القيود الجوهرية)

## المبدأ

الـ Invariants هي القواعد التي يجب أن تكون صحيحة **دائماً** داخل حدود الـ Aggregate. أي عملية تكسر invariant يجب أن تُرفض فوراً.

## الموقع في الكود

```
src/ERP.Domain/
```

## القواعد

- يتم فرض الـ invariants داخل الـ Aggregate Root (في constructor أو methods).
- عند الانتهاك يُرمى Exception واضح.
- الاختبارات في `tests/ERP.Domain.Tests` تتحقق من كل invariant.
