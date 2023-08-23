using System.Text.Json;
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
        var jsObject = await jsRuntime.InvokeAsync<IJSObjectReference>("WaveSurfer.create", options);
        var helper = await Events.Setup(jsRuntime, jsObject);
        var surfer = new WaveSurfer(jsObject, jsRuntime);

        await helper.WireUp(surfer, "audioprocess");
        await helper.WireUp(surfer, "click");
        await helper.WireUp(surfer, "decode");
        await helper.WireUp(surfer, "destroy");
        await helper.WireUp(surfer, "drag");
        await helper.WireUp(surfer, "finish");
        await helper.WireUp(surfer, "interaction");
        await helper.WireUp(surfer, "load");
        await helper.WireUp(surfer, "loading");
        await helper.WireUp(surfer, "pause");
        await helper.WireUp(surfer, "play");
        await helper.WireUp(surfer, "ready");
        await helper.WireUp(surfer, "redraw");
        await helper.WireUp(surfer, "scroll");
        await helper.WireUp(surfer, "seek");
        await helper.WireUp(surfer, "timeupdate");
        await helper.WireUp(surfer, "zoom");

        return surfer;
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
    public async Task LoadAudioAsync(string url, byte[] blob) => await _jsRuntime.InvokeVoidAsync("blobWrapper", "loadAudio", url, blob);
    public async Task LoadBlobAsync(byte[] blob) => await _jsRuntime.InvokeVoidAsync("blobWrapper", _jsObject, "loadBlob", blob);
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
    public async Task<T> RegisterPluginAsync<T>(T plugin) where T : GenericPlugin
    {
        await _jsObject.InvokeVoidAsync("registerPlugin", plugin.JsObject);
        return plugin;
    }

    public void Dispose() => _jsObject.InvokeVoidAsync("destroy");

    public ValueTask DisposeAsync()
    {
        Dispose();
        return _jsObject.DisposeAsync();
    }

    [JSInvokable]
    // ReSharper disable once CyclomaticComplexity
    public virtual Task OnEvent(string eventName, JsonElement args)
    {
        switch (eventName)
        {
            case "audioprocess":
                return AudioProcessed?.Invoke(this, new AudioProcessEventArgs { CurrentTime = args.GetDouble() })
                    ?? Task.CompletedTask;
            case "click":
                return Clicked?.Invoke(this, new ClickEventArgs { RelativeX = args.GetDouble() }) ?? Task.CompletedTask;
            case "decode":
                return Decoded?.Invoke(this, new DecodeEventArgs()) ?? Task.CompletedTask;
            case "destroy":
                Destroyed?.Invoke(this, System.EventArgs.Empty);
                break;
            case "drag":
                return Dragged?.Invoke(this, new DragEventArgs { RelativeX = args.GetDouble() }) ?? Task.CompletedTask;
            case "finish":
                Finished?.Invoke(this, System.EventArgs.Empty);
                break;
            case "interaction":
                return Interacted?.Invoke(this, new InteractionEventArgs { NewTime = args.GetDouble() })
                    ?? Task.CompletedTask;
            case "load":
                return Loaded?.Invoke(this, new LoadEventArgs { Url = args.GetString() }) ?? Task.CompletedTask;
            case "loading":
                return Loading?.Invoke(this, new LoadingEventArgs { Percent = args.GetDouble() }) ?? Task.CompletedTask;
            case "pause":
                Paused?.Invoke(this, System.EventArgs.Empty);
                break;
            case "play":
                Played?.Invoke(this, System.EventArgs.Empty);
                break;
            case "ready":
                return Ready?.Invoke(this, new ReadyEventArgs()) ?? Task.CompletedTask;
            case "redraw":
                Redrawn?.Invoke(this, System.EventArgs.Empty);
                break;
            case "scroll":
                return Scrolled?.Invoke(this, new ScrollEventArgs { VisibleStartTime = args.GetProperty("visibleStartTime").GetDouble(), VisibleEndTime = args.GetProperty("visibleEndTime").GetDouble() })
                    ?? Task.CompletedTask;
            case "seek":
                return Seeking?.Invoke(this, new SeekingEventArgs { CurrentTime = args.GetDouble() })
                    ?? Task.CompletedTask;
            case "timeupdate":
                return TimeUpdated?.Invoke(this, new TimeUpdateEventArgs { CurrentTime = args.GetDouble() })
                    ?? Task.CompletedTask;
            case "zoom":
                return Zoomed?.Invoke(this, new ZoomEventArgs { MinPxPerSec = args.GetDouble() }) ?? Task.CompletedTask;
        }

        return Task.CompletedTask;
    }
}