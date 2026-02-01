namespace ERP.Presentation.WinForms.Accounting.Journals;

partial class JournalForm
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
        _btnCreate = new Button();
        SuspendLayout();
        
        // 
        // _btnCreate
        // 
        _btnCreate.Location = new Point(12, 12);
        _btnCreate.Name = "_btnCreate";
        _btnCreate.Size = new Size(150, 40);
        _btnCreate.TabIndex = 0;
        _btnCreate.Text = "Create Journal";
        _btnCreate.UseVisualStyleBackColor = true;

        // 
        // JournalForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(_btnCreate);
        Name = "JournalForm";
        Text = "Journals";
        ResumeLayout(false);
    }

    #endregion

    private Button _btnCreate;
}
