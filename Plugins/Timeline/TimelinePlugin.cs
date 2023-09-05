using Microsoft.JSInterop;

namespace Blazor.WaveSurfer.Plugins.Timeline;

public class TimelinePlugin : GenericPlugin
{
    public TimelinePlugin(object scriptObject) : base(scriptObject) { }
    
    public static async Task<TimelinePlugin> Create(IJSRuntime jsRuntime, TimelinePluginOptions options)
    {
        var javascriptObject = await jsRuntime.InvokeAsync<IJSObjectReference>("TimelinePlugin.create", options);
        return new TimelinePlugin(javascriptObject);
    }
}