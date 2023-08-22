using Blazor.WaveSurfer.Plugins.Options;
using Microsoft.JSInterop;

namespace Blazor.WaveSurfer.Plugins;

public class TimelinePlugin : GenericPlugin
{
    public override IJSObjectReference JsObject { get; }

    private TimelinePlugin(IJSObjectReference jsObject) => JsObject = jsObject;

    public static async Task<TimelinePlugin> Create(IJSRuntime jsRuntime, TimelinePluginOptions options)
    {
        var javascriptObject = await jsRuntime.InvokeAsync<IJSObjectReference>("TimelinePlugin.create", options);
        return new TimelinePlugin(javascriptObject);
    }
}