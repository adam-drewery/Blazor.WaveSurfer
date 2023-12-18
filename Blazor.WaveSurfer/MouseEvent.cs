namespace Blazor.WaveSurfer;

public class MouseEvent
{
    /// <summary>Returns true if the alt key was down when the mouse event was fired.</summary>
    public bool? AltKey { get; init; }

    /// <summary>The button number that was pressed (if applicable) when the mouse event was fired.</summary>
    public int? Button { get; init; }

    /// <summary>The buttons being pressed (if any) when the mouse event was fired.</summary>
    public int? Buttons { get; init; }

    /// <summary>The X coordinate of the mouse pointer in local (DOM content) coordinates.</summary>
    public double? ClientX { get; init; }

    /// <summary>The Y coordinate of the mouse pointer in local (DOM content) coordinates.</summary>
    public double? ClientY { get; init; }

    /// <summary>Returns true if the control key was down when the mouse event was fired.</summary>
    public bool? CtrlKey { get; init; }

    /// <summary>Returns true if the meta key was down when the mouse event was fired.</summary>
    public bool? MetaKey { get; init; }

    /// <summary>The X coordinate of the mouse pointer relative to the position of the last mousemove event.</summary>
    public double? MovementX { get; init; }

    /// <summary>The Y coordinate of the mouse pointer relative to the position of the last mousemove event.</summary>
    public double? MovementY { get; init; }

    /// <summary>The X coordinate of the mouse pointer relative to the position of the padding edge of the target node.</summary>
    public double? OffsetX { get; init; }

    /// <summary>The Y coordinate of the mouse pointer relative to the position of the padding edge of the target node.</summary>
    public double? OffsetY { get; init; }

    /// <summary>The X coordinate of the mouse pointer relative to the whole document.</summary>
    public double? PageX { get; init; }

    /// <summary>The Y coordinate of the mouse pointer relative to the whole document.</summary>
    public double? PageY { get; init; }

    //// <summary>The secondary target for the event, if there is one.</summary>
    ////public object? RelatedTarget { get; init; } // This might need a more specific type.

    /// <summary>The X coordinate of the mouse pointer in global (screen) coordinates.</summary>
    public double? ScreenX { get; init; }

    /// <summary>The Y coordinate of the mouse pointer in global (screen) coordinates.</summary>
    public double? ScreenY { get; init; }

    /// <summary>Returns true if the shift key was down when the mouse event was fired.</summary>
    public bool? ShiftKey { get; init; }

    /// <summary>Alias for MouseEvent.clientX.</summary>
    public double? X { get; init; }

    /// <summary>Alias for MouseEvent.clientY.</summary>
    public double? Y { get; init; }
}