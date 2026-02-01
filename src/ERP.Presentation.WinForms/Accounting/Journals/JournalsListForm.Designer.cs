namespace ERP.Presentation.WinForms.Accounting.Journals
{
    partial class JournalsListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            toolStrip = new ToolStrip();
            refreshToolStripButton = new ToolStripButton();
            journalsGrid = new DataGridView();
            toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)journalsGrid).BeginInit();
            SuspendLayout();
            // 
            // toolStrip
            // 
            toolStrip.ImageScalingSize = new Size(32, 32);
            toolStrip.Items.AddRange(new ToolStripItem[] { refreshToolStripButton });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.RightToLeft = RightToLeft.Yes;
            toolStrip.Size = new Size(800, 42);
            toolStrip.TabIndex = 0;
            // 
            // refreshToolStripButton
            // 
            refreshToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            refreshToolStripButton.Name = "refreshToolStripButton";
            refreshToolStripButton.Size = new Size(96, 36);
            refreshToolStripButton.Text = "تحديث";
            refreshToolStripButton.Click += RefreshToolStripButton_Click;
            // 
            // journalsGrid
            // 
            journalsGrid.AllowUserToAddRows = false;
            journalsGrid.AllowUserToDeleteRows = false;
            journalsGrid.AllowUserToOrderColumns = true;
            journalsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            journalsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            journalsGrid.Dock = DockStyle.Fill;
            journalsGrid.Location = new Point(0, 42);
            journalsGrid.MultiSelect = false;
            journalsGrid.Name = "journalsGrid";
            journalsGrid.ReadOnly = true;
            journalsGrid.RowHeadersWidth = 82;
            journalsGrid.RowTemplate.Height = 41;
            journalsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            journalsGrid.Size = new Size(800, 408);
            journalsGrid.TabIndex = 1;
            journalsGrid.CellDoubleClick += JournalsGrid_CellDoubleClick;
            // 
            // JournalsListForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(journalsGrid);
            Controls.Add(toolStrip);
            Name = "JournalsListForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            Text = "عرض قائمة القيود";
            WindowState = FormWindowState.Maximized;
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)journalsGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip;
        private ToolStripButton refreshToolStripButton;
        private DataGridView journalsGrid;
    }
}