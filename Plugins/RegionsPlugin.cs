using Microsoft.JSInterop;

namespace Blazor.WaveSurfer.Plugins;

public class RegionsPlugin : GenericPlugin
{
    public override IJSObjectReference JsObject { get; }

    private RegionsPlugin(IJSObjectReference jsObject) => JsObject = jsObject;

    public static async Task<RegionsPlugin> CreateAsync(IJSRuntime jsRuntime)
    {
        var javascriptObject = await jsRuntime.InvokeAsync<IJSObjectReference>("RegionsPlugin.create");
        return new RegionsPlugin(javascriptObject);
    }

    public async Task<SingleRegion> AddRegionAsync(RegionParams options) =>
        await JsObject.InvokeAsync<SingleRegion>("addRegion", options);

    public async Task ClearRegionsAsync() => await JsObject.InvokeVoidAsync("clearRegions");

    public async Task DestroyAsync() => await JsObject.InvokeVoidAsync("destroy");

    // todo how to do omit<>
    //public async Task EnableDragSelection(OmitRegionParams options) => await JsObject.InvokeVoidAsync("enableDragSelection", options);

    public async Task<SingleRegion[]> GetRegionsAsync() => await JsObject.InvokeAsync<SingleRegion[]>("getRegions");

    public async Task InitAsync(WaveSurfer wavesurfer) => await JsObject.InvokeVoidAsync("init", wavesurfer);
}