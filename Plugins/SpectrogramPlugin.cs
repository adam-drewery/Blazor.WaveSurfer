using Blazor.WaveSurfer.Plugins.Options;
using Microsoft.JSInterop;

namespace Blazor.WaveSurfer.Plugins;

public class SpectrogramPlugin : GenericPlugin
{
    public override IJSObjectReference JsObject { get; }

    private SpectrogramPlugin(IJSObjectReference jsObject) => JsObject = jsObject;

    public static async Task<SpectrogramPlugin> Create(IJSRuntime jsRuntime, SpectrogramPluginOptions options)
    {
        var javascriptObject = await jsRuntime.InvokeAsync<IJSObjectReference>("SpectrogramPlugin.create", options);
        return new SpectrogramPlugin(javascriptObject);
    }
}