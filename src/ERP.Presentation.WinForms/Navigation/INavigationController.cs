namespace ERP.Presentation.WinForms.Navigation;

public interface INavigationController
{
    void Initialize(ERP.Presentation.WinForms.Shell.IMainShell shell);
    void ShowJournals();
    void ShowLedgers();
    void ShowCharts();
}
