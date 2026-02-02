using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP.Application.Accounting.Journals.GetJournalById;
using ERP.Application.Accounting.Journals.ListJournals;

namespace ERP.Presentation.WinForms.Accounting.Journals
{
    public sealed class JournalsController
    {
        private readonly ListJournalsHandler _listHandler;
        private readonly GetJournalByIdHandler _getByIdHandler;
        private readonly JournalsListForm _listForm;
        private readonly JournalDetailsForm _detailsForm;

        public JournalsController(
            ListJournalsHandler listHandler,
            GetJournalByIdHandler getByIdHandler,
            JournalsListForm listForm,
            JournalDetailsForm detailsForm)
        {
            ArgumentNullException.ThrowIfNull(listHandler);
            ArgumentNullException.ThrowIfNull(getByIdHandler);
            ArgumentNullException.ThrowIfNull(listForm);
            ArgumentNullException.ThrowIfNull(detailsForm);

            _listHandler = listHandler;
            _getByIdHandler = getByIdHandler;
            _listForm = listForm;
            _detailsForm = detailsForm;

            _listForm.ConfigureCallbacks(
                refresh: Refresh,
                openDetails: OpenDetails);
        }

        public Form GetListView() => _listForm;

        private async void Refresh()
        {
            try
            {
                await RefreshAsync(CancellationToken.None);
            }
            catch (OperationCanceledException)
            {
                // User-initiated cancellation; ignore.
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(_listForm, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void OpenDetails(string journalId)
        {
            try
            {
                await OpenDetailsAsync(journalId, CancellationToken.None);
            }
            catch (OperationCanceledException)
            {
                // User-initiated cancellation; ignore.
            }
            catch (FormatException ex)
            {
                MessageBox.Show(_listForm, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(_listForm, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(_listForm, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task RefreshAsync(CancellationToken cancellationToken)
        {
            var journals = await _listHandler.HandleAsync(new ListJournalsQuery(), cancellationToken);
            _listForm.Bind(journals);
        }

        public async Task OpenDetailsAsync(string journalId, CancellationToken cancellationToken)
        {
            var dto = await _getByIdHandler.HandleAsync(GetJournalByIdQuery.FromString(journalId), cancellationToken);
            _detailsForm.Bind(dto);

            _detailsForm.ShowDialog(_listForm);
        }
    }
}
