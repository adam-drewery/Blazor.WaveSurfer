using System.Text.Json;
using Blazor.InterOptimal;
using Blazor.WaveSurfer.EventArgs;
using Blazor.WaveSurfer.Plugins;
using Microsoft.JSInterop;

namespace Blazor.WaveSurfer;

public class WaveSurfer : IAsyncDisposable
{
    private readonly dynamic _scriptObject;
    private readonly IJSObjectReference _jsObject;

    private WaveSurfer(IJSObjectReference jsObject, dynamic scriptObject)
    {
        _jsObject = jsObject;
        _scriptObject = scriptObject;
    }

    public static async Task<WaveSurfer> CreateAsync(IJSRuntime jsRuntime, WaveSurferOptions options)
    {
        var jsObject = await jsRuntime.InvokeAsync<IJSObjectReference>("WaveSurfer.create", options);
        var scriptObject = await ScriptObject.CreateAsync(jsRuntime, jsObject);
        var surfer = new WaveSurfer(jsObject, scriptObject); 

        await surfer.WireUp("audioprocess");
        await surfer.WireUp("click");
        await surfer.WireUp("decode");
        await surfer.WireUp("destroy");
        await surfer.WireUp("drag");
        await surfer.WireUp("finish");
        await surfer.WireUp("interaction");
        await surfer.WireUp("load");
        await surfer.WireUp("loading");
        await surfer.WireUp("pause");
        await surfer.WireUp("play");
        await surfer.WireUp("ready");
        await surfer.WireUp("redraw");
        await surfer.WireUp("scroll");
        await surfer.WireUp("seek");
        await surfer.WireUp("timeupdate");
        await surfer.WireUp("zoom");

        return surfer;
    }
    
    public async Task WireUp(string eventName)
    {
        var func = (dynamic args) => OnEvent(eventName, args);
        await _scriptObject.on(eventName, func);
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

    public async Task PlayAsync() => await _scriptObject.play();
    public async Task PauseAsync() => await _scriptObject.pause();
    public async Task StopAsync() => await _scriptObject.stop();
    public async Task DestroyAsync() => await _scriptObject.destroy();
    public async Task EmptyAsync() => await _scriptObject.empty();
    public async Task<double[][]> ExportPeaksAsync() => await _scriptObject.exportPeaks();
    public async Task<double> GetCurrentTimeAsync() => await _scriptObject.getCurrentTime();
    public async Task<byte[]> GetDecodedDataAsync() => await _scriptObject.getDecodedData();
    public async Task<double> GetDurationAsync() => await _scriptObject.getDuration();
    public async Task<string> GetMediaElementAsync() => await _scriptObject.getMediaElement();
    public async Task<bool> GetMutedAsync() => await _scriptObject.getMuted();
    public async Task<double> GetPlaybackRateAsync() => await _scriptObject.getPlaybackRate();
    public async Task<double> GetScrollAsync() => await _scriptObject.getScroll();
    public async Task<double> GetVolumeAsync() => await _scriptObject.getVolume();
    public async Task<string> GetWrapperAsync() => await _scriptObject.getWrapper();
    public async Task<bool> IsPlayingAsync() => await _scriptObject.isPlaying();
    public async Task LoadAsync(string url) => await _scriptObject.load(url);
    public async Task LoadAsync(string url, double[] peaks) => await _scriptObject.load(url, peaks);
    public async Task LoadAudioAsync(string url, Blob blob) => await _scriptObject.loadAudio(url, blob);
    public async Task LoadBlobAsync(Blob blob) => await _scriptObject.loadBlob(blob);
    public async Task PlayPauseAsync() => await _scriptObject.playPause();
    public async Task SeekToAsync(double progress) => await _scriptObject.seekTo(progress);
    public async Task SetMutedAsync(bool muted) => await _scriptObject.setMuted(muted);
    public async Task SetOptionsAsync(WaveSurferOptions options) => await _scriptObject.setOptions(options);
    public async Task SetPlaybackRateAsync(double rate) => await _scriptObject.setPlaybackRate(rate);
    public async Task SetSinkIdAsync(string sinkId) => await _scriptObject.setSinkId(sinkId);
    public async Task SetTimeAsync(double time) => await _scriptObject.setTime(time);
    public async Task SetVolumeAsync(double volume) => await _scriptObject.setVolume(volume);
    public async Task SkipAsync(double seconds) => await _scriptObject.skip(seconds);
    public async Task ToggleInteractionAsync(bool isInteractive) => await _scriptObject.toggleInteraction(isInteractive);
    public async Task ZoomAsync(double minPxPerSec) => await _scriptObject.zoom(minPxPerSec);
    public async Task<T> RegisterPluginAsync<T>(T plugin) where T : GenericPlugin
    {
        await _scriptObject.registerPlugin(plugin.JsObject);
        return plugin;
    }

    public void Dispose() => _scriptObject.destroy();

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