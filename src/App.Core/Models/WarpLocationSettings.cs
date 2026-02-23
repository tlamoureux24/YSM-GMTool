namespace App.Core.Models;

public sealed class WarpLocationSettings
{
    public int X { get; set; }

    public int Y { get; set; }

    public string Name { get; set; } = string.Empty;

    public WarpLocationSettings Clone() => new()
    {
        X = X,
        Y = Y,
        Name = Name
    };
}
