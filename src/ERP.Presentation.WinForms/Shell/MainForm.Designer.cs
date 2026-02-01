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
        components = new System.ComponentModel.Container();
        TreeNode treeNode1 = new TreeNode("تهيئة النظام");
        TreeNode treeNode2 = new TreeNode("تهيئة الحسابات");
        TreeNode treeNode3 = new TreeNode("التهيئة ", new TreeNode[] { treeNode1, treeNode2 });
        TreeNode treeNode4 = new TreeNode("مدخلات النظام");
        TreeNode treeNode5 = new TreeNode("مدخلات الحسابات");
        TreeNode treeNode6 = new TreeNode("المدخلات ", new TreeNode[] { treeNode4, treeNode5 });
        TreeNode treeNode7 = new TreeNode("عمليات الحسابات ");
        TreeNode treeNode8 = new TreeNode("العمليات", new TreeNode[] { treeNode7 });
        menuStrip = new MenuStrip();
        fileToolStripMenuItem = new ToolStripMenuItem();
        logoutToolStripMenuItem = new ToolStripMenuItem();
        viewToolStripMenuItem = new ToolStripMenuItem();
        breadcrumbLabel = new Label();
        navigationPanel = new Panel();
        navigationTree = new TreeView();
        navigationSearchTextBox = new TextBox();
        contentPanel = new Panel();
        statusStrip = new StatusStrip();
        toolStripStatusLabelUser = new ToolStripStatusLabel();
        toolStripStatusLabelBranch = new ToolStripStatusLabel();
        toolStripStatusLabelDate = new ToolStripStatusLabel();
        toolTip = new ToolTip(components);
        menuStrip.SuspendLayout();
        navigationPanel.SuspendLayout();
        statusStrip.SuspendLayout();
        SuspendLayout();
        // 
        // menuStrip
        // 
        menuStrip.ImageScalingSize = new Size(32, 32);
        menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, viewToolStripMenuItem });
        menuStrip.Location = new Point(0, 0);
        menuStrip.Name = "menuStrip";
        menuStrip.RightToLeft = RightToLeft.Yes;
        menuStrip.Size = new Size(1246, 40);
        menuStrip.TabIndex = 0;
        menuStrip.Text = "menuStrip";
        // 
        // fileToolStripMenuItem
        // 
        fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { logoutToolStripMenuItem });
        fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        fileToolStripMenuItem.Size = new Size(106, 36);
        fileToolStripMenuItem.Text = "البرنامج";
        // 
        // logoutToolStripMenuItem
        // 
        logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
        logoutToolStripMenuItem.Size = new Size(284, 44);
        logoutToolStripMenuItem.Text = "تسجيل الخروج";
        // 
        // viewToolStripMenuItem
        // 
        viewToolStripMenuItem.Name = "viewToolStripMenuItem";
        viewToolStripMenuItem.Size = new Size(88, 36);
        viewToolStripMenuItem.Text = "عرض";
        // 
        // breadcrumbLabel
        // 
        breadcrumbLabel.Location = new Point(0, 0);
        breadcrumbLabel.Name = "breadcrumbLabel";
        breadcrumbLabel.Size = new Size(100, 23);
        breadcrumbLabel.TabIndex = 0;
        // 
        // navigationPanel
        // 
        navigationPanel.Controls.Add(navigationTree);
        navigationPanel.Dock = DockStyle.Left;
        navigationPanel.Location = new Point(0, 0);
        navigationPanel.Name = "navigationPanel";
        navigationPanel.Padding = new Padding(6);
        navigationPanel.Size = new Size(240, 918);
        navigationPanel.TabIndex = 5;
        // 
        // navigationTree
        // 
        navigationTree.Dock = DockStyle.Fill;
        navigationTree.Location = new Point(6, 6);
        navigationTree.Name = "navigationTree";
        treeNode1.Name = "Node0";
        treeNode1.Text = "تهيئة النظام";
        treeNode2.Name = "Node1";
        treeNode2.Text = "تهيئة الحسابات";
        treeNode3.Name = "";
        treeNode3.Text = "التهيئة ";
        treeNode4.Name = "Node3";
        treeNode4.Text = "مدخلات النظام";
        treeNode5.Name = "Node5";
        treeNode5.Text = "مدخلات الحسابات";
        treeNode6.Name = "";
        treeNode6.Text = "المدخلات ";
        treeNode7.Name = "Node4";
        treeNode7.Text = "عمليات الحسابات ";
        treeNode8.Name = "Node2";
        treeNode8.Text = "العمليات";
        navigationTree.Nodes.AddRange(new TreeNode[] { treeNode3, treeNode6, treeNode8 });
        navigationTree.RightToLeftLayout = true;
        navigationTree.Size = new Size(228, 906);
        navigationTree.TabIndex = 1;
        // 
        // navigationSearchTextBox
        // 
        navigationSearchTextBox.Location = new Point(0, 0);
        navigationSearchTextBox.Name = "navigationSearchTextBox";
        navigationSearchTextBox.Size = new Size(100, 39);
        navigationSearchTextBox.TabIndex = 0;
        // 
        // contentPanel
        // 
        contentPanel.Dock = DockStyle.Fill;
        contentPanel.Location = new Point(240, 0);
        contentPanel.Name = "contentPanel";
        contentPanel.Size = new Size(1246, 918);
        contentPanel.TabIndex = 7;
        contentPanel.Paint += ContentPanel_Paint;
        // 
        // statusStrip
        // 
        statusStrip.ImageScalingSize = new Size(32, 32);
        statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelUser, toolStripStatusLabelBranch, toolStripStatusLabelDate });
        statusStrip.Location = new Point(0, 918);
        statusStrip.Name = "statusStrip";
        statusStrip.Size = new Size(1486, 42);
        statusStrip.TabIndex = 6;
        // 
        // toolStripStatusLabelUser
        // 
        toolStripStatusLabelUser.Name = "toolStripStatusLabelUser";
        toolStripStatusLabelUser.Size = new Size(132, 32);
        toolStripStatusLabelUser.Text = "المستخدم: -";
        // 
        // toolStripStatusLabelBranch
        // 
        toolStripStatusLabelBranch.Name = "toolStripStatusLabelBranch";
        toolStripStatusLabelBranch.Size = new Size(86, 32);
        toolStripStatusLabelBranch.Text = "الفرع: -";
        // 
        // toolStripStatusLabelDate
        // 
        toolStripStatusLabelDate.Name = "toolStripStatusLabelDate";
        toolStripStatusLabelDate.Size = new Size(118, 32);
        toolStripStatusLabelDate.Text = "2026-01-29";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(13F, 32F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1486, 960);
        Controls.Add(contentPanel);
        Controls.Add(navigationPanel);
        Controls.Add(statusStrip);
        Margin = new Padding(6);
        Name = "MainForm";
        RightToLeft = RightToLeft.Yes;
        RightToLeftLayout = true;
        Text = "الشاشة الرئيسئة للنظام";
        WindowState = FormWindowState.Maximized;
        menuStrip.ResumeLayout(false);
        menuStrip.PerformLayout();
        navigationPanel.ResumeLayout(false);
        statusStrip.ResumeLayout(false);
        statusStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private MenuStrip menuStrip;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem logoutToolStripMenuItem;
    private ToolStripMenuItem viewToolStripMenuItem;
    private Label breadcrumbLabel;
    private Panel navigationPanel;
    private TextBox navigationSearchTextBox;
    private TreeView navigationTree;
    private Panel contentPanel;
    private StatusStrip statusStrip;
    private ToolStripStatusLabel toolStripStatusLabelUser;
    private ToolStripStatusLabel toolStripStatusLabelBranch;
    private ToolStripStatusLabel toolStripStatusLabelDate;
    private ToolTip toolTip;
}
