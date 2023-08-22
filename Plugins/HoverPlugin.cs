using Blazor.WaveSurfer.Plugins.Options;
using Microsoft.JSInterop;

namespace Blazor.WaveSurfer.Plugins;

public class HoverPlugin : GenericPlugin
{
    public override IJSObjectReference JsObject { get; }

    private HoverPlugin(IJSObjectReference jsObject) => JsObject = jsObject;

    public static async Task<HoverPlugin> Create(IJSRuntime jsRuntime, HoverPluginOptions options)
    {
        var javascriptObject = await jsRuntime.InvokeAsync<IJSObjectReference>("HoverPlugin.create", options);
        return new HoverPlugin(javascriptObject);
    }
}