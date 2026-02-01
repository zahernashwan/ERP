namespace ERP.Presentation.WinForms.Shell;

public interface IMainShell
{
    ToolStripItemCollection MenuItems { get; }
    Control.ControlCollection ContentControls { get; }
    void SetBreadcrumb(string text);
}
