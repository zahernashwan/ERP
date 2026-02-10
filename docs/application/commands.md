# Commands

## المبدأ

الـ Command يمثّل **نية لتغيير الحالة**. كل Command يقابله Handler واحد ينسّق العملية.

## الموقع في الكود

```
src/ERP.Application/
```

## القواعد

- Command = كائن بيانات (DTO) يصف العملية المطلوبة.
- Handler يستدعي الـ Domain ثم يحفظ عبر Repository.
- لا يُرجع بيانات (أو يرجع ID فقط عند الضرورة).

_Last Updated: 2026-02-10_
