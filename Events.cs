using Blazor.InterOptimal;
using Microsoft.JSInterop;

namespace Blazor.WaveSurfer;

internal class Events
{
    private readonly dynamic _scriptObject;

    private Events(ScriptObject scriptObject) => _scriptObject = scriptObject;

    public static Events Setup(ScriptObject scriptObject)
    {
        return new Events(scriptObject);
    }

    public async Task WireUp(WaveSurfer receiver, string eventName)
    {
        var func = (dynamic args) => receiver.OnEvent(eventName, args);
        await _scriptObject.on(eventName, func);
    }
}