using App.WinForms.Models;
using System.Reflection;

namespace App.WinForms.Controls;

public partial class EntityBrowserControl : UserControl
{
    private IReadOnlyList<BrowserRow> _rows = [];
    private CancellationTokenSource? _debounceCts;

    public EntityBrowserControl()
    {
        InitializeComponent();
        ConfigureGridDefaults();
    }

    public event EventHandler? LoadAllRequested;

    public event EventHandler? FilterRequested;

    public event EventHandler<BrowserRow?>? SelectedRowChanged;

    public Panel ActionsHostPanel => pnlActionsHost;

    public string SearchText => txtSearch.Text;

    public SearchMode CurrentSearchMode => rbSearchById.Checked ? SearchMode.ById : SearchMode.ByName;

    public void ConfigureColumns(IReadOnlyList<BrowserColumnDefinition> columns)
    {
        gridRecords.Columns.Clear();

        foreach (var column in columns)
        {
            var dataGridColumn = new DataGridViewTextBoxColumn
            {
                Name = column.Name,
                HeaderText = column.HeaderText,
                Width = column.Width,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };

            if (column.Fill)
            {
                dataGridColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            gridRecords.Columns.Add(dataGridColumn);
        }
    }

    public void SetRows(IReadOnlyList<BrowserRow> rows)
    {
        _rows = rows;

        gridRecords.RowCount = _rows.Count;
        gridRecords.CurrentCell = null;
        gridRecords.ClearSelection();

        // In VirtualMode visible cells can keep stale values when row count stays unchanged.
        // Force immediate repaint so filtering is reflected while typing.
        gridRecords.Invalidate();
        gridRecords.Refresh();

        SelectedRowChanged?.Invoke(this, null);
    }

    public void SetStatus(string status)
    {
        lblStatus.Text = status;
    }

    private void ConfigureGridDefaults()
    {
        gridRecords.VirtualMode = true;
        gridRecords.AllowUserToAddRows = false;
        gridRecords.AllowUserToDeleteRows = false;
        gridRecords.MultiSelect = false;
        gridRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridRecords.ReadOnly = true;
        gridRecords.RowHeadersVisible = false;
        gridRecords.AllowUserToResizeRows = false;
        gridRecords.RowTemplate.Resizable = DataGridViewTriState.False;
        gridRecords.AutoGenerateColumns = false;
        gridRecords.EnableHeadersVisualStyles = false;
        gridRecords.ColumnHeadersDefaultCellStyle.SelectionBackColor = gridRecords.ColumnHeadersDefaultCellStyle.BackColor;
        gridRecords.ColumnHeadersDefaultCellStyle.SelectionForeColor = gridRecords.ColumnHeadersDefaultCellStyle.ForeColor;
        gridRecords.AllowUserToOrderColumns = false;
        gridRecords.AllowUserToResizeColumns = false;
        TryEnableDoubleBuffering(gridRecords);
    }

    private static void TryEnableDoubleBuffering(DataGridView grid)
    {
        // DataGridView.DoubleBuffered is protected - enable via reflection for smoother scrolling/repaint.
        var property = typeof(DataGridView).GetProperty(
            "DoubleBuffered",
            BindingFlags.Instance | BindingFlags.NonPublic);

        property?.SetValue(grid, true);
    }

    private BrowserRow? GetSelectedRow()
    {
        if (gridRecords.CurrentCell is null)
        {
            return null;
        }

        var rowIndex = gridRecords.CurrentCell.RowIndex;
        if (rowIndex < 0 || rowIndex >= _rows.Count)
        {
            return null;
        }

        return _rows[rowIndex];
    }

    private async void txtSearch_TextChanged(object sender, EventArgs e)
    {
        _debounceCts?.Cancel();
        _debounceCts?.Dispose();
        _debounceCts = new CancellationTokenSource();

        try
        {
            await Task.Delay(120, _debounceCts.Token);
            FilterRequested?.Invoke(this, EventArgs.Empty);
        }
        catch (OperationCanceledException)
        {
            // Ignore stale text changes.
        }
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
        FilterRequested?.Invoke(this, EventArgs.Empty);
    }

    private void btnLoadAll_Click(object sender, EventArgs e)
    {
        LoadAllRequested?.Invoke(this, EventArgs.Empty);
    }

    private void gridRecords_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
    {
        if (e.RowIndex < 0 || e.RowIndex >= _rows.Count)
        {
            return;
        }

        var row = _rows[e.RowIndex];
        if (e.ColumnIndex < 0 || e.ColumnIndex >= row.Values.Length)
        {
            return;
        }

        e.Value = row.Values[e.ColumnIndex];
    }

    private void gridRecords_SelectionChanged(object sender, EventArgs e)
    {
        SelectedRowChanged?.Invoke(this, GetSelectedRow());
    }

    private void rbSearchBy_CheckedChanged(object sender, EventArgs e)
    {
        FilterRequested?.Invoke(this, EventArgs.Empty);
    }
}
