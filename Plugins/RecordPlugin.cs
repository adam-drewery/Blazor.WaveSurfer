using Blazor.WaveSurfer.Plugins.Options;
using Microsoft.JSInterop;

namespace Blazor.WaveSurfer.Plugins;

public class RecordPlugin : GenericPlugin
{
    public override IJSObjectReference JsObject { get; }

    private RecordPlugin(IJSObjectReference jsObject) => JsObject = jsObject;

    public static async Task<RecordPlugin> Create(IJSRuntime jsRuntime, RecordPluginOptions options)
    {
        var javascriptObject = await jsRuntime.InvokeAsync<IJSObjectReference>("RecordPlugin.create", options);
        return new RecordPlugin(javascriptObject);
    }
}