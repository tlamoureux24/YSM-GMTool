namespace App.WinForms.Controls;

partial class SkillsActionsControl
{
    private System.ComponentModel.IContainer components = null;
    private GroupBox gbSkillsActions;
    private TableLayoutPanel tlp;
    private Label lblSkillId;
    private NumericUpDown nudSkillId;
    private Label lblSkillLevel;
    private NumericUpDown nudSkillLevel;
    private Label lblCreatureSlotIndex;
    private NumericUpDown nudCreatureSlotIndex;
    private Button btnLearnSkill;
    private Button btnSetSkill;
    private Button btnRemoveSkill;
    private Button btnLearnAllJobSkills;
    private Button btnLearnCreatureSkill;
    private Button btnLearnCreatureAllSkill;

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
        gbSkillsActions = new GroupBox();
        tlp = new TableLayoutPanel();
        lblSkillId = new Label();
        nudSkillId = new NumericUpDown();
        lblSkillLevel = new Label();
        nudSkillLevel = new NumericUpDown();
        lblCreatureSlotIndex = new Label();
        nudCreatureSlotIndex = new NumericUpDown();
        btnLearnSkill = new Button();
        btnSetSkill = new Button();
        btnRemoveSkill = new Button();
        btnLearnAllJobSkills = new Button();
        btnLearnCreatureSkill = new Button();
        btnLearnCreatureAllSkill = new Button();
        gbSkillsActions.SuspendLayout();
        tlp.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudSkillId).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudSkillLevel).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudCreatureSlotIndex).BeginInit();
        SuspendLayout();
        // 
        // gbSkillsActions
        // 
        gbSkillsActions.Controls.Add(tlp);
        gbSkillsActions.Dock = DockStyle.Fill;
        gbSkillsActions.Location = new Point(0, 0);
        gbSkillsActions.Name = "gbSkillsActions";
        gbSkillsActions.Size = new Size(430, 370);
        gbSkillsActions.TabIndex = 0;
        gbSkillsActions.TabStop = false;
        gbSkillsActions.Text = "Skills";
        // 
        // tlp
        // 
        tlp.ColumnCount = 2;
        tlp.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tlp.Controls.Add(lblSkillId, 0, 0);
        tlp.Controls.Add(nudSkillId, 1, 0);
        tlp.Controls.Add(lblSkillLevel, 0, 1);
        tlp.Controls.Add(nudSkillLevel, 1, 1);
        tlp.Controls.Add(lblCreatureSlotIndex, 0, 2);
        tlp.Controls.Add(nudCreatureSlotIndex, 1, 2);
        tlp.Controls.Add(btnLearnSkill, 0, 3);
        tlp.Controls.Add(btnSetSkill, 0, 4);
        tlp.Controls.Add(btnRemoveSkill, 0, 5);
        tlp.Controls.Add(btnLearnAllJobSkills, 0, 6);
        tlp.Controls.Add(btnLearnCreatureSkill, 0, 7);
        tlp.Controls.Add(btnLearnCreatureAllSkill, 0, 8);
        tlp.Dock = DockStyle.Fill;
        tlp.Location = new Point(3, 23);
        tlp.Name = "tlp";
        tlp.RowCount = 10;
        tlp.RowStyles.Add(new RowStyle());
        tlp.RowStyles.Add(new RowStyle());
        tlp.RowStyles.Add(new RowStyle());
        tlp.RowStyles.Add(new RowStyle());
        tlp.RowStyles.Add(new RowStyle());
        tlp.RowStyles.Add(new RowStyle());
        tlp.RowStyles.Add(new RowStyle());
        tlp.RowStyles.Add(new RowStyle());
        tlp.RowStyles.Add(new RowStyle());
        tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tlp.Size = new Size(424, 344);
        tlp.TabIndex = 0;
        // 
        // lblSkillId
        // 
        lblSkillId.Anchor = AnchorStyles.Left;
        lblSkillId.AutoSize = true;
        lblSkillId.Location = new Point(3, 8);
        lblSkillId.Name = "lblSkillId";
        lblSkillId.Size = new Size(26, 20);
        lblSkillId.TabIndex = 0;
        lblSkillId.Text = "ID:";
        // 
        // nudSkillId
        // 
        nudSkillId.Dock = DockStyle.Fill;
        nudSkillId.Location = new Point(35, 3);
        nudSkillId.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
        nudSkillId.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudSkillId.Name = "nudSkillId";
        nudSkillId.Size = new Size(386, 27);
        nudSkillId.TabIndex = 1;
        nudSkillId.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // lblSkillLevel
        // 
        lblSkillLevel.Anchor = AnchorStyles.Left;
        lblSkillLevel.AutoSize = true;
        lblSkillLevel.Location = new Point(3, 42);
        lblSkillLevel.Name = "lblSkillLevel";
        lblSkillLevel.Size = new Size(48, 20);
        lblSkillLevel.TabIndex = 2;
        lblSkillLevel.Text = "Level:";
        // 
        // nudSkillLevel
        // 
        nudSkillLevel.Dock = DockStyle.Fill;
        nudSkillLevel.Location = new Point(35, 37);
        nudSkillLevel.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
        nudSkillLevel.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudSkillLevel.Name = "nudSkillLevel";
        nudSkillLevel.Size = new Size(386, 27);
        nudSkillLevel.TabIndex = 3;
        nudSkillLevel.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // lblCreatureSlotIndex
        // 
        lblCreatureSlotIndex.Anchor = AnchorStyles.Left;
        lblCreatureSlotIndex.AutoSize = true;
        lblCreatureSlotIndex.Location = new Point(3, 76);
        lblCreatureSlotIndex.Name = "lblCreatureSlotIndex";
        lblCreatureSlotIndex.Size = new Size(113, 20);
        lblCreatureSlotIndex.TabIndex = 4;
        lblCreatureSlotIndex.Text = "Creature slot (0=all):";
        // 
        // nudCreatureSlotIndex
        // 
        nudCreatureSlotIndex.Dock = DockStyle.Fill;
        nudCreatureSlotIndex.Location = new Point(122, 71);
        nudCreatureSlotIndex.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
        nudCreatureSlotIndex.Name = "nudCreatureSlotIndex";
        nudCreatureSlotIndex.Size = new Size(299, 27);
        nudCreatureSlotIndex.TabIndex = 5;
        // 
        // btnLearnSkill
        // 
        tlp.SetColumnSpan(btnLearnSkill, 2);
        btnLearnSkill.Dock = DockStyle.Fill;
        btnLearnSkill.Location = new Point(3, 105);
        btnLearnSkill.Name = "btnLearnSkill";
        btnLearnSkill.Size = new Size(418, 34);
        btnLearnSkill.TabIndex = 6;
        btnLearnSkill.Text = "Learn skill";
        btnLearnSkill.UseVisualStyleBackColor = true;
        btnLearnSkill.Click += btnLearnSkill_Click;
        // 
        // btnSetSkill
        // 
        tlp.SetColumnSpan(btnSetSkill, 2);
        btnSetSkill.Dock = DockStyle.Fill;
        btnSetSkill.Location = new Point(3, 145);
        btnSetSkill.Name = "btnSetSkill";
        btnSetSkill.Size = new Size(418, 34);
        btnSetSkill.TabIndex = 7;
        btnSetSkill.Text = "Set skill level";
        btnSetSkill.UseVisualStyleBackColor = true;
        btnSetSkill.Click += btnSetSkill_Click;
        // 
        // btnRemoveSkill
        // 
        tlp.SetColumnSpan(btnRemoveSkill, 2);
        btnRemoveSkill.Dock = DockStyle.Fill;
        btnRemoveSkill.Location = new Point(3, 185);
        btnRemoveSkill.Name = "btnRemoveSkill";
        btnRemoveSkill.Size = new Size(418, 34);
        btnRemoveSkill.TabIndex = 8;
        btnRemoveSkill.Text = "Remove skill";
        btnRemoveSkill.UseVisualStyleBackColor = true;
        btnRemoveSkill.Click += btnRemoveSkill_Click;
        // 
        // btnLearnAllJobSkills
        // 
        tlp.SetColumnSpan(btnLearnAllJobSkills, 2);
        btnLearnAllJobSkills.Dock = DockStyle.Fill;
        btnLearnAllJobSkills.Location = new Point(3, 225);
        btnLearnAllJobSkills.Name = "btnLearnAllJobSkills";
        btnLearnAllJobSkills.Size = new Size(418, 34);
        btnLearnAllJobSkills.TabIndex = 9;
        btnLearnAllJobSkills.Text = "Learn all skill";
        btnLearnAllJobSkills.UseVisualStyleBackColor = true;
        btnLearnAllJobSkills.Click += btnLearnAllJobSkills_Click;
        // 
        // btnLearnCreatureSkill
        // 
        tlp.SetColumnSpan(btnLearnCreatureSkill, 2);
        btnLearnCreatureSkill.Dock = DockStyle.Fill;
        btnLearnCreatureSkill.Location = new Point(3, 265);
        btnLearnCreatureSkill.Name = "btnLearnCreatureSkill";
        btnLearnCreatureSkill.Size = new Size(418, 34);
        btnLearnCreatureSkill.TabIndex = 10;
        btnLearnCreatureSkill.Text = "Learn creature skill";
        btnLearnCreatureSkill.UseVisualStyleBackColor = true;
        btnLearnCreatureSkill.Click += btnLearnCreatureSkill_Click;
        // 
        // btnLearnCreatureAllSkill
        // 
        tlp.SetColumnSpan(btnLearnCreatureAllSkill, 2);
        btnLearnCreatureAllSkill.Dock = DockStyle.Fill;
        btnLearnCreatureAllSkill.Location = new Point(3, 305);
        btnLearnCreatureAllSkill.Name = "btnLearnCreatureAllSkill";
        btnLearnCreatureAllSkill.Size = new Size(418, 34);
        btnLearnCreatureAllSkill.TabIndex = 11;
        btnLearnCreatureAllSkill.Text = "Learn creature all skill";
        btnLearnCreatureAllSkill.UseVisualStyleBackColor = true;
        btnLearnCreatureAllSkill.Click += btnLearnCreatureAllSkill_Click;
        // 
        // SkillsActionsControl
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(gbSkillsActions);
        Name = "SkillsActionsControl";
        Size = new Size(430, 370);
        gbSkillsActions.ResumeLayout(false);
        tlp.ResumeLayout(false);
        tlp.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudSkillId).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudSkillLevel).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudCreatureSlotIndex).EndInit();
        ResumeLayout(false);
    }
}
