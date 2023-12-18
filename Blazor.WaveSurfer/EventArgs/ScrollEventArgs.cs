namespace Blazor.WaveSurfer.EventArgs;

public class ScrollEventArgs : System.EventArgs
{
    public double VisibleStartTime { get; init; }
    public double VisibleEndTime { get; init; }
}