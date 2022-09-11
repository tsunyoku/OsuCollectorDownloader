using System.Text.Json.Serialization;

namespace OsuCollectorDownloaderLib.Models;

public class CollectionBeatmapsResponse
{
    [JsonPropertyName("nextPageCursor")]
    public int? NextPageCursor { get; init; }
    
    [JsonPropertyName("hasMore")]
    public bool HasMore { get; init; }

    [JsonPropertyName("beatmaps")]
    public IReadOnlyList<Beatmap> Beatmaps { get; set; } = default!;
}