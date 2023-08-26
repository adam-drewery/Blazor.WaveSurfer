using Blazor.InterOptimal;
using Microsoft.JSInterop;

namespace Blazor.WaveSurfer.Plugins.Regions;

public class RegionsPlugin : GenericPlugin
{
    private readonly dynamic _scriptObject;
    
    public override IJSObjectReference JsObject { get; }

    private RegionsPlugin(IJSObjectReference jsObject, dynamic scriptObject)
    {
        _scriptObject = scriptObject;
        JsObject = jsObject;
    }

    public static async Task<RegionsPlugin> CreateAsync(IJSRuntime jsRuntime)
    {
        var jsObject = await jsRuntime.InvokeAsync<IJSObjectReference>("RegionsPlugin.create");
        var scriptObject = await ScriptObject.CreateAsync(jsRuntime, jsObject);
        var plugin = new RegionsPlugin(jsObject, scriptObject);
        
        
        await plugin.WireUp( "region-clicked");
        await plugin.WireUp( "region-created");
        await plugin.WireUp( "region-double-clicked");
        await plugin.WireUp( "region-in");
        await plugin.WireUp( "region-out");
        await plugin.WireUp( "region-updated");

        return plugin;
    }
    
    public async Task WireUp(string eventName)
    {
        var func = (dynamic args) => OnEvent(eventName, args);
        await _scriptObject.on(eventName, func);
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
    
    public async Task<Region> AddRegionAsync(RegionParams options) => await _scriptObject.addRegion(options);

    public async Task ClearRegionsAsync() => await _scriptObject.clearRegions();

    public async Task DestroyAsync() => await _scriptObject.destroy();

    // todo how to do omit<>
    //public async Task EnableDragSelection(OmitRegionParams options) => await JsObject.InvokeVoidAsync("enableDragSelection", options);

    public async Task<Region[]> GetRegionsAsync() => await _scriptObject.getRegions();

    public async Task InitAsync(WaveSurfer wavesurfer) => await _scriptObject.init(wavesurfer);
}