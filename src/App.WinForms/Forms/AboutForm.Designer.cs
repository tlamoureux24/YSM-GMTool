namespace App.WinForms.Forms;

partial class AboutForm
{
    private System.ComponentModel.IContainer components = null;
    private TableLayoutPanel tlp;
    private Label lblTitle;
    private Label lblAuthor;
    private Button btnOk;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        tlp = new TableLayoutPanel();
        lblTitle = new Label();
        lblAuthor = new Label();
        btnOk = new Button();
        tlp.SuspendLayout();
        SuspendLayout();
        // 
        // tlp
        // 
        tlp.ColumnCount = 1;
        tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tlp.Controls.Add(lblTitle, 0, 0);
        tlp.Controls.Add(lblAuthor, 0, 1);
        tlp.Controls.Add(btnOk, 0, 2);
        tlp.Dock = DockStyle.Fill;
        tlp.Location = new Point(12, 12);
        tlp.Name = "tlp";
        tlp.RowCount = 3;
        tlp.RowStyles.Add(new RowStyle());
        tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tlp.RowStyles.Add(new RowStyle());
        tlp.Size = new Size(360, 177);
        tlp.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Dock = DockStyle.Fill;
        lblTitle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
        lblTitle.Location = new Point(3, 0);
        lblTitle.Name = "lblTitle";
        lblTitle.Padding = new Padding(0, 12, 0, 12);
        lblTitle.Size = new Size(354, 52);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "GM Tool";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblAuthor
        // 
        lblAuthor.AutoSize = true;
        lblAuthor.Dock = DockStyle.Fill;
        lblAuthor.Location = new Point(3, 52);
        lblAuthor.Name = "lblAuthor";
        lblAuthor.Size = new Size(354, 90);
        lblAuthor.TabIndex = 1;
        lblAuthor.Text = "Aplikacje tworzyl YoSiem.";
        lblAuthor.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // btnOk
        // 
        btnOk.Anchor = AnchorStyles.Right;
        btnOk.DialogResult = DialogResult.OK;
        btnOk.Location = new Point(257, 145);
        btnOk.Name = "btnOk";
        btnOk.Size = new Size(100, 29);
        btnOk.TabIndex = 2;
        btnOk.Text = "OK";
        btnOk.UseVisualStyleBackColor = true;
        // 
        // AboutForm
        // 
        AcceptButton = btnOk;
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(384, 201);
        Controls.Add(tlp);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "AboutForm";
        Padding = new Padding(12);
        StartPosition = FormStartPosition.CenterParent;
        Text = "About";
        tlp.ResumeLayout(false);
        tlp.PerformLayout();
        ResumeLayout(false);
    }
}
