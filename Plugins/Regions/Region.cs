namespace Blazor.WaveSurfer.Plugins.Regions;

public class Region
{
    public string? Id { get; set; }
    
    public double Start { get; set; }
    
    public double End { get; set; }
    
    public bool Drag { get; set; }
    
    public bool Resize { get; set; }
    
    public string? Color { get; set; }
    
    public double MinLength { get; set; } = 0;
    
    public double? MaxLength { get; set; }
    
    // public event ClickEventHandler? Clicked;
    // public event DblClickEventHandler? DoubleClicked;
    // public event LeaveEventHandler? Left;
    // public event OverEventHandler? Over;
    // public event EventHandler? Played;
    // public event EventHandler? Removed;
    // public event EventHandler? Updated;
    // public event EventHandler? UpdateEnded;
    //
    // public delegate Task ClickEventHandler(object sender, ClickEventArgs e);
    // public delegate Task DblClickEventHandler(object sender, DblClickEventArgs e);
    // public delegate Task LeaveEventHandler(object sender, LeaveEventArgs e);
    // public delegate Task OverEventHandler(object sender, OverEventArgs e);
    
    // ReSharper disable once CyclomaticComplexity
    // [JSInvokable]
    // public virtual Task OnEvent(string eventName, JsonElement args)
    // {
    //     switch (eventName)
    //     {
    //         case "click":
    //             return Clicked?.Invoke(this, new ClickEventArgs(args.Deserialize<MouseEvent>()))
    //                 ?? Task.CompletedTask;
    //         case "dblclick":
    //             return DoubleClicked?.Invoke(this, new DblClickEventArgs(args.Deserialize<MouseEvent>()))
    //                 ?? Task.CompletedTask;
    //         case "leave":
    //             return Left?.Invoke(this, new LeaveEventArgs(args.Deserialize<MouseEvent>()))
    //                 ?? Task.CompletedTask;
    //         case "over":
    //             return Over?.Invoke(this, new OverEventArgs(args.Deserialize<MouseEvent>()))
    //                 ?? Task.CompletedTask;
    //         case "play":
    //             Played?.Invoke(this, System.EventArgs.Empty);
    //             break;
    //         case "remove":
    //             Removed?.Invoke(this, System.EventArgs.Empty);
    //             break;
    //         case "update":
    //             Updated?.Invoke(this, System.EventArgs.Empty);
    //             break;
    //         case "update-end":
    //             UpdateEnded?.Invoke(this, System.EventArgs.Empty);
    //             break;
    //     }
    //
    //     return Task.CompletedTask;
    // }
}