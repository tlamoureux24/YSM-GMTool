using Serilog;
using System.Runtime.CompilerServices;

namespace App.WinForms.Layout;

internal static class UiLayoutPolicy
{
    private const int SectionBottomPaddingPx = 10;

    private sealed class ButtonSnapshot
    {
        public required Size FixedSize { get; init; }
        public required AnchorStyles OriginalAnchor { get; init; }
    }

    private static readonly ConditionalWeakTable<Button, ButtonSnapshot> ButtonSnapshots = new();

    public static void ApplyFixedButtonSizes(Control root)
    {
        foreach (var control in Descendants(root))
        {
            if (control is not Button button)
            {
                continue;
            }

            ApplyFixedButtonSize(button);
        }
    }

    public static void FitActionSections(Control root)
    {
        if (!root.IsHandleCreated || root.IsDisposed)
        {
            return;
        }

        if (root is ScrollableControl scrollable)
        {
            scrollable.AutoScroll = false;
        }

        var actionControls = root.Controls
            .Cast<Control>()
            .Where(IsActionControlRoot)
            .ToList();

        if (actionControls.Count == 0 && IsActionControlRoot(root))
        {
            actionControls.Add(root);
        }

        foreach (var actionControl in actionControls)
        {
            FitSingleActionControl(actionControl);
        }
    }

    public static void ValidateNoSectionClipping(Control root)
    {
        if (!root.IsHandleCreated || root.IsDisposed)
        {
            return;
        }

        var sections = Descendants(root)
            .Where(static c => c is GroupBox && c.Visible && !c.IsDisposed)
            .ToList();

        foreach (var section in sections)
        {
            var overflow = GetVerticalOverflow(section);
            if (overflow <= 0)
            {
                continue;
            }

            section.Height += overflow;
            Log.Warning(
                "Auto-layout adjusted clipped section {SectionName} by {Overflow}px.",
                section.Name,
                overflow);
        }

        root.PerformLayout();
    }

    public static int GetRequiredMainFormMinHeight(Form form, IEnumerable<Control> actionHosts, int currentMinHeight)
    {
        var requiredMinHeight = currentMinHeight;
        foreach (var host in actionHosts)
        {
            if (host.IsDisposed
                || !host.IsHandleCreated
                || host.ClientSize.Height <= 0
                || !IsActuallyVisible(host))
            {
                continue;
            }

            var requiredHostContentHeight = GetRequiredContentHeight(host);
            if (requiredHostContentHeight <= 0)
            {
                continue;
            }

            // Translate required host height to required form height.
            var formToHostDelta = Math.Max(form.Height - host.ClientSize.Height, 0);
            var candidate = requiredHostContentHeight + formToHostDelta + 8;
            requiredMinHeight = Math.Max(requiredMinHeight, candidate);
        }

        return requiredMinHeight;
    }

    public static int MeasureRequiredHeight(Control control)
    {
        if (control.IsDisposed)
        {
            return 0;
        }

        if (ShouldIgnoreInMeasurements(control))
        {
            return 0;
        }

        if (control is GroupBox groupBox)
        {
            return MeasureGroupBoxHeight(groupBox);
        }

        if (!control.HasChildren)
        {
            return Math.Max(control.MinimumSize.Height, GetLeafPreferredHeight(control));
        }

        return Math.Max(control.MinimumSize.Height, GetRequiredContentHeight(control));
    }

    private static void ApplyFixedButtonSize(Button button)
    {
        if (!ButtonSnapshots.TryGetValue(button, out var snapshot))
        {
            var fixedSize = button.Size;
            if (fixedSize.Width <= 0 || fixedSize.Height <= 0)
            {
                fixedSize = button.GetPreferredSize(Size.Empty);
            }

            snapshot = new ButtonSnapshot
            {
                FixedSize = fixedSize,
                OriginalAnchor = button.Anchor
            };
            ButtonSnapshots.Add(button, snapshot);
        }

        button.AutoSize = false;
        button.MinimumSize = snapshot.FixedSize;
        button.MaximumSize = snapshot.FixedSize;
        button.Size = snapshot.FixedSize;

        if (button.Dock != DockStyle.None)
        {
            button.Dock = DockStyle.None;
        }

        if (button.Parent is TableLayoutPanel)
        {
            button.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            return;
        }

        var anchor = snapshot.OriginalAnchor;
        if ((anchor & AnchorStyles.Left) != 0 && (anchor & AnchorStyles.Right) != 0)
        {
            anchor &= ~AnchorStyles.Right;
        }

        if ((anchor & AnchorStyles.Top) != 0 && (anchor & AnchorStyles.Bottom) != 0)
        {
            anchor &= ~AnchorStyles.Bottom;
        }

        if (anchor == AnchorStyles.None)
        {
            anchor = AnchorStyles.Top | AnchorStyles.Left;
        }

        button.Anchor = anchor;
    }

    private static void FitSingleActionControl(Control actionControl)
    {
        if (!actionControl.Visible || actionControl.IsDisposed)
        {
            return;
        }

        actionControl.SuspendLayout();
        try
        {
            for (var pass = 0; pass < 4; pass++)
            {
                var changed = false;

                var containers = Descendants(actionControl)
                    .Where(static c => c != null && c.Visible && !c.IsDisposed && IsFitContainer(c))
                    .OrderByDescending(GetDepth)
                    .ToList();

                foreach (var container in containers)
                {
                    var desired = MeasureRequiredHeight(container);
                    if (desired <= 0)
                    {
                        continue;
                    }

                    desired = Math.Max(container.MinimumSize.Height, desired);
                    if (Math.Abs(container.Height - desired) <= 1)
                    {
                        continue;
                    }

                    container.Height = desired;
                    changed = true;
                }

                var actionDesired = Math.Max(actionControl.MinimumSize.Height, MeasureRequiredHeight(actionControl));
                if (Math.Abs(actionControl.Height - actionDesired) > 1)
                {
                    actionControl.Height = actionDesired;
                    changed = true;
                }

                if (!changed)
                {
                    break;
                }

                actionControl.PerformLayout();
            }
        }
        finally
        {
            actionControl.ResumeLayout(true);
        }
    }

    private static int GetRequiredContentHeight(Control host)
    {
        var maxBottom = host.Padding.Top;
        foreach (Control child in host.Controls)
        {
            if (!child.Visible || child.IsDisposed)
            {
                continue;
            }

            if (ShouldIgnoreInMeasurements(child))
            {
                continue;
            }

            var childRequired = MeasureRequiredHeight(child);
            var childBottom = child.Top + childRequired + child.Margin.Bottom;
            maxBottom = Math.Max(maxBottom, childBottom);
        }

        return maxBottom + host.Padding.Bottom;
    }

    private static int GetVerticalOverflow(Control section)
    {
        var required = MeasureRequiredHeight(section);
        var current = Math.Max(section.Height, 0);
        if (required <= current)
        {
            return 0;
        }

        return required - current;
    }

    private static int MeasureGroupBoxHeight(GroupBox groupBox)
    {
        var contentBottom = GetBottomMostLeaf(groupBox);
        if (contentBottom <= 0)
        {
            contentBottom = GetRequiredContentHeight(groupBox) - groupBox.Padding.Bottom;
        }

        return Math.Max(
            groupBox.MinimumSize.Height,
            contentBottom + groupBox.Padding.Bottom + SectionBottomPaddingPx);
    }

    private static int GetBottomMostLeaf(Control ancestor)
    {
        var maxBottom = 0;
        foreach (var node in Descendants(ancestor))
        {
            if (ReferenceEquals(node, ancestor) || !node.Visible || node.IsDisposed)
            {
                continue;
            }

            if (ShouldIgnoreInMeasurements(node))
            {
                continue;
            }

            // Skip pure containers; we want actual content controls.
            if (node.HasChildren && node is not Button)
            {
                continue;
            }

            var relativeBottom = GetBottomRelativeToAncestor(node, ancestor);
            maxBottom = Math.Max(maxBottom, relativeBottom);
        }

        return maxBottom;
    }

    private static int GetBottomRelativeToAncestor(Control node, Control ancestor)
    {
        var bottom = node.Bottom + node.Margin.Bottom;
        var parent = node.Parent;
        while (parent is not null && parent != ancestor)
        {
            bottom += parent.Top;
            parent = parent.Parent;
        }

        return bottom;
    }

    private static int GetLeafPreferredHeight(Control control)
    {
        if (control is Button button && ButtonSnapshots.TryGetValue(button, out var snapshot))
        {
            return snapshot.FixedSize.Height;
        }

        var preferred = control.GetPreferredSize(Size.Empty).Height;
        if (preferred > 0)
        {
            return preferred;
        }

        return control.Height;
    }

    private static bool ShouldIgnoreInMeasurements(Control control)
    {
        return control is DataGridView or SplitContainer or TabControl;
    }

    private static bool IsFitContainer(Control control)
    {
        return control is GroupBox
            || control is UserControl
            || control is TableLayoutPanel
            || control is FlowLayoutPanel
            || control is Panel;
    }

    private static bool IsActionControlRoot(Control control)
    {
        if (!control.Visible || control.IsDisposed)
        {
            return false;
        }

        if (control is not UserControl)
        {
            return false;
        }

        var typeName = control.GetType().Name;
        return typeName.EndsWith("ActionsControl", StringComparison.Ordinal);
    }

    private static int GetDepth(Control control)
    {
        var depth = 0;
        for (var current = control.Parent; current is not null; current = current.Parent)
        {
            depth++;
        }

        return depth;
    }

    private static bool IsActuallyVisible(Control control)
    {
        for (Control? current = control; current is not null; current = current.Parent)
        {
            if (!current.Visible)
            {
                return false;
            }
        }

        return true;
    }

    private static IEnumerable<Control> Descendants(Control root)
    {
        var stack = new Stack<Control>();
        stack.Push(root);

        while (stack.Count > 0)
        {
            var current = stack.Pop();
            yield return current;

            for (var i = current.Controls.Count - 1; i >= 0; i--)
            {
                stack.Push(current.Controls[i]);
            }
        }
    }
}
