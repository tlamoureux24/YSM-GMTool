namespace App.WinForms.Controls;

public partial class PlayerCheckerActionsControl : UserControl
{
    public PlayerCheckerActionsControl()
    {
        InitializeComponent();
    }

    public event EventHandler? CreateCheckCommandRequested;

    public event EventHandler? LoadInventoryRequested;

    public event EventHandler? LoadWarehouseRequested;

    public event EventHandler? OpenInfosRequested;

    public string PlayerName => txtPlayerName.Text.Trim();

    private void btnCreateCheckCommand_Click(object sender, EventArgs e)
    {
        CreateCheckCommandRequested?.Invoke(this, EventArgs.Empty);
    }

    private void btnLoadInventory_Click(object sender, EventArgs e)
    {
        LoadInventoryRequested?.Invoke(this, EventArgs.Empty);
    }

    private void btnLoadWh_Click(object sender, EventArgs e)
    {
        LoadWarehouseRequested?.Invoke(this, EventArgs.Empty);
    }

    private void btnOpenInfos_Click(object sender, EventArgs e)
    {
        OpenInfosRequested?.Invoke(this, EventArgs.Empty);
    }
}
