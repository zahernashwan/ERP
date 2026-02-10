# الدليل المحاسبي (Chart of Accounts)

## الوصف العام

الدليل المحاسبي هو الهيكل الشجري للحسابات الذي يُنظّم جميع العمليات المالية. يمكن فتحه وتسجيل حسابات فيه، ولا يمكن تعديله بعد الإغلاق.

## الموقع في الكود

```
src/ERP.Domain/Accounting/Aggregates/ChartOfAccounts/
src/ERP.Application/Accounting/ChartOfAccounts/
```

## الكيانات والـ Value Objects

| العنصر | النوع | الوصف |
| --- | --- | --- |
| `ChartOfAccounts` | Aggregate Root | الدليل المحاسبي |
| `Account` | Entity | الحساب داخل الدليل |
| `ChartOfAccountsId` | Value Object | معرّف الدليل |
| `ChartName` | Value Object | اسم الدليل |

## القواعد (Invariants)

- لا يمكن تسجيل حساب برقم مكرر (`DuplicateAccountNumberException`).
- لا يمكن تعديل دليل مُغلق (`ChartClosedException`).
- كل حساب له رقم فريد ومستوى في الشجرة.

## أحداث النطاق (Domain Events)

| الحدث | الوصف |
| --- | --- |
| `ChartOpened` | يُصدر عند فتح دليل محاسبي جديد |
| `AccountRegistered` | يُصدر عند تسجيل حساب في الدليل |

## حالات الاستخدام

| الأمر / الاستعلام | النوع | الوصف |
| --- | --- | --- |
| `OpenChart` | Command | فتح دليل محاسبي جديد |
| `RegisterAccount` | Command | تسجيل حساب في الدليل |
| `GetChartById` | Query | استعلام عن دليل بمعرّفه |
| `ListCharts` | Query | عرض قائمة الأدلة المحاسبية |

## الاعتماديات

- يحتوي على كيانات `Account`.
- يُستخدم كمرجع لسطور القيود اليومية.
