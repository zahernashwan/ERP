# README Template

> ⚠️ هذا الملف قالب فقط — لا يُعرض مباشرة.
> README.md يُولَّد تلقائياً بواسطة `scripts/generate-readme.sh`.

## البنية

يتم تجميع README.md تلقائياً من جميع ملفات `/docs/**/*.md` بالترتيب التالي:

1. `docs/overview.md` — رؤية عامة
2. `docs/architecture.md` — البنية المعمارية
3. `docs/projects/*.md` — توثيق المشاريع
4. `docs/modules/*.md` — توثيق الموديلات
5. `docs/domain/*.md` — طبقة النطاق
6. `docs/application/*.md` — طبقة التطبيق
7. `docs/infrastructure/*.md` — طبقة البنية التحتية

## قواعد التوثيق

- كل ملف `.md` يجب أن يبدأ بعنوان `# Title`.
- لا يُسمح بتعديل `README.md` يدوياً.
- أي تغيير في التوثيق يتم عبر ملفات `/docs` ثم تشغيل السكربت.

_Last Updated: 2026-02-10_
