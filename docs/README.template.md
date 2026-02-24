# README Template

> ⚠️ هذا الملف قالب فقط — لا يُعرض مباشرة.
> README.md يُولَّد تلقائياً بواسطة `scripts/generate-readme.sh`.

## البنية

يتم تجميع README.md تلقائياً من جميع ملفات `/docs/**/*.md` بالترتيب التالي:

1. `docs/overview.md` — رؤية عامة
2. `docs/architecture.md` — البنية المعمارية
3. `docs/ARCHITECTURE_RULES.md` — القواعد المعمارية الحاكمة
4. `docs/development-guide.md` — دليل التطوير
5. `docs/critical-recommendations.md` — توصيات حرجة
6. `docs/documentation-map.md` — خريطة التوثيق
7. `docs/projects/*.md` — توثيق المشاريع
8. `docs/modules/*.md` — توثيق الوحدات
9. `docs/domain/*.md` — مفاهيم طبقة النطاق
10. `docs/application/*.md` — مفاهيم طبقة التطبيق
11. `docs/infrastructure/*.md` — مفاهيم البنية التحتية

## قواعد التوثيق

- كل ملف `.md` يجب أن يبدأ بعنوان `# Title`.
- لا يُسمح بتعديل `README.md` يدوياً.
- أي تغيير في التوثيق يتم عبر ملفات `/docs` ثم تشغيل السكربت.

_Last Updated: 2026-02-10_
