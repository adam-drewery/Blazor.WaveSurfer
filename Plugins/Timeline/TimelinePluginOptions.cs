namespace Blazor.WaveSurfer.Plugins.Timeline;

public class TimelinePluginOptions
{
    /// <summary>HTML element or selector for a timeline container.</summary>
    public string? Container { get; set; }

    /// <summary>The duration of the timeline in seconds.</summary>
    public double? Duration { get; set; }

    /// <summary>Callback to format time into a suitable label.</summary>
    public Func<double, string>? FormatTimeCallback { get; set; }

    /// <summary>The height of the timeline in pixels.</summary>
    public int? Height { get; set; }

    /// <summary>Position to insert the timeline.</summary>
    public string? InsertPosition { get; set; }

    /// <summary>Interval between numeric labels in seconds.</summary>
    public double? PrimaryLabelInterval { get; set; }

    /// <summary>Interval between numeric labels in timeIntervals.</summary>
    public double? PrimaryLabelSpacing { get; set; }

    /// <summary>Interval between secondary numeric labels in seconds.</summary>
    public double? SecondaryLabelInterval { get; set; }

    /// <summary>Interval between secondary numeric labels in timeIntervals.</summary>
    public double? SecondaryLabelSpacing { get; set; }

    /// <summary>Custom inline style for the container.</summary>
    public string? Style { get; set; }

    /// <summary>Interval between ticks in seconds.</summary>
    public double? TimeInterval { get; set; }
}