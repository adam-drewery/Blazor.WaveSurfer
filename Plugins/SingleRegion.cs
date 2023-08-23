namespace Blazor.WaveSurfer.Plugins;

public class SingleRegion
{
    public string? Id { get; set; }
    
    public double Start { get; set; }
    
    public double End { get; set; }
    
    public bool Drag { get; set; }
    
    public bool Resize { get; set; }
    
    public string? Color { get; set; }
    
    public double MinLength { get; set; } = 0;
    
    public double? MaxLength { get; set; } = double.PositiveInfinity;
}