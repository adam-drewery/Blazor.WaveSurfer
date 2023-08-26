namespace Blazor.WaveSurfer.Plugins.Regions;

public class RegionUpdatedEventArgs : System.EventArgs
{
    public Region? Region { get; init; }
}