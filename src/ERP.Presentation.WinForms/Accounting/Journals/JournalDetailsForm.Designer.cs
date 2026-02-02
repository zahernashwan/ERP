namespace ERP.Presentation.WinForms.Accounting.Journals
{
    partial class JournalDetailsForm
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
            mainLayout = new TableLayoutPanel();
            headerGroup = new GroupBox();
            headerTable = new TableLayoutPanel();
            numberLabel = new Label();
            numberValueLabel = new Label();
            dateLabel = new Label();
            dateValueLabel = new Label();
            statusLabel = new Label();
            statusValueLabel = new Label();
            referenceLabel = new Label();
            referenceValueLabel = new Label();
            postedAtLabel = new Label();
            postedAtValueLabel = new Label();
            linesGrid = new DataGridView();
            footerPanel = new Panel();
            footerTable = new TableLayoutPanel();
            totalCreditValueLabel = new Label();
            totalCreditLabel = new Label();
            totalDebitValueLabel = new Label();
            totalDebitLabel = new Label();
            differenceLabel = new Label();
            differenceValueLabel = new Label();
            mainLayout.SuspendLayout();
            headerGroup.SuspendLayout();
            headerTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)linesGrid).BeginInit();
            footerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 1;
            mainLayout.ColumnStyles.Add(new ColumnStyle());
            mainLayout.Controls.Add(headerGroup, 0, 0);
            mainLayout.Controls.Add(linesGrid, 0, 1);
            mainLayout.Controls.Add(footerPanel, 0, 2);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.Padding = new Padding(10);
            mainLayout.RowCount = 3;
            mainLayout.RowStyles.Add(new RowStyle());
            mainLayout.RowStyles.Add(new RowStyle());
            mainLayout.RowStyles.Add(new RowStyle());
            mainLayout.Size = new Size(1859, 1401);
            mainLayout.TabIndex = 0;
            // 
            // headerGroup
            // 
            headerGroup.AutoSize = true;
            headerGroup.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            headerGroup.Controls.Add(headerTable);
            headerGroup.Dock = DockStyle.Fill;
            headerGroup.Location = new Point(13, 13);
            headerGroup.Name = "headerGroup";
            headerGroup.Size = new Size(1833, 166);
            headerGroup.TabIndex = 0;
            headerGroup.TabStop = false;
            headerGroup.Text = "بيانات القيد";
            // 
            // headerTable
            // 
            headerTable.AutoSize = true;
            headerTable.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            headerTable.ColumnCount = 6;
            headerTable.ColumnStyles.Add(new ColumnStyle());
            headerTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            headerTable.ColumnStyles.Add(new ColumnStyle());
            headerTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            headerTable.ColumnStyles.Add(new ColumnStyle());
            headerTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            headerTable.Controls.Add(numberLabel, 0, 0);
            headerTable.Controls.Add(numberValueLabel, 1, 0);
            headerTable.Controls.Add(dateLabel, 2, 0);
            headerTable.Controls.Add(dateValueLabel, 3, 0);
            headerTable.Controls.Add(statusLabel, 4, 0);
            headerTable.Controls.Add(statusValueLabel, 5, 0);
            headerTable.Controls.Add(referenceLabel, 0, 1);
            headerTable.Controls.Add(referenceValueLabel, 1, 1);
            headerTable.Controls.Add(postedAtLabel, 2, 1);
            headerTable.Controls.Add(postedAtValueLabel, 3, 1);
            headerTable.Dock = DockStyle.Fill;
            headerTable.Location = new Point(3, 35);
            headerTable.Name = "headerTable";
            headerTable.RowCount = 2;
            headerTable.RowStyles.Add(new RowStyle());
            headerTable.RowStyles.Add(new RowStyle());
            headerTable.Size = new Size(1827, 128);
            headerTable.TabIndex = 0;
            // 
            // numberLabel
            // 
            numberLabel.AutoSize = true;
            numberLabel.Dock = DockStyle.Fill;
            numberLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            numberLabel.Location = new Point(1710, 0);
            numberLabel.Margin = new Padding(3, 8, 3, 8);
            numberLabel.Name = "numberLabel";
            numberLabel.Size = new Size(114, 45);
            numberLabel.TabIndex = 0;
            numberLabel.Text = "الرقم:";
            numberLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // numberValueLabel
            // 
            numberValueLabel.AutoSize = true;
            numberValueLabel.Dock = DockStyle.Fill;
            numberValueLabel.Font = new Font("Segoe UI", 10F);
            numberValueLabel.Location = new Point(1221, 0);
            numberValueLabel.Margin = new Padding(3, 8, 20, 8);
            numberValueLabel.Name = "numberValueLabel";
            numberValueLabel.Size = new Size(466, 45);
            numberValueLabel.TabIndex = 1;
            numberValueLabel.Text = "-";
            numberValueLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = true;
            dateLabel.Dock = DockStyle.Fill;
            dateLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dateLabel.Location = new Point(1101, 0);
            dateLabel.Margin = new Padding(3, 8, 3, 8);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(114, 45);
            dateLabel.TabIndex = 2;
            dateLabel.Text = "التاريخ:";
            dateLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dateValueLabel
            // 
            dateValueLabel.AutoSize = true;
            dateValueLabel.Dock = DockStyle.Fill;
            dateValueLabel.Font = new Font("Segoe UI", 10F);
            dateValueLabel.Location = new Point(612, 0);
            dateValueLabel.Margin = new Padding(3, 8, 20, 8);
            dateValueLabel.Name = "dateValueLabel";
            dateValueLabel.Size = new Size(466, 45);
            dateValueLabel.TabIndex = 3;
            dateValueLabel.Text = "-";
            dateValueLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Dock = DockStyle.Fill;
            statusLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            statusLabel.Location = new Point(492, 0);
            statusLabel.Margin = new Padding(3, 8, 3, 8);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(114, 45);
            statusLabel.TabIndex = 4;
            statusLabel.Text = "الحالة:";
            statusLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // statusValueLabel
            // 
            statusValueLabel.AutoSize = true;
            statusValueLabel.Dock = DockStyle.Fill;
            statusValueLabel.Font = new Font("Segoe UI", 10F);
            statusValueLabel.Location = new Point(3, 0);
            statusValueLabel.Margin = new Padding(3, 8, 20, 8);
            statusValueLabel.Name = "statusValueLabel";
            statusValueLabel.Size = new Size(466, 45);
            statusValueLabel.TabIndex = 5;
            statusValueLabel.Text = "-";
            statusValueLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // referenceLabel
            // 
            referenceLabel.AutoSize = true;
            referenceLabel.Dock = DockStyle.Fill;
            referenceLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            referenceLabel.Location = new Point(1710, 61);
            referenceLabel.Margin = new Padding(3, 8, 3, 8);
            referenceLabel.Name = "referenceLabel";
            referenceLabel.Size = new Size(114, 45);
            referenceLabel.TabIndex = 6;
            referenceLabel.Text = "المرجع:";
            referenceLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // referenceValueLabel
            // 
            referenceValueLabel.AutoSize = true;
            referenceValueLabel.Dock = DockStyle.Fill;
            referenceValueLabel.Font = new Font("Segoe UI", 10F);
            referenceValueLabel.Location = new Point(1221, 61);
            referenceValueLabel.Margin = new Padding(3, 8, 20, 8);
            referenceValueLabel.Name = "referenceValueLabel";
            referenceValueLabel.Size = new Size(466, 45);
            referenceValueLabel.TabIndex = 7;
            referenceValueLabel.Text = "-";
            referenceValueLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // postedAtLabel
            // 
            postedAtLabel.AutoSize = true;
            postedAtLabel.Dock = DockStyle.Fill;
            postedAtLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            postedAtLabel.Location = new Point(1101, 61);
            postedAtLabel.Margin = new Padding(3, 8, 3, 8);
            postedAtLabel.Name = "postedAtLabel";
            postedAtLabel.Size = new Size(114, 45);
            postedAtLabel.TabIndex = 8;
            postedAtLabel.Text = "تاريخ الترحيل:";
            postedAtLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // postedAtValueLabel
            // 
            postedAtValueLabel.AutoSize = true;
            postedAtValueLabel.Dock = DockStyle.Fill;
            postedAtValueLabel.Font = new Font("Segoe UI", 10F);
            postedAtValueLabel.Location = new Point(612, 61);
            postedAtValueLabel.Margin = new Padding(3, 8, 20, 8);
            postedAtValueLabel.Name = "postedAtValueLabel";
            postedAtValueLabel.Size = new Size(466, 45);
            postedAtValueLabel.TabIndex = 9;
            postedAtValueLabel.Text = "-";
            postedAtValueLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // linesGrid
            // 
            linesGrid.AllowUserToAddRows = false;
            linesGrid.AllowUserToDeleteRows = false;
            linesGrid.AllowUserToOrderColumns = true;
            linesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            linesGrid.BorderStyle = BorderStyle.None;
            linesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            linesGrid.Dock = DockStyle.Fill;
            linesGrid.Location = new Point(13, 185);
            linesGrid.MultiSelect = false;
            linesGrid.Name = "linesGrid";
            linesGrid.ReadOnly = true;
            linesGrid.RowHeadersWidth = 30;
            linesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            linesGrid.Size = new Size(1833, 941);
            linesGrid.TabIndex = 1;
            // 
            // footerPanel
            // 
            footerPanel.AutoSize = true;
            footerPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            footerPanel.BackColor = SystemColors.Control;
            footerPanel.Controls.Add(footerTable);
            footerPanel.Dock = DockStyle.Fill;
            footerPanel.Location = new Point(13, 1132);
            footerPanel.Name = "footerPanel";
            footerPanel.Padding = new Padding(5);
            footerPanel.Size = new Size(1833, 256);
            footerPanel.TabIndex = 2;
            
            // 
            // footerTable
            // 
            footerTable.AutoSize = true;
            footerTable.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            footerTable.ColumnCount = 6;
            footerTable.ColumnStyles.Add(new ColumnStyle());
            footerTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            footerTable.ColumnStyles.Add(new ColumnStyle());
            footerTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            footerTable.ColumnStyles.Add(new ColumnStyle());
            footerTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            footerTable.Controls.Add(totalDebitLabel, 0, 0);
            footerTable.Controls.Add(totalDebitValueLabel, 1, 0);
            footerTable.Controls.Add(totalCreditLabel, 2, 0);
            footerTable.Controls.Add(totalCreditValueLabel, 3, 0);
            footerTable.Controls.Add(differenceLabel, 4, 0);
            footerTable.Controls.Add(differenceValueLabel, 5, 0);
            footerTable.Dock = DockStyle.Right;
            footerTable.Location = new Point(1005, 5);
            footerTable.Name = "footerTable";
            footerTable.RowCount = 1;
            footerTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            footerTable.Size = new Size(823, 236);
            footerTable.TabIndex = 0;

            // 
            // totalDebitLabel
            // 
            totalDebitLabel.AutoSize = true;
            totalDebitLabel.Dock = DockStyle.Fill;
            totalDebitLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            totalDebitLabel.Location = new Point(3, 3);
            totalDebitLabel.Margin = new Padding(3);
            totalDebitLabel.Name = "totalDebitLabel";
            totalDebitLabel.Size = new Size(100, 230);
            totalDebitLabel.TabIndex = 0;
            totalDebitLabel.Text = "إجمالي المدين:";
            totalDebitLabel.TextAlign = ContentAlignment.MiddleRight;

            // 
            // totalDebitValueLabel
            // 
            totalDebitValueLabel.AutoSize = true;
            totalDebitValueLabel.BackColor = SystemColors.Window;
            totalDebitValueLabel.BorderStyle = BorderStyle.Fixed3D;
            totalDebitValueLabel.Dock = DockStyle.Fill;
            totalDebitValueLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            totalDebitValueLabel.ForeColor = SystemColors.WindowText;
            totalDebitValueLabel.Location = new Point(109, 3);
            totalDebitValueLabel.Margin = new Padding(3, 3, 10, 3);
            totalDebitValueLabel.Name = "totalDebitValueLabel";
            totalDebitValueLabel.Size = new Size(127, 230);
            totalDebitValueLabel.TabIndex = 1;
            totalDebitValueLabel.Text = "0.00";
            totalDebitValueLabel.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // totalCreditLabel
            // 
            totalCreditLabel.AutoSize = true;
            totalCreditLabel.Dock = DockStyle.Fill;
            totalCreditLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            totalCreditLabel.Location = new Point(249, 3);
            totalCreditLabel.Margin = new Padding(3);
            totalCreditLabel.Name = "totalCreditLabel";
            totalCreditLabel.Size = new Size(100, 230);
            totalCreditLabel.TabIndex = 2;
            totalCreditLabel.Text = "إجمالي الدائن:";
            totalCreditLabel.TextAlign = ContentAlignment.MiddleRight;

            // 
            // totalCreditValueLabel
            // 
            totalCreditValueLabel.AutoSize = true;
            totalCreditValueLabel.BackColor = SystemColors.Window;
            totalCreditValueLabel.BorderStyle = BorderStyle.Fixed3D;
            totalCreditValueLabel.Dock = DockStyle.Fill;
            totalCreditValueLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            totalCreditValueLabel.ForeColor = SystemColors.WindowText;
            totalCreditValueLabel.Location = new Point(355, 3);
            totalCreditValueLabel.Margin = new Padding(3, 3, 10, 3);
            totalCreditValueLabel.Name = "totalCreditValueLabel";
            totalCreditValueLabel.Size = new Size(127, 230);
            totalCreditValueLabel.TabIndex = 3;
            totalCreditValueLabel.Text = "0.00";
            totalCreditValueLabel.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // differenceLabel
            // 
            differenceLabel.AutoSize = true;
            differenceLabel.Dock = DockStyle.Fill;
            differenceLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            differenceLabel.Location = new Point(495, 3);
            differenceLabel.Margin = new Padding(3);
            differenceLabel.Name = "differenceLabel";
            differenceLabel.Size = new Size(100, 230);
            differenceLabel.TabIndex = 4;
            differenceLabel.Text = "الفرق:";
            differenceLabel.TextAlign = ContentAlignment.MiddleRight;

            // 
            // differenceValueLabel
            // 
            differenceValueLabel.AutoSize = true;
            differenceValueLabel.BackColor = SystemColors.Window;
            differenceValueLabel.BorderStyle = BorderStyle.Fixed3D;
            differenceValueLabel.Dock = DockStyle.Fill;
            differenceValueLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            differenceValueLabel.ForeColor = SystemColors.WindowText;
            differenceValueLabel.Location = new Point(601, 3);
            differenceValueLabel.Margin = new Padding(3);
            differenceValueLabel.Name = "differenceValueLabel";
            differenceValueLabel.Size = new Size(134, 230);
            differenceValueLabel.TabIndex = 5;
            differenceValueLabel.Text = "0.00";
            differenceValueLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // JournalDetailsForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1859, 1401);
            Controls.Add(mainLayout);
            Name = "JournalDetailsForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            Text = "عرض تفاصيل قيد واحد";
            WindowState = FormWindowState.Maximized;
            mainLayout.ResumeLayout(false);
            mainLayout.PerformLayout();
            headerGroup.ResumeLayout(false);
            headerGroup.PerformLayout();
            headerTable.ResumeLayout(false);
            headerTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)linesGrid).EndInit();
            footerPanel.ResumeLayout(false);
            footerPanel.PerformLayout();
            footerTable.ResumeLayout(false);
            footerTable.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel mainLayout;
        private GroupBox headerGroup;
        private TableLayoutPanel headerTable;
        private Label numberLabel;
        private Label numberValueLabel;
        private Label dateLabel;
        private Label dateValueLabel;
        private Label statusLabel;
        private Label statusValueLabel;
        private Label referenceLabel;
        private Label referenceValueLabel;
        private Label postedAtLabel;
        private Label postedAtValueLabel;
        private DataGridView linesGrid;
        private Panel footerPanel;
        private TableLayoutPanel footerTable;
        private Label totalDebitLabel;
        private Label totalDebitValueLabel;
        private Label totalCreditLabel;
        private Label totalCreditValueLabel;
        private Label differenceLabel;
        private Label differenceValueLabel;
    }
}