using ERP.Presentation.WinForms.Accounting.ChartOfAccounts;
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

        var chartsItem = new ToolStripMenuItem { Text = "Chart of Accounts" };
        chartsItem.Click += (_, _) => ShowCharts();

        navigationMenu.DropDownItems.Add(chartsItem);

        _shell.MenuItems.Add(navigationMenu);
    }

    public void ShowCharts() => ShowInShell<ChartsListForm>("Chart of Accounts");

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
