namespace Blazor.WaveSurfer.Plugins.Regions.EventArgs;

public class LeaveEventArgs : System.EventArgs
{
    public LeaveEventArgs(MouseEvent? mouseEvent) => MouseEvent = mouseEvent;

    public MouseEvent? MouseEvent { get; init; }
}