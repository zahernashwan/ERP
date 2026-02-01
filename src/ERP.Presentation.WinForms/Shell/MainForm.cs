using System.Globalization;
using System.Windows.Forms;
using ERP.Presentation.WinForms.Shell;

namespace ERP.Presentation.WinForms;

public sealed partial class MainForm : Form, IMainShell
{
    internal MainForm()
    {
        InitializeComponent();

        Text = "ERP";
        StartPosition = FormStartPosition.CenterScreen;

        InitializeStatusStrip();
    }

    public ToolStripItemCollection MenuItems => menuStrip.Items;

    public Control.ControlCollection ContentControls => contentPanel.Controls;

    public void SetBreadcrumb(string text)
    {
        breadcrumbLabel.Text = text;
    }

    private void InitializeStatusStrip()
    {
        toolStripStatusLabelDate.Text = DateTimeOffset.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
    }

    private void ContentPanel_Paint(object sender, PaintEventArgs e)
    {

    }
}
