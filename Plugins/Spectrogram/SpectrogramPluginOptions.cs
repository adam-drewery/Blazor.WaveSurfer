namespace Blazor.WaveSurfer.Plugins.Spectrogram;

public class SpectrogramPluginOptions
{
    /// <summary>Some window functions have this extra value. (Between 0 and 1)</summary>
    public double? Alpha { get; set; }

    /// <summary>A 256 long array of 4-element arrays specifying r, g, b, and alpha.</summary>
    public double[][]? ColorMap { get; set; }

    /// <summary>Selector of element or element in which to render.</summary>
    public string? Container { get; set; }

    /// <summary>Number of samples to fetch to FFT. Must be a power of 2.</summary>
    public int? FftSamples { get; set; }

    /// <summary>Max frequency to scale spectrogram. Set this to samplerate/2 to draw whole range of spectrogram.</summary>
    public double? FrequencyMax { get; set; }

    /// <summary>Min frequency to scale spectrogram.</summary>
    public double? FrequencyMin { get; set; }

    /// <summary>Height of the spectrogram view in CSS pixels.</summary>
    public int? Height { get; set; }

    /// <summary>Set to true to display frequency labels.</summary>
    public bool? Labels { get; set; }

    /// <summary>Background color for frequency labels.</summary>
    public string? LabelsBackground { get; set; }

    /// <summary>Color for frequency labels.</summary>
    public string? LabelsColor { get; set; }

    /// <summary>Color for Hz frequency labels.</summary>
    public string? LabelsHzColor { get; set; }

    /// <summary>Size of the overlapping window. Must be less than fftSamples. Auto deduced from canvas size by default.</summary>
    public int? Noverlap { get; set; }

    /// <summary>Render a spectrogram for each channel independently when true.</summary>
    public bool? SplitChannels { get; set; }

    /// <summary>The window function to be used.</summary>
    public string? WindowFunc { get; set; }
}