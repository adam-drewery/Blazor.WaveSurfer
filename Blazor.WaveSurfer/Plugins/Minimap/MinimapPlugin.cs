using Microsoft.JSInterop;

namespace Blazor.WaveSurfer.Plugins.Minimap;

public class MinimapPlugin : GenericPlugin
{
    public override IJSObjectReference JsObject { get; }

    private MinimapPlugin(IJSObjectReference jsObject) => JsObject = jsObject;

    public static async Task<MinimapPlugin> Create(IJSRuntime jsRuntime, MinimapPluginOptions options)
    {
        var javascriptObject = await jsRuntime.InvokeAsync<IJSObjectReference>("MiniMapPlugin.create", options);
        return new MinimapPlugin(javascriptObject);
    }
}