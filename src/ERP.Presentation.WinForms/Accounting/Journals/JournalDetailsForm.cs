using ERP.Application.Accounting.Journals.GetJournalById;

namespace ERP.Presentation.WinForms.Accounting.Journals
{
    public partial class JournalDetailsForm : Form
    {
        public JournalDetailsForm()
        {
            InitializeComponent();

            linesGrid.AutoGenerateColumns = false;
            linesGrid.Columns.Clear();

            linesGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(JournalLineDto.AccountId),
                HeaderText = "الحساب",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            });

            linesGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(JournalLineDto.Debit),
                HeaderText = "مدين",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            });

            linesGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(JournalLineDto.Credit),
                HeaderText = "دائن",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            });

            linesGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(JournalLineDto.Currency),
                HeaderText = "العملة",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            });

            linesGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(JournalLineDto.Description),
                HeaderText = "البيان",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            });

            linesGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(JournalLineDto.ProjectId),
                HeaderText = "المشروع",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            });
        }

        public void Bind(JournalDetailsDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto);

            numberValueLabel.Text = dto.Number;
            dateValueLabel.Text = dto.AccountingDate.ToString("yyyy-MM-dd");
            statusValueLabel.Text = dto.Status;
            referenceValueLabel.Text = string.IsNullOrWhiteSpace(dto.Reference) ? "-" : dto.Reference;
            postedAtValueLabel.Text = dto.PostedAt is null ? "-" : dto.PostedAt.Value.ToString("yyyy-MM-dd HH:mm");

            linesGrid.DataSource = new BindingSource { DataSource = dto.Lines.ToList() };
        }
    }
}
