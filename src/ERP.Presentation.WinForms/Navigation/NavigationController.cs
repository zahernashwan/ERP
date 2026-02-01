using ERP.Presentation.WinForms.Accounting.ChartOfAccounts;
using ERP.Presentation.WinForms.Accounting.Journals;
using ERP.Presentation.WinForms.Accounting.Ledgers;
using ERP.Presentation.WinForms.Shell;
using Microsoft.Extensions.DependencyInjection;

namespace ERP.Presentation.WinForms.Navigation;

public sealed class NavigationController(IServiceProvider services) : INavigationController
{
    private readonly IServiceProvider _services = services;
    private IMainShell? _shell;

    public void Initialize(IMainShell shell)
    {
        ArgumentNullException.ThrowIfNull(shell);
        _shell = shell;

        var navigationMenu = new ToolStripMenuItem { Text = "التنقل" };

        var journalsItem = new ToolStripMenuItem { Text = "Journals" };
        journalsItem.Click += async (_, _) => await ShowJournalsAsync();

        var chartsItem = new ToolStripMenuItem { Text = "Chart of Accounts" };
        chartsItem.Click += (_, _) => ShowCharts();

        var ledgersItem = new ToolStripMenuItem { Text = "Ledgers" };
        ledgersItem.Click += (_, _) => ShowLedgers();

        navigationMenu.DropDownItems.Add(ledgersItem);
        navigationMenu.DropDownItems.Add(chartsItem);
        navigationMenu.DropDownItems.Add(journalsItem);

        _shell.MenuItems.Add(navigationMenu);
    }

    public void ShowJournals() => ShowJournalsAsync().GetAwaiter().GetResult();

    public void ShowLedgers() => ShowInShell<LedgersListForm>("Ledgers");

    public void ShowCharts() => ShowInShell<ChartsListForm>("Chart of Accounts");

    private async Task ShowJournalsAsync()
    {
        if (_shell is null)
            throw new InvalidOperationException("NavigationController.Initialize must be called before navigation.");

        using var scope = _services.CreateScope();
        var controller = scope.ServiceProvider.GetRequiredService<JournalsController>();

        await controller.RefreshAsync(CancellationToken.None);

        var view = controller.GetListView();

        _shell.ContentControls.Clear();

        view.TopLevel = false;
        view.FormBorderStyle = FormBorderStyle.None;
        view.Dock = DockStyle.Fill;

        _shell.ContentControls.Add(view);
        _shell.SetBreadcrumb("Journals");

        view.Show();
    }

    private void ShowInShell<TForm>(string breadcrumb)
        where TForm : Form
    {
        if (_shell is null)
            throw new InvalidOperationException("NavigationController.Initialize must be called before navigation.");

        using var scope = _services.CreateScope();
        var form = scope.ServiceProvider.GetRequiredService<TForm>();

        _shell.ContentControls.Clear();

        form.TopLevel = false;
        form.FormBorderStyle = FormBorderStyle.None;
        form.Dock = DockStyle.Fill;

        _shell.ContentControls.Add(form);
        _shell.SetBreadcrumb(breadcrumb);

        form.Show();
    }
}
