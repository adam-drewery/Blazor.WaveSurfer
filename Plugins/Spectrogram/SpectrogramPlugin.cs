using Microsoft.JSInterop;

namespace Blazor.WaveSurfer.Plugins.Spectrogram;

public class SpectrogramPlugin : GenericPlugin
{
    public SpectrogramPlugin(object scriptObject) : base(scriptObject) { }
    
    public static async Task<SpectrogramPlugin> Create(IJSRuntime jsRuntime, SpectrogramPluginOptions options)
    {
        var javascriptObject = await jsRuntime.InvokeAsync<IJSObjectReference>("SpectrogramPlugin.create", options);
        return new SpectrogramPlugin(javascriptObject);
    }
}