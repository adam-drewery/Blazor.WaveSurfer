using Microsoft.JSInterop;

namespace Blazor.WaveSurfer.Plugins.Record;

public class RecordPlugin : GenericPlugin
{
    public RecordPlugin(object scriptObject) : base(scriptObject) { }
    
    public static async Task<RecordPlugin> Create(IJSRuntime jsRuntime, RecordPluginOptions options)
    {
        var javascriptObject = await jsRuntime.InvokeAsync<IJSObjectReference>("RecordPlugin.create", options);
        return new RecordPlugin(javascriptObject);
    }
}