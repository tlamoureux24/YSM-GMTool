using System.ComponentModel;
using System.Drawing;

namespace App.WinForms.Controls;

public partial class WarpActionsControl : UserControl
{
    public WarpActionsControl()
    {
        InitializeComponent();
        ApplyReadabilityPalette();
    }

    public event EventHandler? WarpToYouRequested;

    public event EventHandler? WarpRequested;

    public event EventHandler? WarpToSomeoneRequested;

    public event EventHandler? AddWarpRequested;

    public event EventHandler? RemoveSelectedWarpRequested;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int SelectedX
    {
        get => (int)nudSelectedX.Value;
        set
        {
            var clamped = Math.Clamp(value, (int)nudSelectedX.Minimum, (int)nudSelectedX.Maximum);
            nudSelectedX.Value = clamped;
        }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int SelectedY
    {
        get => (int)nudSelectedY.Value;
        set
        {
            var clamped = Math.Clamp(value, (int)nudSelectedY.Minimum, (int)nudSelectedY.Maximum);
            nudSelectedY.Value = clamped;
        }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int AddX => (int)nudAddX.Value;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int AddY => (int)nudAddY.Value;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string LocationName => txtLocationName.Text.Trim();

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool OpenWorldmapEnabled
    {
        get => btnOpenWorldmap.Enabled;
        set => btnOpenWorldmap.Enabled = value;
    }

    public void PrimeAddFieldsFromSelected()
    {
        nudAddX.Value = nudSelectedX.Value;
        nudAddY.Value = nudSelectedY.Value;
    }

    public void ClearAddFields()
    {
        txtLocationName.Clear();
    }

    private void ApplyReadabilityPalette()
    {
        var page = Color.FromArgb(25, 28, 34);
        var panel = Color.FromArgb(34, 39, 48);
        var panelAlt = Color.FromArgb(39, 45, 56);
        var text = Color.FromArgb(235, 238, 245);

        BackColor = page;
        gbWarpActions.BackColor = panel;
        gbWarpActions.ForeColor = text;
        gbWarpCommands.BackColor = panelAlt;
        gbWarpCommands.ForeColor = text;
        gbManageWarp.BackColor = panelAlt;
        gbManageWarp.ForeColor = text;
    }

    private void btnWarpToYou_Click(object sender, EventArgs e)
    {
        WarpToYouRequested?.Invoke(this, EventArgs.Empty);
    }

    private void btnWarp_Click(object sender, EventArgs e)
    {
        WarpRequested?.Invoke(this, EventArgs.Empty);
    }

    private void btnWarpToSomeone_Click(object sender, EventArgs e)
    {
        WarpToSomeoneRequested?.Invoke(this, EventArgs.Empty);
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        AddWarpRequested?.Invoke(this, EventArgs.Empty);
    }

    private void btnRemoveSelected_Click(object sender, EventArgs e)
    {
        RemoveSelectedWarpRequested?.Invoke(this, EventArgs.Empty);
    }
}
