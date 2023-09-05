using Microsoft.JSInterop;

namespace Blazor.WaveSurfer.Plugins.Envelope;

public class EnvelopePlugin : GenericPlugin
{
    public EnvelopePlugin(object scriptObject) : base(scriptObject) { }
    
    public static async Task<EnvelopePlugin> Create(IJSRuntime jsRuntime, EnvelopePluginOptions options)
    {
        var javascriptObject = await jsRuntime.InvokeAsync<IJSObjectReference>("EnvelopePlugin.create", options);
        return new EnvelopePlugin(javascriptObject);
    }
}