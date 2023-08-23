namespace Blazor.WaveSurfer.Plugins.Hover;

public class HoverPluginOptions
{
    /// <summary>Background color of the hover label.</summary>
    public string? LabelBackground { get; set; }

    /// <summary>Color of the hover label.</summary>
    public string? LabelColor { get; set; }

    /// <summary>Size of the hover label, can be a string or number.</summary>
    public object? LabelSize { get; set; } // Using object to accommodate both string and number

    /// <summary>Color of the hover line.</summary>
    public string? LineColor { get; set; }

    /// <summary>Width of the hover line, can be a string or number.</summary>
    public object? LineWidth { get; set; } // Using object to accommodate both string and number
}