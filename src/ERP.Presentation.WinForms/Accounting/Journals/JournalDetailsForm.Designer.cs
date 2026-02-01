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
            headerTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)linesGrid).BeginInit();
            SuspendLayout();
            // 
            // headerTable
            // 
            headerTable.ColumnCount = 2;
            headerTable.ColumnStyles.Add(new ColumnStyle());
            headerTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            headerTable.Controls.Add(numberLabel, 0, 0);
            headerTable.Controls.Add(numberValueLabel, 1, 0);
            headerTable.Controls.Add(dateLabel, 0, 1);
            headerTable.Controls.Add(dateValueLabel, 1, 1);
            headerTable.Controls.Add(statusLabel, 0, 2);
            headerTable.Controls.Add(statusValueLabel, 1, 2);
            headerTable.Controls.Add(referenceLabel, 0, 3);
            headerTable.Controls.Add(referenceValueLabel, 1, 3);
            headerTable.Controls.Add(postedAtLabel, 0, 4);
            headerTable.Controls.Add(postedAtValueLabel, 1, 4);
            headerTable.Dock = DockStyle.Top;
            headerTable.Location = new Point(0, 0);
            headerTable.Name = "headerTable";
            headerTable.Padding = new Padding(12);
            headerTable.RowCount = 5;
            headerTable.RowStyles.Add(new RowStyle());
            headerTable.RowStyles.Add(new RowStyle());
            headerTable.RowStyles.Add(new RowStyle());
            headerTable.RowStyles.Add(new RowStyle());
            headerTable.RowStyles.Add(new RowStyle());
            headerTable.Size = new Size(1028, 260);
            headerTable.TabIndex = 0;
            // 
            // numberLabel
            // 
            numberLabel.AutoSize = true;
            numberLabel.Location = new Point(951, 12);
            numberLabel.Name = "numberLabel";
            numberLabel.Size = new Size(62, 32);
            numberLabel.TabIndex = 0;
            numberLabel.Text = "الرقم";
            // 
            // numberValueLabel
            // 
            numberValueLabel.AutoSize = true;
            numberValueLabel.Location = new Point(844, 12);
            numberValueLabel.Name = "numberValueLabel";
            numberValueLabel.Size = new Size(24, 32);
            numberValueLabel.TabIndex = 1;
            numberValueLabel.Text = "-";
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = true;
            dateLabel.Location = new Point(937, 44);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(76, 32);
            dateLabel.TabIndex = 2;
            dateLabel.Text = "التاريخ";
            // 
            // dateValueLabel
            // 
            dateValueLabel.AutoSize = true;
            dateValueLabel.Location = new Point(844, 44);
            dateValueLabel.Name = "dateValueLabel";
            dateValueLabel.Size = new Size(24, 32);
            dateValueLabel.TabIndex = 3;
            dateValueLabel.Text = "-";
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(945, 76);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(68, 32);
            statusLabel.TabIndex = 4;
            statusLabel.Text = "الحالة";
            // 
            // statusValueLabel
            // 
            statusValueLabel.AutoSize = true;
            statusValueLabel.Location = new Point(844, 76);
            statusValueLabel.Name = "statusValueLabel";
            statusValueLabel.Size = new Size(24, 32);
            statusValueLabel.TabIndex = 5;
            statusValueLabel.Text = "-";
            // 
            // referenceLabel
            // 
            referenceLabel.AutoSize = true;
            referenceLabel.Location = new Point(933, 108);
            referenceLabel.Name = "referenceLabel";
            referenceLabel.Size = new Size(80, 32);
            referenceLabel.TabIndex = 6;
            referenceLabel.Text = "المرجع";
            // 
            // referenceValueLabel
            // 
            referenceValueLabel.AutoSize = true;
            referenceValueLabel.Location = new Point(844, 108);
            referenceValueLabel.Name = "referenceValueLabel";
            referenceValueLabel.Size = new Size(24, 32);
            referenceValueLabel.TabIndex = 7;
            referenceValueLabel.Text = "-";
            // 
            // postedAtLabel
            // 
            postedAtLabel.AutoSize = true;
            postedAtLabel.Location = new Point(874, 140);
            postedAtLabel.Name = "postedAtLabel";
            postedAtLabel.Size = new Size(139, 32);
            postedAtLabel.TabIndex = 8;
            postedAtLabel.Text = "تاريخ الترحيل";
            // 
            // postedAtValueLabel
            // 
            postedAtValueLabel.AutoSize = true;
            postedAtValueLabel.Location = new Point(844, 140);
            postedAtValueLabel.Name = "postedAtValueLabel";
            postedAtValueLabel.Size = new Size(24, 32);
            postedAtValueLabel.TabIndex = 9;
            postedAtValueLabel.Text = "-";
            // 
            // linesGrid
            // 
            linesGrid.AllowUserToAddRows = false;
            linesGrid.AllowUserToDeleteRows = false;
            linesGrid.AllowUserToOrderColumns = true;
            linesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            linesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            linesGrid.Dock = DockStyle.Fill;
            linesGrid.Location = new Point(0, 260);
            linesGrid.MultiSelect = false;
            linesGrid.Name = "linesGrid";
            linesGrid.ReadOnly = true;
            linesGrid.RowHeadersWidth = 82;
            linesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            linesGrid.Size = new Size(1028, 386);
            linesGrid.TabIndex = 1;
            // 
            // JournalDetailsForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1028, 646);
            Controls.Add(linesGrid);
            Controls.Add(headerTable);
            Name = "JournalDetailsForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            Text = "عرض تفاصيل قيد واحد";
            WindowState = FormWindowState.Maximized;
            headerTable.ResumeLayout(false);
            headerTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)linesGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

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
    }
}