using System.Text.Json.Serialization;

namespace OsuCollectorDownloaderLib.Models;

public class FailTimes
{
    [JsonPropertyName("fail")]
    public IReadOnlyList<int> Fail { get; init; } = default!;

    [JsonPropertyName("exit")]
    public IReadOnlyList<int> Exit { get; init; } = default!;
}