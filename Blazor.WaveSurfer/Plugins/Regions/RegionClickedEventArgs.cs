namespace Blazor.WaveSurfer.Plugins.Regions;

public class RegionClickedEventArgs : System.EventArgs
{
    public Region? Region { get; init; }
}