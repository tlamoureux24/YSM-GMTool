using System.ComponentModel;

namespace App.WinForms.Controls;

public partial class SummonsActionsControl : UserControl
{
    public SummonsActionsControl()
    {
        InitializeComponent();
        cmbSlot.SelectedIndex = 0;
        nudAddStage.Enabled = chkUseAddStage.Checked;
    }

    public event EventHandler? AddSummonRequested;

    public event EventHandler? StageSummonRequested;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int SummonId
    {
        get => (int)nudSummonId.Value;
        set
        {
            if (value <= 0)
            {
                return;
            }

            var clamped = Math.Min(value, (int)nudSummonId.Maximum);
            nudSummonId.Value = clamped;
        }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int AddSummonStage => (int)nudAddStage.Value;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool UseAddSummonStage => chkUseAddStage.Checked;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int Slot
    {
        get
        {
            if (cmbSlot.SelectedItem is int slot)
            {
                return slot;
            }

            return 0;
        }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int Stage => (int)nudStage.Value;

    private void btnAddSummon_Click(object sender, EventArgs e)
    {
        AddSummonRequested?.Invoke(this, EventArgs.Empty);
    }

    private void chkUseAddStage_CheckedChanged(object sender, EventArgs e)
    {
        nudAddStage.Enabled = chkUseAddStage.Checked;
    }

    private void btnStageSummon_Click(object sender, EventArgs e)
    {
        StageSummonRequested?.Invoke(this, EventArgs.Empty);
    }
}
