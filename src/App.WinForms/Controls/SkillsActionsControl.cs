using System.ComponentModel;
using System.Drawing;

namespace App.WinForms.Controls;

public partial class SkillsActionsControl : UserControl
{
    public SkillsActionsControl()
    {
        InitializeComponent();
        ApplyReadabilityPalette();
    }

    public event EventHandler? LearnSkillRequested;

    public event EventHandler? LearnAllJobSkillsRequested;

    public event EventHandler? LearnCreatureSkillRequested;

    public event EventHandler? SetSkillRequested;

    public event EventHandler? RemoveSkillRequested;

    public event EventHandler? LearnCreatureAllSkillRequested;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int SkillId
    {
        get => (int)nudSkillId.Value;
        set
        {
            if (value <= 0)
            {
                return;
            }

            var clamped = Math.Min(value, (int)nudSkillId.Maximum);
            nudSkillId.Value = clamped;
        }
    }

    public int SkillLevel => (int)nudSkillLevel.Value;

    public int CreatureSlotIndex => (int)nudCreatureSlotIndex.Value;

    private void ApplyReadabilityPalette()
    {
        var page = Color.FromArgb(25, 28, 34);
        var panel = Color.FromArgb(34, 39, 48);
        var panelAlt = Color.FromArgb(39, 45, 56);
        var text = Color.FromArgb(235, 238, 245);

        BackColor = page;
        gbSkillsActions.BackColor = panel;
        gbSkillsActions.ForeColor = text;
        gbSelected.BackColor = panelAlt;
        gbPlayerSkills.BackColor = panelAlt;
        gbCreatureSkills.BackColor = panelAlt;
        gbSelected.ForeColor = text;
        gbPlayerSkills.ForeColor = text;
        gbCreatureSkills.ForeColor = text;
    }

    private void btnLearnSkill_Click(object sender, EventArgs e)
    {
        LearnSkillRequested?.Invoke(this, EventArgs.Empty);
    }

    private void btnLearnAllJobSkills_Click(object sender, EventArgs e)
    {
        LearnAllJobSkillsRequested?.Invoke(this, EventArgs.Empty);
    }

    private void btnLearnCreatureSkill_Click(object sender, EventArgs e)
    {
        LearnCreatureSkillRequested?.Invoke(this, EventArgs.Empty);
    }

    private void btnSetSkill_Click(object sender, EventArgs e)
    {
        SetSkillRequested?.Invoke(this, EventArgs.Empty);
    }

    private void btnRemoveSkill_Click(object sender, EventArgs e)
    {
        RemoveSkillRequested?.Invoke(this, EventArgs.Empty);
    }

    private void btnLearnCreatureAllSkill_Click(object sender, EventArgs e)
    {
        LearnCreatureAllSkillRequested?.Invoke(this, EventArgs.Empty);
    }
}
