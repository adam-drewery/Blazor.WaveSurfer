namespace Blazor.WaveSurfer.EventArgs;

public class SeekingEventArgs : System.EventArgs
{
    public double CurrentTime { get; init; }
}