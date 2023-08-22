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
            var options = new WaveSurferOptions(/* your options here */); 
            waveSurfer = new WaveSurfer("waveform");
            await waveSurfer.LoadAsync("https://wavesurfer-js.org/example/split-channels/stereo.mp3");
        }
    }
}
```
Refer to the [wavesurfer.js documentation](https://wavesurfer-js.org/docs/) for more information.