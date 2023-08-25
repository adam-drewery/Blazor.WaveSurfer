using Blazor.InterOptimal;
using Microsoft.JSInterop;

namespace Blazor.WaveSurfer.Plugins.Regions;

public class RegionsPlugin : GenericPlugin
{
    public override IJSObjectReference JsObject { get; }

    private RegionsPlugin(IJSObjectReference jsObject)
    {
        JsObject = jsObject;
    }

    public static async Task<RegionsPlugin> CreateAsync(IJSRuntime jsRuntime)
    {
        var jsObject = await jsRuntime.InvokeAsync<IJSObjectReference>("RegionsPlugin.create");
        var scriptObject = await ScriptObject.CreateAsync(jsRuntime, jsObject);
        var helper = Events.Setup(scriptObject);
        var plugin = new RegionsPlugin(jsObject);
        
        await helper.WireUp(plugin, "region-clicked");
        await helper.WireUp(plugin, "region-created");
        await helper.WireUp(plugin, "region-double-clicked");
        await helper.WireUp(plugin, "region-in");
        await helper.WireUp(plugin, "region-out");
        await helper.WireUp(plugin, "region-updated");

        return plugin;
    }
    
    public event RegionClickedEventHandler? RegionClicked;
    public event RegionCreatedEventHandler? RegionCreated;
    public event RegionDoubleClickedEventHandler? RegionDoubleClicked;
    public event RegionInEventHandler? RegionIn;
    public event RegionOutEventHandler? RegionOut;
    public event RegionUpdatedEventHandler? RegionUpdated;

    public delegate Task RegionClickedEventHandler(object sender, RegionClickedEventArgs e);
    public delegate Task RegionCreatedEventHandler(object sender, RegionCreatedEventArgs e);
    public delegate Task RegionDoubleClickedEventHandler(object sender, RegionDoubleClickedEventArgs e);
    public delegate Task RegionInEventHandler(object sender, RegionInEventArgs e);
    public delegate Task RegionOutEventHandler(object sender, RegionOutEventArgs e);
    public delegate Task RegionUpdatedEventHandler(object sender, RegionUpdatedEventArgs e);

    [JSInvokable]
    // ReSharper disable once CyclomaticComplexity
    public virtual Task OnEvent(string eventName, Region region)
    {
        switch (eventName)
        {
            case "region-clicked":
                var clickedArgs = new RegionClickedEventArgs { Region = region };
                return RegionClicked?.Invoke(this, clickedArgs) ?? Task.CompletedTask;

            case "region-created":
                var createdArgs = new RegionCreatedEventArgs { Region = region };
                return RegionCreated?.Invoke(this, createdArgs) ?? Task.CompletedTask;

            case "region-double-clicked":
                var doubleClickedArgs = new RegionDoubleClickedEventArgs { Region = region };
                return RegionDoubleClicked?.Invoke(this, doubleClickedArgs) ?? Task.CompletedTask;

            case "region-in":
                var inArgs = new RegionInEventArgs { Region = region };
                return RegionIn?.Invoke(this, inArgs) ?? Task.CompletedTask;

            case "region-out":
                var outArgs = new RegionOutEventArgs { Region = region };
                return RegionOut?.Invoke(this, outArgs) ?? Task.CompletedTask;

            case "region-updated":
                var updatedArgs = new RegionUpdatedEventArgs { Region = region };
                return RegionUpdated?.Invoke(this, updatedArgs) ?? Task.CompletedTask;
        }

        return Task.CompletedTask;
    }
    
    public async Task<Region> AddRegionAsync(RegionParams options) =>
        await JsObject.InvokeAsync<Region>("addRegion", options);

    public async Task ClearRegionsAsync() => await JsObject.InvokeVoidAsync("clearRegions");

    public async Task DestroyAsync() => await JsObject.InvokeVoidAsync("destroy");

    // todo how to do omit<>
    //public async Task EnableDragSelection(OmitRegionParams options) => await JsObject.InvokeVoidAsync("enableDragSelection", options);

    public async Task<Region[]> GetRegionsAsync() => await JsObject.InvokeAsync<Region[]>("getRegions");

    public async Task InitAsync(WaveSurfer wavesurfer) => await JsObject.InvokeVoidAsync("init", wavesurfer);
}

public class RegionCreatedEventArgs : System.EventArgs
{
    public Region? Region { get; init; }
}

public class RegionDoubleClickedEventArgs : System.EventArgs
{
    public Region? Region { get; init; }
        
    public MouseEvent? MouseEvent { get; init; }
}

public class RegionInEventArgs : System.EventArgs
{
    public Region? Region { get; init; }
}

public class RegionOutEventArgs : System.EventArgs
{
    public Region? Region { get; init; }
}

public class RegionUpdatedEventArgs : System.EventArgs
{
    public Region? Region { get; init; }
}

public class RegionClickedEventArgs : System.EventArgs
{
    public Region? Region { get; init; }
}