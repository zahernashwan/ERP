# Persistence (التخزين)

## المبدأ

طبقة البنية التحتية تنفّذ واجهات التخزين المعرّفة في Application. التنفيذ الحالي يستخدم In-Memory.

## الموقع في الكود

```
src/ERP.Infrastructure/
```

## القواعد

- Repository يطبّق واجهة من Application.
- لا يحتوي منطق أعمال.
- يمكن استبداله بتنفيذ آخر (EF Core, Dapper, etc.) بدون تأثير على الطبقات الأخرى.

_Last Updated: 2026-02-10_
