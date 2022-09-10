using System.Text.Json.Serialization;

namespace OsuCollectorDownloaderLib.Models;

public class CollectionResponse
{
    // NOTE: only some fields are typed here because i'm lazy and don't care for the rest
    
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = default!;

    [JsonPropertyName("uploader")]
    public Uploader Uploader { get; init; } = default!;
}