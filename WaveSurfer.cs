using Blazor.WaveSurfer.EventArgs;
using Blazor.WaveSurfer.Plugins;
using Microsoft.JSInterop;

namespace Blazor.WaveSurfer;

public class WaveSurfer : IAsyncDisposable
{
    private readonly IJSRuntime _jsRuntime;
    private readonly IJSObjectReference _jsObject;

    private WaveSurfer(IJSObjectReference jsObject, IJSRuntime jsRuntime)
    {
        _jsObject = jsObject;
        _jsRuntime = jsRuntime;
    }

    public static async Task<WaveSurfer> CreateAsync(IJSRuntime jsRuntime, WaveSurferOptions options)
    {
        // setup utility js function first
        const string function = @"
        window.setupCallback = function(dotNetReference, waveSurferInstance, eventName, callbackMethod) {
            waveSurferInstance.on(eventName, function(args) {
                dotNetReference.invokeMethodAsync(callbackMethod, args);
            });
        };";

        await jsRuntime.InvokeVoidAsync("eval", function);
        var javascriptObject = await jsRuntime.InvokeAsync<IJSObjectReference>("WaveSurfer.create", options);
        var surfer = new WaveSurfer(javascriptObject, jsRuntime);
        
        await surfer.WireUp("audioprocess", nameof(OnAudioProcessed));
        await surfer.WireUp("click", nameof(OnClicked));
        await surfer.WireUp("decode", nameof(OnDecoded));
        await surfer.WireUp("destroy", nameof(OnDestroyed));
        await surfer.WireUp("drag", nameof(OnDragged));
        await surfer.WireUp("finish", nameof(OnFinished));
        await surfer.WireUp("interaction", nameof(OnInteracted));
        await surfer.WireUp("load", nameof(OnLoaded));
        await surfer.WireUp("loading", nameof(OnLoading));
        await surfer.WireUp("pause", nameof(OnPaused));
        await surfer.WireUp("play", nameof(OnPlayed));
        await surfer.WireUp("ready", nameof(OnReady));
        await surfer.WireUp("redraw", nameof(OnRedrawn));
        await surfer.WireUp("scroll", nameof(OnScrolled));
        await surfer.WireUp("seek", nameof(OnSeeking));
        await surfer.WireUp("timeupdate", nameof(OnTimeUpdated));
        await surfer.WireUp("zoom", nameof(OnZoomed));

        return surfer;
    }

    private async Task WireUp(string eventName, string callbackMethod)
    {
        var @ref = DotNetObjectReference.Create(this);
        await _jsRuntime.InvokeVoidAsync("setupCallback", @ref, _jsObject, eventName, callbackMethod);
    }

    public event AudioProcessEventHandler? AudioProcessed;
    public event ClickEventHandler? Clicked;
    public event DecodeEventHandler? Decoded;
    public event EventHandler? Destroyed;
    public event DragEventHandler? Dragged;
    public event EventHandler? Finished;
    public event InteractionEventHandler? Interacted;
    public event LoadEventHandler? Loaded;
    public event LoadingEventHandler? Loading;
    public event EventHandler? Paused;
    public event EventHandler? Played;
    public event ReadyEventHandler? Ready;
    public event EventHandler? Redrawn;
    public event ScrollEventHandler? Scrolled;
    public event SeekingEventHandler? Seeking;
    public event TimeUpdateEventHandler? TimeUpdated;
    public event ZoomEventHandler? Zoomed;

    // Delegates
    public delegate Task AudioProcessEventHandler(object sender, AudioProcessEventArgs e);
    public delegate Task ClickEventHandler(object sender, ClickEventArgs e);
    public delegate Task DecodeEventHandler(object sender, DecodeEventArgs e);
    public delegate Task DragEventHandler(object sender, DragEventArgs e);
    public delegate Task InteractionEventHandler(object sender, InteractionEventArgs e);
    public delegate Task LoadEventHandler(object sender, LoadEventArgs e);
    public delegate Task LoadingEventHandler(object sender, LoadingEventArgs e);
    public delegate Task ReadyEventHandler(object sender, ReadyEventArgs e);
    public delegate Task ScrollEventHandler(object sender, ScrollEventArgs e);
    public delegate Task SeekingEventHandler(object sender, SeekingEventArgs e);
    public delegate Task TimeUpdateEventHandler(object sender, TimeUpdateEventArgs e);
    public delegate Task ZoomEventHandler(object sender, ZoomEventArgs e);
    
    public async Task PlayAsync() => await _jsObject.InvokeVoidAsync("play");
    public async Task PauseAsync() => await _jsObject.InvokeVoidAsync("pause");
    public async Task StopAsync() => await _jsObject.InvokeVoidAsync("stop");
    public async Task DestroyAsync() => await _jsObject.InvokeVoidAsync("destroy");
    public async Task EmptyAsync() => await _jsObject.InvokeVoidAsync("empty");
    public async Task<double[][]> ExportPeaksAsync() => await _jsObject.InvokeAsync<double[][]>("exportPeaks");
    public async Task<double> GetCurrentTimeAsync() => await _jsObject.InvokeAsync<double>("getCurrentTime");
    public async Task<byte[]> GetDecodedDataAsync() => await _jsObject.InvokeAsync<byte[]>("getDecodedData");        
    public async Task<double> GetDurationAsync() => await _jsObject.InvokeAsync<double>("getDuration");
    public async Task<string> GetMediaElementAsync() => await _jsObject.InvokeAsync<string>("getMediaElement");        
    public async Task<bool> GetMutedAsync() => await _jsObject.InvokeAsync<bool>("getMuted");
    public async Task<double> GetPlaybackRateAsync() => await _jsObject.InvokeAsync<double>("getPlaybackRate");
    public async Task<double> GetScrollAsync() => await _jsObject.InvokeAsync<double>("getScroll");
    public async Task<double> GetVolumeAsync() => await _jsObject.InvokeAsync<double>("getVolume");
    public async Task<string> GetWrapperAsync() => await _jsObject.InvokeAsync<string>("getWrapper");        
    public async Task<bool> IsPlayingAsync() => await _jsObject.InvokeAsync<bool>("isPlaying");
    public async Task LoadAsync(string url) => await _jsObject.InvokeVoidAsync("load", url);
    public async Task LoadAsync(string url, double[] peaks) => await _jsObject.InvokeVoidAsync("load", url, peaks);
    public async Task LoadAudioAsync(string url, byte[] blob) => await _jsObject.InvokeVoidAsync("loadAudio", url, blob);
    public async Task LoadBlobAsync(byte[] blob) => await _jsObject.InvokeVoidAsync("loadBlob", blob);
    public async Task PlayPauseAsync() => await _jsObject.InvokeVoidAsync("playPause");
    public async Task SeekToAsync(double progress) => await _jsObject.InvokeVoidAsync("seekTo", progress);
    public async Task SetMutedAsync(bool muted) => await _jsObject.InvokeVoidAsync("setMuted", muted);
    public async Task SetOptionsAsync(WaveSurferOptions options) => await _jsObject.InvokeVoidAsync("setOptions", options);
    public async Task SetPlaybackRateAsync(double rate) => await _jsObject.InvokeVoidAsync("setPlaybackRate", rate);
    public async Task SetSinkIdAsync(string sinkId) => await _jsObject.InvokeVoidAsync("setSinkId", sinkId);
    public async Task SetTimeAsync(double time) => await _jsObject.InvokeVoidAsync("setTime", time);
    public async Task SetVolumeAsync(double volume) => await _jsObject.InvokeVoidAsync("setVolume", volume);
    public async Task SkipAsync(double seconds) => await _jsObject.InvokeVoidAsync("skip", seconds);
    public async Task ToggleInteractionAsync(bool isInteractive) => await _jsObject.InvokeVoidAsync("toggleInteraction", isInteractive);
    public async Task ZoomAsync(double minPxPerSec) => await _jsObject.InvokeVoidAsync("zoom", minPxPerSec);

    public async Task<GenericPlugin> RegisterPluginAsync(GenericPlugin plugin) 
        => await _jsObject.InvokeAsync<GenericPlugin>("registerPlugin", plugin.JsObject);
    
    public void Dispose() => _jsObject.InvokeVoidAsync("destroy");
        
    public ValueTask DisposeAsync()
    {
        Dispose();
        return _jsObject.DisposeAsync();
    }
    
    [JSInvokable] public virtual Task OnAudioProcessed(double currentTime) => AudioProcessed?.Invoke(this, new AudioProcessEventArgs { CurrentTime = currentTime }) ?? Task.CompletedTask;
    [JSInvokable] public virtual Task OnClicked(double relativeX) => Clicked?.Invoke(this, new ClickEventArgs { RelativeX = relativeX }) ?? Task.CompletedTask;
    [JSInvokable] public virtual Task OnDecoded() => Decoded?.Invoke(this, new DecodeEventArgs()) ?? Task.CompletedTask;
    [JSInvokable] public virtual void OnDestroyed() => Destroyed?.Invoke(this, System.EventArgs.Empty);
    [JSInvokable] public virtual Task OnDragged(double relativeX) => Dragged?.Invoke(this, new DragEventArgs { RelativeX = relativeX }) ?? Task.CompletedTask;
    [JSInvokable] public virtual void OnFinished() => Finished?.Invoke(this, System.EventArgs.Empty);
    [JSInvokable] public virtual Task OnInteracted(double newTime) => Interacted?.Invoke(this, new InteractionEventArgs { NewTime = newTime }) ?? Task.CompletedTask;
    [JSInvokable] public virtual Task OnLoaded(string url) => Loaded?.Invoke(this, new LoadEventArgs { Url = url }) ?? Task.CompletedTask;
    [JSInvokable] public virtual Task OnLoading(int progress) => Loading?.Invoke(this, new LoadingEventArgs { Percent = progress }) ?? Task.CompletedTask;
    [JSInvokable] public virtual void OnPaused() => Paused?.Invoke(this, System.EventArgs.Empty);
    [JSInvokable] public virtual void OnPlayed() => Played?.Invoke(this, System.EventArgs.Empty);
    [JSInvokable] public virtual Task OnReady() => Ready?.Invoke(this, new ReadyEventArgs()) ?? Task.CompletedTask;
    [JSInvokable] public virtual void OnRedrawn() => Redrawn?.Invoke(this, System.EventArgs.Empty);
    [JSInvokable] public virtual Task OnScrolled(double visibleStartTime, double visibleEndTime) => Scrolled?.Invoke(this, new ScrollEventArgs { VisibleStartTime = visibleStartTime, VisibleEndTime = visibleEndTime}) ?? Task.CompletedTask;
    [JSInvokable] public virtual Task OnSeeking(double currentTime) => Seeking?.Invoke(this, new SeekingEventArgs { CurrentTime = currentTime }) ?? Task.CompletedTask;
    [JSInvokable] public virtual Task OnTimeUpdated(double currentTime) => TimeUpdated?.Invoke(this, new TimeUpdateEventArgs { CurrentTime = currentTime }) ?? Task.CompletedTask;
    [JSInvokable] public virtual Task OnZoomed(float minPxPerSec) => Zoomed?.Invoke(this, new ZoomEventArgs { MinPxPerSec = minPxPerSec }) ?? Task.CompletedTask;
}