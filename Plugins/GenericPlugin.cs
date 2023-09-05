namespace Blazor.WaveSurfer.Plugins;

public abstract class GenericPlugin
{
    protected GenericPlugin(dynamic scriptObject) => ScriptObject = scriptObject;
    internal dynamic ScriptObject { get; set; }
}