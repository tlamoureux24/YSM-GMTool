using System.ComponentModel;

namespace App.WinForms.Controls;

public partial class MonsterActionsControl : UserControl
{
    private const string SpawnModeAtYourPlace = "At your place";
    private const string SpawnModeAtSelectedPlayer = "At selected player place";
    private const string SpawnModeAtSpecificCoordinates = "At specific coordinates";

    public MonsterActionsControl()
    {
        InitializeComponent();
        cmbSpawnMode.SelectedIndex = 0;
        ToggleInputsByMode();
    }

    public event EventHandler? CreateCommandRequested;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int MonsterId
    {
        get => (int)nudMonsterId.Value;
        set
        {
            if (value <= 0)
            {
                return;
            }

            var clamped = Math.Min(value, (int)nudMonsterId.Maximum);
            nudMonsterId.Value = clamped;
        }
    }

    public int Amount => (int)nudAmount.Value;

    public string SpawnMode => (cmbSpawnMode.SelectedItem as string) ?? SpawnModeAtYourPlace;

    public int X => (int)nudX.Value;

    public int Y => (int)nudY.Value;

    public int Layer => (int)nudLayer.Value;

    public bool UseLifetime => chkUseLifetime.Checked;

    public int MinutesLifetime => Math.Max(1, (int)nudMinutesLifetime.Value);

    private void btnCreateSpawnCommand_Click(object sender, EventArgs e)
    {
        CreateCommandRequested?.Invoke(this, EventArgs.Empty);
    }

    private void cmbSpawnMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        ToggleInputsByMode();
    }

    private void chkUseLifetime_CheckedChanged(object sender, EventArgs e)
    {
        if (chkUseLifetime.Checked && nudMinutesLifetime.Value < 1)
        {
            nudMinutesLifetime.Value = 1;
        }
        else if (!chkUseLifetime.Checked)
        {
            nudMinutesLifetime.Value = -1;
        }

        ToggleInputsByMode();
    }

    private void ToggleInputsByMode()
    {
        var selectedMode = SpawnMode;
        var coordinatesMode = selectedMode.Equals(SpawnModeAtSpecificCoordinates, StringComparison.OrdinalIgnoreCase);
        var playerMode = selectedMode.Equals(SpawnModeAtSelectedPlayer, StringComparison.OrdinalIgnoreCase);

        nudX.Enabled = coordinatesMode;
        nudY.Enabled = coordinatesMode;
        nudLayer.Enabled = coordinatesMode;

        var canUseLifetime = coordinatesMode || playerMode;
        chkUseLifetime.Enabled = canUseLifetime;

        if (!canUseLifetime)
        {
            chkUseLifetime.Checked = false;
            nudMinutesLifetime.Value = -1;
        }

        nudMinutesLifetime.Enabled = canUseLifetime && chkUseLifetime.Checked;
    }
}
