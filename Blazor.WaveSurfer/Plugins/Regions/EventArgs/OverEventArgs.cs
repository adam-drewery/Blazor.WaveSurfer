namespace Blazor.WaveSurfer.Plugins.Regions.EventArgs;

public class OverEventArgs : System.EventArgs
{
    public OverEventArgs(MouseEvent? mouseEvent) => MouseEvent = mouseEvent;

    public MouseEvent? MouseEvent { get; init; }
}