# Integrations (التكاملات الخارجية)

## المبدأ

أي تكامل مع أنظمة خارجية (APIs, Message Brokers, File Systems) يُنفَّذ في طبقة Infrastructure.

## الموقع في الكود

```
src/ERP.Infrastructure/
```

## القواعد

- كل تكامل يطبّق واجهة معرّفة في Application.
- لا يعتمد على طبقة Presentation.
- يُسجَّل في DI Container عبر `InfrastructureModule`.

_Last Updated: 2026-02-10_
