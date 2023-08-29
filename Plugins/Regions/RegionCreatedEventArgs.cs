namespace Blazor.WaveSurfer.Plugins.Regions;

public class RegionCreatedEventArgs : System.EventArgs
{
    public Region? Region { get; init; }
}