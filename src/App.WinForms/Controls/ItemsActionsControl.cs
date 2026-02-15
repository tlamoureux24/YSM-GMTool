using System.ComponentModel;

namespace App.WinForms.Controls;

public partial class ItemsActionsControl : UserControl
{
    private static readonly string[] WearSlotItems =
    [
        "-1 - WEAR_NONE / WEAR_CANTWEAR",
        "0 - WEAR_WEAPON",
        "1 - WEAR_SHIELD",
        "2 - WEAR_ARMOR",
        "3 - WEAR_HELM",
        "4 - WEAR_GLOVE",
        "5 - WEAR_BOOTS",
        "6 - WEAR_BELT",
        "7 - WEAR_MANTLE",
        "8 - WEAR_ARMULET",
        "9 - WEAR_RING",
        "10 - WEAR_SECOND_RING",
        "11 - WEAR_EAR",
        "12 - WEAR_FACE",
        "13 - WEAR_DECO_BACKPACK",
        "14 - WEAR_DECO_WEAPON",
        "15 - WEAR_DECO_SHIELD",
        "16 - WEAR_DECO_ARMOR",
        "17 - WEAR_DECO_HELM",
        "18 - WEAR_DECO_GLOVE",
        "19 - WEAR_DECO_BOOTS",
        "20 - WEAR_DECO_MANTLE",
        "21 - WEAR_DECO_SHOULDER",
        "22 - WEAR_RIDE_ITEM",
        "23 - WEAR_BAG_SLOT",
        "24 - WEAR_DECO_BOOSTER",
        "25 - WEAR_DECO_EMBLEM",
        "26 - WEAR_SECOND_EAR",
        "27 - WEAR_CHAOSSTONE",
        "28 - WEAR_MEDAL",
        "29 - WEAR_MASK",
        "30 - WEAR_WINGS",
        "31 - WEAR_SPARE_WEAPON",
        "32 - WEAR_SPARE_SHIELD",
        "33 - WEAR_SPARE_DECO_WEAPON",
        "34 - WEAR_SPARE_DECO_SHIELD",
        "94 - WEAR_TWOFINGER_RING",
        "99 - WEAR_TWOHAND",
        "100 - WEAR_SKILL",
        "200 - WEAR_SUMMON_ONLY"
    ];

    public ItemsActionsControl()
    {
        InitializeComponent();
        cmbWearSlot.Items.Clear();
        cmbWearSlot.Items.AddRange(WearSlotItems);
        cmbWearSlot.SelectedIndex = Array.FindIndex(WearSlotItems, x => x.StartsWith("0 ", StringComparison.Ordinal));
        if (cmbWearSlot.SelectedIndex < 0)
        {
            cmbWearSlot.SelectedIndex = 0;
        }
        rbTargetOwn.Checked = true;
        ToggleStatusFlag();
    }

    public event EventHandler? AddYourselfRequested;

    public event EventHandler? GiveOtherPlayerRequested;

    public event EventHandler? EditLevelRequested;

    public event EventHandler? EditEnhanceRequested;

    public event EventHandler? ChangeAppearanceRequested;

    public event EventHandler? ChangeItemCodeRequested;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int ItemId
    {
        get => (int)nudItemId.Value;
        set
        {
            if (value <= 0)
            {
                return;
            }

            var clamped = Math.Min(value, (int)nudItemId.Maximum);
            nudItemId.Value = clamped;
        }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string ItemName
    {
        get => txtItemName.Text;
        set => txtItemName.Text = value ?? string.Empty;
    }

    public int Amount => (int)nudAmount.Value;

    public int Level => (int)nudLevel.Value;

    public int Enhance => (int)nudEnhance.Value;

    public bool UseStatusFlag => chkUseStatusFlag.Checked;

    public int StatusFlag => UseStatusFlag ? (int)nudStatusFlag.Value : 0;

    public int WearSlotIndex
    {
        get
        {
            if (cmbWearSlot.SelectedItem is not string selected)
            {
                return 0;
            }

            var separator = selected.IndexOf(' ');
            if (separator <= 0)
            {
                return 0;
            }

            var left = selected[..separator];
            return int.TryParse(left, out var slot) ? slot : 0;
        }
    }

    public bool ApplyToOtherPlayer => rbTargetOther.Checked;

    public int ModifyLevel => (int)nudModifyLevel.Value;

    public int ModifyEnhance => (int)nudModifyEnhance.Value;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int ModifyItemCode
    {
        get => (int)nudModifyItemCode.Value;
        set
        {
            if (value <= 0)
            {
                return;
            }

            var clamped = Math.Min(value, (int)nudModifyItemCode.Maximum);
            nudModifyItemCode.Value = clamped;
        }
    }

    private void btnAddYourself_Click(object sender, EventArgs e)
    {
        AddYourselfRequested?.Invoke(this, EventArgs.Empty);
    }

    private void btnGiveOtherPlayer_Click(object sender, EventArgs e)
    {
        GiveOtherPlayerRequested?.Invoke(this, EventArgs.Empty);
    }

    private void btnEditLevel_Click(object sender, EventArgs e)
    {
        EditLevelRequested?.Invoke(this, EventArgs.Empty);
    }

    private void btnEditEnhance_Click(object sender, EventArgs e)
    {
        EditEnhanceRequested?.Invoke(this, EventArgs.Empty);
    }

    private void btnChangeAppearance_Click(object sender, EventArgs e)
    {
        ChangeAppearanceRequested?.Invoke(this, EventArgs.Empty);
    }

    private void btnChangeItemCode_Click(object sender, EventArgs e)
    {
        ChangeItemCodeRequested?.Invoke(this, EventArgs.Empty);
    }

    private void chkUseStatusFlag_CheckedChanged(object sender, EventArgs e)
    {
        ToggleStatusFlag();
    }

    private void ToggleStatusFlag()
    {
        nudStatusFlag.Enabled = chkUseStatusFlag.Checked;
        if (!chkUseStatusFlag.Checked)
        {
            nudStatusFlag.Value = 0;
        }
    }
}
