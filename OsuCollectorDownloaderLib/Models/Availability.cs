using System.Text.Json.Serialization;

namespace OsuCollectorDownloaderLib.Models;

public class Availability
{
    [JsonPropertyName("more_information")]
    public string? MoreInformation { get; init; }
    
    [JsonPropertyName("download_disabled")]
    public bool DownloadDisabled { get; init; }
}