# Aggregates

## المبدأ

الـ Aggregate هو حدود الاتساق (Consistency Boundary) في نموذج الأعمال. كل Aggregate يحمي قواعده الداخلية (invariants) ولا يُعدَّل إلا عبر جذره (Aggregate Root).

## الموقع في الكود

```
src/ERP.Domain/
```

## القواعد

- كل Aggregate Root يرث من `Entity` أو يطبّق هوية فريدة.
- التعديل يتم فقط عبر methods على الـ Root.
- لا يُسمح بالوصول المباشر للكيانات الداخلية من خارج الـ Aggregate.
