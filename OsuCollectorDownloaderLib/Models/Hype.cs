using System.Text.Json.Serialization;

namespace OsuCollectorDownloaderLib.Models;

public class Hype
{
    [JsonPropertyName("required")]
    public int Required { get; init; }
    
    [JsonPropertyName("current")]
    public int Current { get; init; }
}