using System.ComponentModel;
using System.Drawing;

namespace App.WinForms.Controls;

public partial class BuffsActionsControl : UserControl
{
    public BuffsActionsControl()
    {
        InitializeComponent();
        ApplyReadabilityPalette();
        rbPlayer.Checked = true;
    }

    public event EventHandler? AddTimedWorldStateRequested;

    public event EventHandler? AddEventStateRequested;

    public event EventHandler? RemoveEventStateRequested;

    public event EventHandler? AddPlayerOrCreatureBuffRequested;

    public event EventHandler? RemovePlayerOrCreatureBuffRequested;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int StateId
    {
        get => (int)nudStateId.Value;
        set
        {
            if (value <= 0)
            {
                return;
            }

            var clamped = Math.Min(value, (int)nudStateId.Maximum);
            nudStateId.Value = clamped;
        }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string BuffName
    {
        get => txtBuffName.Text;
        set => txtBuffName.Text = value ?? string.Empty;
    }

    public int BuffLevel => (int)nudBuffLevel.Value;

    public int DurationMinutes => (int)nudDurationMinutes.Value;

    public bool IsSummonTarget => rbSummon.Checked;

    private void ApplyReadabilityPalette()
    {
        var page = Color.FromArgb(25, 28, 34);
        var panel = Color.FromArgb(34, 39, 48);
        var panelAlt = Color.FromArgb(39, 45, 56);
        var text = Color.FromArgb(235, 238, 245);

        BackColor = page;
        gbBuffActions.BackColor = panel;
        gbBuffActions.ForeColor = text;
        gbSelected.BackColor = panelAlt;
        gbGlobalBuffs.BackColor = panelAlt;
        gbPlayerCreature.BackColor = panelAlt;
        gbSelected.ForeColor = text;
        gbGlobalBuffs.ForeColor = text;
        gbPlayerCreature.ForeColor = text;
    }

    private void btnAddTimedWorldState_Click(object sender, EventArgs e)
    {
        AddTimedWorldStateRequested?.Invoke(this, EventArgs.Empty);
    }

    private void btnAddEventState_Click(object sender, EventArgs e)
    {
        AddEventStateRequested?.Invoke(this, EventArgs.Empty);
    }

    private void btnRemoveEventState_Click(object sender, EventArgs e)
    {
        RemoveEventStateRequested?.Invoke(this, EventArgs.Empty);
    }

    private void btnAddBuff_Click(object sender, EventArgs e)
    {
        AddPlayerOrCreatureBuffRequested?.Invoke(this, EventArgs.Empty);
    }

    private void btnRemoveBuff_Click(object sender, EventArgs e)
    {
        RemovePlayerOrCreatureBuffRequested?.Invoke(this, EventArgs.Empty);
    }
}
