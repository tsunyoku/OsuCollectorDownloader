namespace OsuCollectorDownloaderLib.Models;

public class Collection
{
    public CollectionResponse CollectionDetails { get; init; } = default!;
    public CollectionBeatmapsResponse BeatmapDetails { get; init; } = default!;
}