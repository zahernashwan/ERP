namespace ERP.Presentation.WinForms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        _menuStrip = new MenuStrip();
        _tsmAccounting = new ToolStripMenuItem();
        _tsmJournals = new ToolStripMenuItem();

        _menuStrip.SuspendLayout();
        SuspendLayout();

        // 
        // _menuStrip
        // 
        _menuStrip.Items.AddRange(new ToolStripItem[] { _tsmAccounting });
        _menuStrip.Location = new Point(0, 0);
        _menuStrip.Name = "_menuStrip";
        _menuStrip.Size = new Size(800, 24);
        _menuStrip.TabIndex = 0;
        _menuStrip.Text = "menuStrip1";

        // 
        // _tsmAccounting
        // 
        _tsmAccounting.DropDownItems.AddRange(new ToolStripItem[] { _tsmJournals });
        _tsmAccounting.Name = "_tsmAccounting";
        _tsmAccounting.Size = new Size(81, 20);
        _tsmAccounting.Text = "Accounting";

        // 
        // _tsmJournals
        // 
        _tsmJournals.Name = "_tsmJournals";
        _tsmJournals.Size = new Size(180, 22);
        _tsmJournals.Text = "Journals";

        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(_menuStrip);
        MainMenuStrip = _menuStrip;
        Name = "MainForm";
        Text = "ERP";
        _menuStrip.ResumeLayout(false);
        _menuStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private MenuStrip _menuStrip;
    private ToolStripMenuItem _tsmAccounting;
    private ToolStripMenuItem _tsmJournals;
}
