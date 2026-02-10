# الحسابات (Account)

## الوصف العام

وحدة الحسابات تُمثل الحسابات المالية الفردية داخل الدليل المحاسبي. كل حساب يحمل رقمًا فريدًا ومستوى في الشجرة المحاسبية، ويُستخدم لتسجيل الحركات المالية (مدين/دائن).

## الموقع في الكود

```
src/ERP.Domain/Accounting/Aggregates/Accounts/
src/ERP.Application/Accounting/ChartOfAccounts/
```

## الكيانات والـ Value Objects

| العنصر | النوع | الوصف |
| --- | --- | --- |
| `Account` | Entity | الحساب المالي داخل الدليل المحاسبي |
| `AccountId` | Value Object | معرّف الحساب |
| `AccountNumber` | Value Object | رقم الحساب الفريد |
| `AccountName` | Value Object | اسم الحساب |

## القواعد (Invariants)

- كل حساب له رقم فريد (`AccountNumber`) داخل الدليل المحاسبي.
- الحسابات الأبوية لا تقبل قيودًا مباشرة.
- لا يمكن تعطيل حساب له أرصدة نشطة.

## أحداث النطاق (Domain Events)

| الحدث | الوصف |
| --- | --- |
| `AccountRegistered` | يُصدر عند تسجيل حساب جديد في الدليل |
| `AccountDeactivated` | يُصدر عند تعطيل حساب |

## حالات الاستخدام

| الأمر / الاستعلام | النوع | الوصف |
| --- | --- | --- |
| `RegisterAccount` | Command | تسجيل حساب جديد في الدليل المحاسبي |

## الاعتماديات

- ينتمي إلى Aggregate الدليل المحاسبي (`ChartOfAccounts`).
- يُستخدم في سطور القيود اليومية (`JournalLine`).
