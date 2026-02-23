namespace App.WinForms.Forms;

using App.WinForms.Layout;

public partial class AboutForm : Form
{
    public AboutForm()
    {
        InitializeComponent();
        ApplyDialogIcon();
        Shown += AboutForm_Shown;
    }

    private void AboutForm_Shown(object? sender, EventArgs e)
    {
        if (!IsHandleCreated || IsDisposed)
        {
            return;
        }

        BeginInvoke((Action)(() => UiLayoutPolicy.ApplyFixedButtonSizes(this)));
    }

    private void ApplyDialogIcon()
    {
        try
        {
            using var exeIcon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            if (exeIcon is not null)
            {
                Icon = (Icon)exeIcon.Clone();
                picIcon.Image = exeIcon.ToBitmap();
                ShowIcon = true;
            }
        }
        catch
        {
            // Keep default if extraction fails.
        }
    }
}
