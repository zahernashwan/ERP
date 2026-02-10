# القيود اليومية (Journal)

## الوصف العام

القيد اليومي هو الوحدة الأساسية للتسجيل المحاسبي. كل قيد يحتوي سطورًا مدينة ودائنة يجب أن تتوازن. يُدار ضمن دفتر أستاذ (`Ledger`) ويمر بمراحل: إنشاء ← إضافة سطور ← ترحيل.

## الموقع في الكود

```
src/ERP.Domain/Accounting/Aggregates/Journals/
src/ERP.Application/Accounting/Journals/
```

## الكيانات والـ Value Objects

| العنصر | النوع | الوصف |
| --- | --- | --- |
| `Journal` | Aggregate Root | القيد اليومي |
| `JournalLine` | Entity | سطر القيد (مدين أو دائن) |
| `JournalId` | Value Object | معرّف القيد |
| `JournalNumber` | Value Object | رقم القيد التسلسلي |
| `Money` | Value Object | المبلغ المالي |
| `Currency` | Value Object | العملة |

## القواعد (Invariants)

- مجموع المدين = مجموع الدائن (invariant أساسي).
- القيد يحتوي سطرًا واحدًا على الأقل.
- بعد الترحيل لا يمكن التعديل.
- لا يمكن ترحيل قيد غير متوازن.

## أحداث النطاق (Domain Events)

| الحدث | الوصف |
| --- | --- |
| `JournalPosted` | يُصدر عند ترحيل القيد |

## حالات الاستخدام

| الأمر / الاستعلام | النوع | الوصف |
| --- | --- | --- |
| `StartJournal` | Command | بدء قيد يومية جديد |
| `AddJournalLine` | Command | إضافة سطر مدين أو دائن |
| `PostJournal` | Command | ترحيل القيد |
| `GetJournalById` | Query | استعلام عن قيد بمعرّفه |
| `ListJournals` | Query | عرض قائمة القيود |

## الاعتماديات

- يُسجَّل في دفتر الأستاذ (`Ledger`) عبر `RegisterJournal`.
- يستخدم `AccountId` لربط السطور بالحسابات.

_Last Updated: 2026-02-10_
