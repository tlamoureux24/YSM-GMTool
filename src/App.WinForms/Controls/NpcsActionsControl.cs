using System.ComponentModel;
using System.Drawing;

namespace App.WinForms.Controls;

public partial class NpcsActionsControl : UserControl
{
    public NpcsActionsControl()
    {
        InitializeComponent();
        ApplyReadabilityPalette();
    }

    public event EventHandler? CreateAddNpcToWorldCommandRequested;

    public event EventHandler? CreateShowNpcCommandRequested;

    public event EventHandler? CreateWarpToNpcCommandRequested;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int NpcId
    {
        get => (int)nudNpcId.Value;
        set
        {
            if (value <= 0)
            {
                return;
            }

            var clamped = Math.Min(value, (int)nudNpcId.Maximum);
            nudNpcId.Value = clamped;
        }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string NpcName
    {
        get => txtNpcName.Text;
        set => txtNpcName.Text = value ?? string.Empty;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string ContactScript
    {
        get => txtContactScript.Text;
        set => txtContactScript.Text = value ?? string.Empty;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int NpcX
    {
        get => (int)nudX.Value;
        set
        {
            var clamped = Math.Clamp(value, (int)nudX.Minimum, (int)nudX.Maximum);
            nudX.Value = clamped;
        }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int NpcY
    {
        get => (int)nudY.Value;
        set
        {
            var clamped = Math.Clamp(value, (int)nudY.Minimum, (int)nudY.Maximum);
            nudY.Value = clamped;
        }
    }

    public int Layer => (int)nudLayer.Value;

    public int VisibleFlag => chkHideNpc.Checked ? 1 : 0;

    private void ApplyReadabilityPalette()
    {
        var page = Color.FromArgb(25, 28, 34);
        var panel = Color.FromArgb(34, 39, 48);
        var panelAlt = Color.FromArgb(39, 45, 56);
        var text = Color.FromArgb(235, 238, 245);

        BackColor = page;
        gbNpcActions.BackColor = panel;
        gbNpcActions.ForeColor = text;
        gbSelectedNpc.BackColor = panelAlt;
        gbCommands.BackColor = panelAlt;
        gbSelectedNpc.ForeColor = text;
        gbCommands.ForeColor = text;
    }

    private void btnAddNpcToWorld_Click(object sender, EventArgs e)
    {
        CreateAddNpcToWorldCommandRequested?.Invoke(this, EventArgs.Empty);
    }

    private void btnShowNpc_Click(object sender, EventArgs e)
    {
        CreateShowNpcCommandRequested?.Invoke(this, EventArgs.Empty);
    }

    private void btnWarpToNpc_Click(object sender, EventArgs e)
    {
        CreateWarpToNpcCommandRequested?.Invoke(this, EventArgs.Empty);
    }
}
