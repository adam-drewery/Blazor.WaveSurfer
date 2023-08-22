using Microsoft.JSInterop;

namespace Blazor.WaveSurfer.Plugins;

public class RegionsPlugin : GenericPlugin
{
    public override IJSObjectReference JsObject { get; }

    private RegionsPlugin(IJSObjectReference jsObject) => JsObject = jsObject;

    public static async Task<RegionsPlugin> Create(IJSRuntime jsRuntime)
    {
        var javascriptObject = await jsRuntime.InvokeAsync<IJSObjectReference>("RegionsPlugin.create");
        return new RegionsPlugin(javascriptObject);
    }

    public async Task<SingleRegion> AddRegion(RegionParams options) =>
        await JsObject.InvokeAsync<SingleRegion>("addRegion", options);

    public async Task ClearRegions() => await JsObject.InvokeVoidAsync("clearRegions");

    public async Task Destroy() => await JsObject.InvokeVoidAsync("destroy");

    // todo how to do omit<>
    //public async Task EnableDragSelection(OmitRegionParams options) => await JsObject.InvokeVoidAsync("enableDragSelection", options);

    public async Task<SingleRegion[]> GetRegions() => await JsObject.InvokeAsync<SingleRegion[]>("getRegions");

    public async Task Init(WaveSurfer wavesurfer) => await JsObject.InvokeVoidAsync("init", wavesurfer);

    // ... Other methods and properties ...
}