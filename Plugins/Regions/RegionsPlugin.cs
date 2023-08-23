using System.Text.Json;
using Blazor.WaveSurfer.Plugins.Regions.EventArgs;
using Microsoft.JSInterop;

namespace Blazor.WaveSurfer.Plugins.Regions;

public class RegionsPlugin : GenericPlugin
{
    private readonly Events _helper;
    public override IJSObjectReference JsObject { get; }

    private RegionsPlugin(IJSObjectReference jsObject, Events helper)
    {
        _helper = helper;
        JsObject = jsObject;
    }

    public static async Task<RegionsPlugin> CreateAsync(IJSRuntime jsRuntime)
    {
        var jsObject = await jsRuntime.InvokeAsync<IJSObjectReference>("RegionsPlugin.create");
        var helper = await Events.Setup(jsRuntime, jsObject);
        var plugin = new RegionsPlugin(jsObject, helper);
        
        await helper.WireUp(plugin, "click");
        await helper.WireUp(plugin, "dblclick");
        await helper.WireUp(plugin, "leave");
        await helper.WireUp(plugin, "over");
        await helper.WireUp(plugin, "play");
        await helper.WireUp(plugin, "remove");
        await helper.WireUp(plugin, "update");
        await helper.WireUp(plugin, "update-end");

        return plugin;
    }

    public async Task<SingleRegion> AddRegionAsync(RegionParams options) =>
        await JsObject.InvokeAsync<SingleRegion>("addRegion", options);

    public async Task ClearRegionsAsync() => await JsObject.InvokeVoidAsync("clearRegions");

    public async Task DestroyAsync() => await JsObject.InvokeVoidAsync("destroy");

    // todo how to do omit<>
    //public async Task EnableDragSelection(OmitRegionParams options) => await JsObject.InvokeVoidAsync("enableDragSelection", options);

    public async Task<SingleRegion[]> GetRegionsAsync() => await JsObject.InvokeAsync<SingleRegion[]>("getRegions");

    public async Task InitAsync(WaveSurfer wavesurfer) => await JsObject.InvokeVoidAsync("init", wavesurfer);
    
    public event ClickEventHandler? Clicked;
    public event DblClickEventHandler? DoubleClicked;
    public event LeaveEventHandler? Left;
    public event OverEventHandler? Over;
    public event EventHandler? Played;
    public event EventHandler? Removed;
    public event EventHandler? Updated;
    public event EventHandler? UpdateEnded;

    public delegate Task ClickEventHandler(object sender, ClickEventArgs e);
    public delegate Task DblClickEventHandler(object sender, DblClickEventArgs e);
    public delegate Task LeaveEventHandler(object sender, LeaveEventArgs e);
    public delegate Task OverEventHandler(object sender, OverEventArgs e);
    
    // ReSharper disable once CyclomaticComplexity
    [JSInvokable]
    public virtual Task OnEvent(string eventName, JsonElement args)
    {
        switch (eventName)
        {
            case "click":
                return Clicked?.Invoke(this, new ClickEventArgs(args.Deserialize<MouseEvent>()))
                    ?? Task.CompletedTask;
            case "dblclick":
                return DoubleClicked?.Invoke(this, new DblClickEventArgs(args.Deserialize<MouseEvent>()))
                    ?? Task.CompletedTask;
            case "leave":
                return Left?.Invoke(this, new LeaveEventArgs(args.Deserialize<MouseEvent>()))
                    ?? Task.CompletedTask;
            case "over":
                return Over?.Invoke(this, new OverEventArgs(args.Deserialize<MouseEvent>()))
                    ?? Task.CompletedTask;
            case "play":
                Played?.Invoke(this, System.EventArgs.Empty);
                break;
            case "remove":
                Removed?.Invoke(this, System.EventArgs.Empty);
                break;
            case "update":
                Updated?.Invoke(this, System.EventArgs.Empty);
                break;
            case "update-end":
                UpdateEnded?.Invoke(this, System.EventArgs.Empty);
                break;
        }

        return Task.CompletedTask;
    }
}