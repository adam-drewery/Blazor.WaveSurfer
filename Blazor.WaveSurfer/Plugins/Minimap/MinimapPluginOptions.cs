namespace Blazor.WaveSurfer.Plugins.Minimap;

public class MinimapPluginOptions
{
    /// <summary>Position to insert the minimap.</summary>
    public string? InsertPosition { get; set; }

    /// <summary>Color of the minimap overlay.</summary>
    public string? OverlayColor { get; set; }

    // Note: The documentation also mentions "& WaveSurferOptions". 
    // This implies that MinimapPluginOptions might inherit or include properties from WaveSurferOptions.
    // If you have a WaveSurferOptions class, you might consider inheriting from it or including its properties.
}