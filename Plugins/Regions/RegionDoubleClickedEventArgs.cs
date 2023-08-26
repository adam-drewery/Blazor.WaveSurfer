namespace Blazor.WaveSurfer.Plugins.Regions;

public class RegionDoubleClickedEventArgs : System.EventArgs
{
    public Region? Region { get; init; }
        
    public MouseEvent? MouseEvent { get; init; }
}