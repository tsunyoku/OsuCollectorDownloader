namespace OsuCollectorDownloaderLib.Models;

public class BeatmapsetDownload
{
    public int BeatmapsetId { get; init; }
    public MemoryStream OszFile { get; init; } = default!;
}