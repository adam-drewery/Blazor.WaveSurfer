using Blazor.JsInterop.Dynamic;

namespace Blazor.WaveSurfer.Plugins.Regions;

public class Region
{
    private readonly dynamic _scriptObject;

    public Region(DynamicJsObject scriptObject) => _scriptObject = scriptObject;

    public string? Id => _scriptObject.id;
    
    public double Start => _scriptObject.start;
    
    public double End => _scriptObject.end;
    
    public bool Drag => _scriptObject.drag;
    
    public bool Resize => _scriptObject.resize;
    
    public string? Color => _scriptObject.color;
    
    public double MinLength => _scriptObject.minLength;
    
    public double? MaxLength => _scriptObject.maxLength;
    
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