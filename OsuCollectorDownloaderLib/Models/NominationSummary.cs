using System.Text.Json.Serialization;

namespace OsuCollectorDownloaderLib.Models;

public class NominationSummary
{
    [JsonPropertyName("current")]
    public int Current { get; init; }
    
    [JsonPropertyName("required")]
    public int Required { get; init; }
}