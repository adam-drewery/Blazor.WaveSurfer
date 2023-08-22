namespace Blazor.WaveSurfer.Plugins.Options;

public class RecordPluginOptions
{
    /// <summary>The audio bitrate to use when recording audio.</summary>
    public int? AudioBitsPerSecond { get; set; }

    /// <summary>The MIME type to use when recording audio.</summary>
    public string? MimeType { get; set; }

    /// <summary>Whether to render the recorded audio, true by default.</summary>
    public bool? RenderRecordedAudio { get; set; }
}