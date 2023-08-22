namespace Blazor.WaveSurfer.Plugins.Options;

public class EnvelopePluginOptions
{
    /// <summary>Fill color of the drag point.</summary>
    public string? DragPointFill { get; set; }

    /// <summary>Size of the drag point.</summary>
    public double? DragPointSize { get; set; }

    /// <summary>Stroke color of the drag point.</summary>
    public string? DragPointStroke { get; set; }

    /// <summary>End position of the fade-in effect in seconds.</summary>
    public double? FadeInEnd { get; set; }

    /// <summary>Start position of the fade-in effect in seconds.</summary>
    public double? FadeInStart { get; set; }

    /// <summary>End position of the fade-out effect in seconds.</summary>
    public double? FadeOutEnd { get; set; }

    /// <summary>Start position of the fade-out effect in seconds.</summary>
    public double? FadeOutStart { get; set; }

    /// <summary>Color of the envelope line.</summary>
    public string? LineColor { get; set; }

    /// <summary>Width of the envelope line.</summary>
    public string? LineWidth { get; set; }

    /// <summary>Volume of the envelope.</summary>
    public double? Volume { get; set; }
}