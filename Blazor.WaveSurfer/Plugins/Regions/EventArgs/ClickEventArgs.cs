namespace Blazor.WaveSurfer.Plugins.Regions.EventArgs;

public class ClickEventArgs : System.EventArgs
{
    public ClickEventArgs(MouseEvent? mouseEvent) => MouseEvent = mouseEvent;
        
    public MouseEvent? MouseEvent { get; init; }
}