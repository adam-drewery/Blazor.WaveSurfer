using Microsoft.JSInterop;

namespace Blazor.WaveSurfer.Plugins.Hover;

public class HoverPlugin : GenericPlugin
{
    public HoverPlugin(object scriptObject) : base(scriptObject) { }
    
    public static async Task<HoverPlugin> Create(IJSRuntime jsRuntime, HoverPluginOptions options)
    {
        var javascriptObject = await jsRuntime.InvokeAsync<IJSObjectReference>("HoverPlugin.create", options);
        return new HoverPlugin(javascriptObject);
    }
}