using ERP.Application.Accounting.Journals.ListJournals;

namespace ERP.Presentation.WinForms.Accounting.Journals;

public partial class JournalsListForm : Form
{
    private Action? _refresh;
    private Action<string>? _openDetails;

    public JournalsListForm()
    {
        InitializeComponent();

        journalsGrid.AutoGenerateColumns = false;
        journalsGrid.Columns.Clear();

        journalsGrid.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(JournalListItemDto.Number),
            HeaderText = "الرقم",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
        });

        journalsGrid.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(JournalListItemDto.AccountingDate),
            HeaderText = "التاريخ",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
        });

        journalsGrid.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(JournalListItemDto.Status),
            HeaderText = "الحالة",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
        });
    }

    public void ConfigureCallbacks(Action refresh, Action<string> openDetails)
    {
        ArgumentNullException.ThrowIfNull(refresh);
        ArgumentNullException.ThrowIfNull(openDetails);

        _refresh = refresh;
        _openDetails = openDetails;
    }

    public void Bind(IReadOnlyList<JournalListItemDto> journals)
    {
        ArgumentNullException.ThrowIfNull(journals);

        journalsGrid.DataSource = new BindingSource { DataSource = journals.ToList() };
    }

    // Referenced by `JournalsListForm.Designer.cs`
    private void RefreshToolStripButton_Click(object? sender, EventArgs e) => _refresh?.Invoke();

    // Referenced by `JournalsListForm.Designer.cs`
    private void JournalsGrid_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
            return;

        if (journalsGrid.Rows[e.RowIndex].DataBoundItem is not JournalListItemDto item)
            return;

        _openDetails?.Invoke(item.Id);
    }
}
