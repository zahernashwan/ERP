# دفتر الأستاذ (Ledger)

## الوصف العام

دفتر الأستاذ هو الحاوية الزمنية للقيود اليومية. يرتبط بفترة محاسبية محددة ويمكن إقفاله لمنع أي تعديلات إضافية.

## الموقع في الكود

```
src/ERP.Domain/Accounting/Aggregates/Ledgers/
src/ERP.Application/Accounting/Ledgers/
```

## الكيانات والـ Value Objects

| العنصر | النوع | الوصف |
| --- | --- | --- |
| `Ledger` | Aggregate Root | دفتر الأستاذ |
| `LedgerId` | Value Object | معرّف الدفتر |
| `AccountingPeriod` | Value Object | الفترة المحاسبية |

## القواعد (Invariants)

- لا يمكن تسجيل قيد في دفتر مُقفل (`LedgerClosedException`).
- القيد يجب أن يكون ضمن الفترة المحاسبية للدفتر (`JournalOutsidePeriodException`).
- لا يمكن تسجيل قيد مكرر (`DuplicateJournalRegistrationException`).

## أحداث النطاق (Domain Events)

| الحدث | الوصف |
| --- | --- |
| `LedgerClosed` | يُصدر عند إقفال الدفتر |

## حالات الاستخدام

| الأمر / الاستعلام | النوع | الوصف |
| --- | --- | --- |
| `OpenLedger` | Command | فتح دفتر أستاذ جديد |
| `RegisterJournal` | Command | تسجيل قيد في الدفتر |
| `CloseLedger` | Command | إقفال الدفتر |
| `GetLedgerById` | Query | استعلام عن دفتر بمعرّفه |
| `ListLedgers` | Query | عرض قائمة الدفاتر |

## الاعتماديات

- يحتوي على مراجع للقيود اليومية (`Journal`).
- يعتمد على `AccountingPeriod` لتحديد صلاحية التسجيل.

_Last Updated: 2026-02-10_
