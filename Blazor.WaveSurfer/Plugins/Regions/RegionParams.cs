namespace Blazor.WaveSurfer.Plugins.Regions;

public class RegionParams
{
    /// <summary>The color of the region (CSS color)</summary>
    public string? Color { get; set; }

    /// <summary>Content string or HTML element</summary>
    public object? Content { get; set; }  // Can be string or HTMLElement

    /// <summary>Allow/dissallow dragging the region</summary>
    public bool? Drag { get; set; }

    /// <summary>The end position of the region (in seconds)</summary>
    public double? End { get; set; }

    /// <summary>The id of the region, any string</summary>
    public string? Id { get; set; }

    /// <summary>Max length when resizing (in seconds)</summary>
    public double? MaxLength { get; set; }

    /// <summary>Min length when resizing (in seconds)</summary>
    public double? MinLength { get; set; }

    /// <summary>Allow/dissallow resizing the region</summary>
    public bool? Resize { get; set; }

    /// <summary>The start position of the region (in seconds)</summary>
    public double Start { get; set; }
}