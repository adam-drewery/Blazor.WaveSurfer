using Microsoft.JSInterop;

namespace Blazor.WaveSurfer.Plugins;

public abstract class GenericPlugin
{
    public abstract IJSObjectReference JsObject { get; }
}