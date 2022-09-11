using System.Text.Json.Serialization;

namespace OsuCollectorDownloaderLib.Models;

public class Uploader
{
    [JsonPropertyName("username")]
    public string Username { get; init; } = default!;
    
    [JsonPropertyName("rank")]
    public int? Rank { get; init; }
    
    [JsonPropertyName("id")]
    public int Id { get; init; }
}