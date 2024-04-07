[![GitHub Actions](https://github.com/adam-drewery/Blazor.WaveSurfer/actions/workflows/build.yml/badge.svg)](https://github.com/adam-drewery/Blazor.WaveSurfer/actions/workflows/build.yml)
[![NuGet (Blazor.WaveSurfer)](https://img.shields.io/nuget/v/Blazor.WaveSurfer.svg?style=flat-square)](https://www.nuget.org/packages/Blazor.WaveSurfer/)


# Blazor.WaveSurfer
.NET wrapper for the popular [wavesurfer.js](https://wavesurfer-js.org/docs/) library

## Requires:
- .net 7
- Microsoft.JSInterop

## Client-side configuration:
Just import the wavesurfer.js library and make it globally available:
```js
import WaveSurfer from 'wavesurfer.js';
window.WaveSurfer = WaveSurfer;
```

or:

```js
window.WaveSurfer = require('wavesurfer.js');
```

## Usage:
```csharp
@using Blazor.WaveSurfer
<div id="waveform"></div>

@code {
    WaveSurfer waveSurfer;
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            var options = new WaveSurferOptions { Container = "#waveform" /* your other options here */ }; 
            waveSurfer = await WaveSurfer.Create(options);
            await waveSurfer.LoadAsync("https://wavesurfer-js.org/example/split-channels/stereo.mp3");
        }
    }
}
```
Refer to the [wavesurfer.js documentation](https://wavesurfer-js.org/docs/) for more information.
