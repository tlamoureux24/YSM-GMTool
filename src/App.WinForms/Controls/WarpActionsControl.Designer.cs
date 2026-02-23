namespace App.WinForms.Controls;

partial class WarpActionsControl
{
    private System.ComponentModel.IContainer components = null;
    private GroupBox gbWarpActions;
    private TableLayoutPanel tlpRoot;
    private GroupBox gbWarpCommands;
    private TableLayoutPanel tlpCommands;
    private Label lblSelectedX;
    private NumericUpDown nudSelectedX;
    private Label lblSelectedY;
    private NumericUpDown nudSelectedY;
    private Button btnWarpToYou;
    private Button btnWarp;
    private Button btnWarpToSomeone;
    private Button btnOpenWorldmap;
    private GroupBox gbManageWarp;
    private TableLayoutPanel tlpManage;
    private Label lblAddX;
    private NumericUpDown nudAddX;
    private Label lblAddY;
    private NumericUpDown nudAddY;
    private Label lblLocationName;
    private TextBox txtLocationName;
    private Button btnAdd;
    private Button btnRemoveSelected;

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
        gbWarpActions = new GroupBox();
        tlpRoot = new TableLayoutPanel();
        gbWarpCommands = new GroupBox();
        tlpCommands = new TableLayoutPanel();
        lblSelectedX = new Label();
        nudSelectedX = new NumericUpDown();
        lblSelectedY = new Label();
        nudSelectedY = new NumericUpDown();
        btnWarpToYou = new Button();
        btnWarp = new Button();
        btnWarpToSomeone = new Button();
        btnOpenWorldmap = new Button();
        gbManageWarp = new GroupBox();
        tlpManage = new TableLayoutPanel();
        lblAddX = new Label();
        nudAddX = new NumericUpDown();
        lblAddY = new Label();
        nudAddY = new NumericUpDown();
        lblLocationName = new Label();
        txtLocationName = new TextBox();
        btnAdd = new Button();
        btnRemoveSelected = new Button();
        gbWarpActions.SuspendLayout();
        tlpRoot.SuspendLayout();
        gbWarpCommands.SuspendLayout();
        tlpCommands.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudSelectedX).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudSelectedY).BeginInit();
        gbManageWarp.SuspendLayout();
        tlpManage.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudAddX).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudAddY).BeginInit();
        SuspendLayout();
        // 
        // gbWarpActions
        // 
        gbWarpActions.Controls.Add(tlpRoot);
        gbWarpActions.Dock = DockStyle.Fill;
        gbWarpActions.Location = new Point(0, 0);
        gbWarpActions.Name = "gbWarpActions";
        gbWarpActions.Size = new Size(430, 290);
        gbWarpActions.TabIndex = 0;
        gbWarpActions.TabStop = false;
        gbWarpActions.Text = "Warp Commands";
        // 
        // tlpRoot
        // 
        tlpRoot.ColumnCount = 1;
        tlpRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tlpRoot.Controls.Add(gbWarpCommands, 0, 0);
        tlpRoot.Controls.Add(gbManageWarp, 0, 1);
        tlpRoot.Dock = DockStyle.Fill;
        tlpRoot.Location = new Point(3, 23);
        tlpRoot.Name = "tlpRoot";
        tlpRoot.RowCount = 2;
        tlpRoot.RowStyles.Add(new RowStyle());
        tlpRoot.RowStyles.Add(new RowStyle());
        tlpRoot.Size = new Size(424, 264);
        tlpRoot.TabIndex = 0;
        // 
        // gbWarpCommands
        // 
        gbWarpCommands.Controls.Add(tlpCommands);
        gbWarpCommands.Dock = DockStyle.Fill;
        gbWarpCommands.Location = new Point(3, 3);
        gbWarpCommands.Name = "gbWarpCommands";
        gbWarpCommands.Size = new Size(418, 146);
        gbWarpCommands.TabIndex = 0;
        gbWarpCommands.TabStop = false;
        gbWarpCommands.Text = "Selected Warp";
        // 
        // tlpCommands
        // 
        tlpCommands.ColumnCount = 4;
        tlpCommands.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
        tlpCommands.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tlpCommands.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
        tlpCommands.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tlpCommands.Controls.Add(lblSelectedX, 0, 0);
        tlpCommands.Controls.Add(nudSelectedX, 1, 0);
        tlpCommands.Controls.Add(lblSelectedY, 2, 0);
        tlpCommands.Controls.Add(nudSelectedY, 3, 0);
        tlpCommands.Controls.Add(btnWarp, 0, 1);
        tlpCommands.Controls.Add(btnWarpToYou, 0, 2);
        tlpCommands.Controls.Add(btnWarpToSomeone, 2, 2);
        tlpCommands.Controls.Add(btnOpenWorldmap, 0, 3);
        tlpCommands.Dock = DockStyle.Fill;
        tlpCommands.Location = new Point(3, 23);
        tlpCommands.Name = "tlpCommands";
        tlpCommands.RowCount = 4;
        tlpCommands.RowStyles.Add(new RowStyle());
        tlpCommands.RowStyles.Add(new RowStyle());
        tlpCommands.RowStyles.Add(new RowStyle());
        tlpCommands.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
        tlpCommands.Size = new Size(412, 120);
        tlpCommands.TabIndex = 0;
        // 
        // lblSelectedX
        // 
        lblSelectedX.Anchor = AnchorStyles.Left;
        lblSelectedX.AutoSize = true;
        lblSelectedX.Location = new Point(3, 7);
        lblSelectedX.Name = "lblSelectedX";
        lblSelectedX.Size = new Size(17, 20);
        lblSelectedX.TabIndex = 0;
        lblSelectedX.Text = "X";
        // 
        // nudSelectedX
        // 
        nudSelectedX.Dock = DockStyle.Fill;
        nudSelectedX.Location = new Point(53, 3);
        nudSelectedX.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        nudSelectedX.Minimum = new decimal(new int[] { 1000000, 0, 0, int.MinValue });
        nudSelectedX.Name = "nudSelectedX";
        nudSelectedX.Size = new Size(150, 27);
        nudSelectedX.TabIndex = 1;
        // 
        // lblSelectedY
        // 
        lblSelectedY.Anchor = AnchorStyles.Left;
        lblSelectedY.AutoSize = true;
        lblSelectedY.Location = new Point(209, 7);
        lblSelectedY.Name = "lblSelectedY";
        lblSelectedY.Size = new Size(16, 20);
        lblSelectedY.TabIndex = 2;
        lblSelectedY.Text = "Y";
        // 
        // nudSelectedY
        // 
        nudSelectedY.Dock = DockStyle.Fill;
        nudSelectedY.Location = new Point(259, 3);
        nudSelectedY.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        nudSelectedY.Minimum = new decimal(new int[] { 1000000, 0, 0, int.MinValue });
        nudSelectedY.Name = "nudSelectedY";
        nudSelectedY.Size = new Size(150, 27);
        nudSelectedY.TabIndex = 3;
        // 
        // btnWarp
        // 
        tlpCommands.SetColumnSpan(btnWarp, 2);
        btnWarp.Dock = DockStyle.Fill;
        btnWarp.Location = new Point(3, 36);
        btnWarp.Name = "btnWarp";
        btnWarp.Size = new Size(200, 30);
        btnWarp.TabIndex = 4;
        btnWarp.Text = "Warp";
        btnWarp.UseVisualStyleBackColor = true;
        btnWarp.Click += btnWarp_Click;
        // 
        // btnWarpToYou
        // 
        tlpCommands.SetColumnSpan(btnWarpToYou, 2);
        btnWarpToYou.Dock = DockStyle.Fill;
        btnWarpToYou.Location = new Point(3, 72);
        btnWarpToYou.Name = "btnWarpToYou";
        btnWarpToYou.Size = new Size(200, 30);
        btnWarpToYou.TabIndex = 5;
        btnWarpToYou.Text = "Warp to you";
        btnWarpToYou.UseVisualStyleBackColor = true;
        btnWarpToYou.Click += btnWarpToYou_Click;
        // 
        // btnWarpToSomeone
        // 
        tlpCommands.SetColumnSpan(btnWarpToSomeone, 2);
        btnWarpToSomeone.Dock = DockStyle.Fill;
        btnWarpToSomeone.Location = new Point(209, 72);
        btnWarpToSomeone.Name = "btnWarpToSomeone";
        btnWarpToSomeone.Size = new Size(200, 30);
        btnWarpToSomeone.TabIndex = 6;
        btnWarpToSomeone.Text = "Warp to someone";
        btnWarpToSomeone.UseVisualStyleBackColor = true;
        btnWarpToSomeone.Click += btnWarpToSomeone_Click;
        // 
        // btnOpenWorldmap
        // 
        tlpCommands.SetColumnSpan(btnOpenWorldmap, 2);
        btnOpenWorldmap.Dock = DockStyle.Fill;
        btnOpenWorldmap.Enabled = false;
        btnOpenWorldmap.Location = new Point(3, 108);
        btnOpenWorldmap.Name = "btnOpenWorldmap";
        btnOpenWorldmap.Size = new Size(200, 30);
        btnOpenWorldmap.TabIndex = 7;
        btnOpenWorldmap.Text = "OpenWorldmap";
        btnOpenWorldmap.UseVisualStyleBackColor = true;
        // 
        // gbManageWarp
        // 
        gbManageWarp.Controls.Add(tlpManage);
        gbManageWarp.Dock = DockStyle.Fill;
        gbManageWarp.Location = new Point(3, 126);
        gbManageWarp.Name = "gbManageWarp";
        gbManageWarp.Size = new Size(418, 135);
        gbManageWarp.TabIndex = 1;
        gbManageWarp.TabStop = false;
        gbManageWarp.Text = "Manage Warps";
        // 
        // tlpManage
        // 
        tlpManage.ColumnCount = 4;
        tlpManage.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
        tlpManage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tlpManage.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
        tlpManage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tlpManage.Controls.Add(lblAddX, 0, 0);
        tlpManage.Controls.Add(nudAddX, 1, 0);
        tlpManage.Controls.Add(lblAddY, 2, 0);
        tlpManage.Controls.Add(nudAddY, 3, 0);
        tlpManage.Controls.Add(lblLocationName, 0, 1);
        tlpManage.Controls.Add(txtLocationName, 1, 1);
        tlpManage.Controls.Add(btnAdd, 0, 2);
        tlpManage.Controls.Add(btnRemoveSelected, 2, 2);
        tlpManage.Dock = DockStyle.Fill;
        tlpManage.Location = new Point(3, 23);
        tlpManage.Name = "tlpManage";
        tlpManage.RowCount = 3;
        tlpManage.RowStyles.Add(new RowStyle());
        tlpManage.RowStyles.Add(new RowStyle());
        tlpManage.RowStyles.Add(new RowStyle());
        tlpManage.Size = new Size(412, 109);
        tlpManage.TabIndex = 0;
        // 
        // lblAddX
        // 
        lblAddX.Anchor = AnchorStyles.Left;
        lblAddX.AutoSize = true;
        lblAddX.Location = new Point(3, 7);
        lblAddX.Name = "lblAddX";
        lblAddX.Size = new Size(17, 20);
        lblAddX.TabIndex = 0;
        lblAddX.Text = "X";
        // 
        // nudAddX
        // 
        nudAddX.Dock = DockStyle.Fill;
        nudAddX.Location = new Point(53, 3);
        nudAddX.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        nudAddX.Minimum = new decimal(new int[] { 1000000, 0, 0, int.MinValue });
        nudAddX.Name = "nudAddX";
        nudAddX.Size = new Size(150, 27);
        nudAddX.TabIndex = 1;
        // 
        // lblAddY
        // 
        lblAddY.Anchor = AnchorStyles.Left;
        lblAddY.AutoSize = true;
        lblAddY.Location = new Point(209, 7);
        lblAddY.Name = "lblAddY";
        lblAddY.Size = new Size(16, 20);
        lblAddY.TabIndex = 2;
        lblAddY.Text = "Y";
        // 
        // nudAddY
        // 
        nudAddY.Dock = DockStyle.Fill;
        nudAddY.Location = new Point(259, 3);
        nudAddY.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        nudAddY.Minimum = new decimal(new int[] { 1000000, 0, 0, int.MinValue });
        nudAddY.Name = "nudAddY";
        nudAddY.Size = new Size(150, 27);
        nudAddY.TabIndex = 3;
        // 
        // lblLocationName
        // 
        lblLocationName.Anchor = AnchorStyles.Left;
        lblLocationName.AutoSize = true;
        lblLocationName.Location = new Point(3, 40);
        lblLocationName.Name = "lblLocationName";
        lblLocationName.Size = new Size(29, 20);
        lblLocationName.TabIndex = 4;
        lblLocationName.Text = "Loc";
        // 
        // txtLocationName
        // 
        tlpManage.SetColumnSpan(txtLocationName, 3);
        txtLocationName.Dock = DockStyle.Fill;
        txtLocationName.Location = new Point(53, 36);
        txtLocationName.Name = "txtLocationName";
        txtLocationName.PlaceholderText = "Location name";
        txtLocationName.Size = new Size(356, 27);
        txtLocationName.TabIndex = 5;
        // 
        // btnAdd
        // 
        tlpManage.SetColumnSpan(btnAdd, 2);
        btnAdd.Dock = DockStyle.Fill;
        btnAdd.Location = new Point(3, 69);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(200, 37);
        btnAdd.TabIndex = 6;
        btnAdd.Text = "Add";
        btnAdd.UseVisualStyleBackColor = true;
        btnAdd.Click += btnAdd_Click;
        // 
        // btnRemoveSelected
        // 
        tlpManage.SetColumnSpan(btnRemoveSelected, 2);
        btnRemoveSelected.Dock = DockStyle.Fill;
        btnRemoveSelected.Location = new Point(209, 69);
        btnRemoveSelected.Name = "btnRemoveSelected";
        btnRemoveSelected.Size = new Size(200, 37);
        btnRemoveSelected.TabIndex = 7;
        btnRemoveSelected.Text = "X";
        btnRemoveSelected.UseVisualStyleBackColor = true;
        btnRemoveSelected.Click += btnRemoveSelected_Click;
        // 
        // WarpActionsControl
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(gbWarpActions);
        MinimumSize = new Size(430, 0);
        Name = "WarpActionsControl";
        Size = new Size(430, 320);
        gbWarpActions.ResumeLayout(false);
        tlpRoot.ResumeLayout(false);
        gbWarpCommands.ResumeLayout(false);
        tlpCommands.ResumeLayout(false);
        tlpCommands.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudSelectedX).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudSelectedY).EndInit();
        gbManageWarp.ResumeLayout(false);
        tlpManage.ResumeLayout(false);
        tlpManage.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudAddX).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudAddY).EndInit();
        ResumeLayout(false);
    }
}
