using Microsoft.JSInterop;

namespace Blazor.WaveSurfer;

internal class Events
{
    private static bool _configured;
    private readonly IJSRuntime _jsRuntime;
    private readonly IJSObjectReference _jsObject;

    private Events(IJSRuntime jsRuntime, IJSObjectReference jsObject)
    {
        _jsRuntime = jsRuntime;
        _jsObject = jsObject;
    }

    public static async Task<Events> Setup(IJSRuntime jsRuntime, IJSObjectReference jsObject)
    {
        if (!_configured)
            await Configure(jsRuntime);
        
        _configured = true;
        
        return new Events(jsRuntime, jsObject);
    }

    private static async Task Configure(IJSRuntime jsRuntime)
    {
        // setup utility js function first
        const string setupCallback = 
            @"window.setupCallback = function(eventReceiver, eventEmitter, eventName) {
            eventEmitter.on(eventName, function(args) {
                eventReceiver.invokeMethodAsync('OnEvent', eventName, args);
            });
        };";

        const string blobWrapper =
            @"window.blobWrapper = function(instance, methodName, ...args) {
            const processedArgs = args.map(arg => {
                if (arg instanceof Uint8Array) {
                    return new Blob([arg]);
                }
                return arg;
            });

            if (instance && typeof instance[methodName] === 'function') {
                instance[methodName](...processedArgs);
            } else {
                console.error(`Method ${methodName} is not defined on the provided instance.`);
            }
        };";

        await jsRuntime.InvokeVoidAsync("eval", setupCallback);
        await jsRuntime.InvokeVoidAsync("eval", blobWrapper);
    }

    public async Task WireUp(object receiver, string eventName)
    {
        var @ref = DotNetObjectReference.Create(receiver);
        await _jsRuntime.InvokeVoidAsync("setupCallback", @ref, _jsObject, eventName);
    }
}