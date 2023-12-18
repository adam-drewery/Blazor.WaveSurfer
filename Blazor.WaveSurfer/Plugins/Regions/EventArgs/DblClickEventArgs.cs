namespace Blazor.WaveSurfer.Plugins.Regions.EventArgs;

public class DblClickEventArgs : System.EventArgs
{
    public DblClickEventArgs(MouseEvent? mouseEvent) => MouseEvent = mouseEvent;

    public MouseEvent? MouseEvent { get; init; }
}