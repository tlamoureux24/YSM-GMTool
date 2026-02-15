using System.ComponentModel;

namespace App.WinForms.Controls;

public partial class BuffsActionsControl : UserControl
{
    public BuffsActionsControl()
    {
        InitializeComponent();
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
