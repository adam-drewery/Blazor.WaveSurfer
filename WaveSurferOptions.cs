namespace Blazor.WaveSurfer
{
    public class WaveSurferOptions
    {
        /// <summary>Required: an HTML element or selector where the waveform will be rendered.</summary>
        public string? Container { get; set; }

        /// <summary>The height of the waveform in pixels, or "auto" to fill the container height.</summary>
        public object? Height { get; set; }

        /// <summary>The color of the waveform.</summary>
        public object? WaveColor { get; set; }

        /// <summary>The color of the progress mask.</summary>
        public object? ProgressColor { get; set; }

        /// <summary>The color of the playback cursor.</summary>
        public string? CursorColor { get; set; }

        /// <summary>The cursor width.</summary>
        public double? CursorWidth { get; set; }

        /// <summary>If set, the waveform will be rendered with bars.</summary>
        public double? BarWidth { get; set; }

        /// <summary>Spacing between bars in pixels.</summary>
        public double? BarGap { get; set; }

        /// <summary>Rounded borders for bars.</summary>
        public double? BarRadius { get; set; }

        /// <summary>A vertical scaling factor for the waveform.</summary>
        public double? BarHeight { get; set; }

        /// <summary>Vertical bar alignment.</summary>
        public BarAlignment? BarAlign { get; set; }

        /// <summary>Minimum pixels per second of audio (i.e. the zoom level).</summary>
        public double? MinPxPerSec { get; set; }

        /// <summary>Stretch the waveform to fill the container, true by default.</summary>
        public bool? FillParent { get; set; }

        /// <summary>Audio URL.</summary>
        public string? Url { get; set; }

        /// <summary>Pre-computed audio data, arrays of floats for each channel.</summary>
        public List<List<double>>? Peaks { get; set; }

        /// <summary>Pre-computed audio duration in seconds.</summary>
        public double? Duration { get; set; }

        //// <summary>Use an existing media element instead of creating one.</summary>
        //// Excluded as it's better to handle on the JavaScript side.

        /// <summary>Whether to show default audio element controls.</summary>
        public bool? MediaControls { get; set; }

        /// <summary>Play the audio on load.</summary>
        public bool? Autoplay { get; set; }

        /// <summary>Pass false to disable clicks on the waveform.</summary>
        public bool? Interact { get; set; }

        /// <summary>Hide the scrollbar.</summary>
        public bool? HideScrollbar { get; set; }

        /// <summary>Audio rate, i.e. the playback speed.</summary>
        public double? AudioRate { get; set; }

        /// <summary>Automatically scroll the container to keep the current position in viewport.</summary>
        public bool? AutoScroll { get; set; }

        /// <summary>If autoScroll is enabled, keep the cursor in the center of the waveform during playback.</summary>
        public bool? AutoCenter { get; set; }

        /// <summary>Decoding sample rate. Doesn't affect the playback. Defaults to 8000.</summary>
        public double? SampleRate { get; set; } = 8000;

        /// <summary>Render each audio channel as a separate waveform.</summary>
        public List<WaveSurferOptions>? SplitChannels { get; set; }

        /// <summary>Stretch the waveform to the full height.</summary>
        public bool? Normalize { get; set; }

        //// <summary>The list of plugins to initialize on start.</summary>
        //// Excluded as it's better to handle on the JavaScript side.

        //// <summary>Custom render function.</summary>
        //// Excluded as it's better to handle on the JavaScript side.

        /// <summary>Options to pass to the fetch method.</summary>
        public HttpRequestMessage? FetchParams { get; set; }

        public enum BarAlignment
        {
            Top,
            Bottom
        }
    }
}