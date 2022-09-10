using System.Collections.Immutable;

namespace OsuCollectorDownloaderLib;

public static class BeatmapsetDownloader
{
    private static readonly HttpClient HttpClient = new()
    {
        BaseAddress = new Uri("https://kitsu.moe/")
    };

    public static async Task<BeatmapsetDownload> DownloadBeatmapset(int beatmapsetId)
    {
        var stream = await HttpClient.GetStreamAsync($"d/{beatmapsetId}");
        if (stream is null)
            throw new Exception($"Failed to download beatmapset ID {beatmapsetId}.");

        var memoryStream = new MemoryStream();
        await stream.CopyToAsync(memoryStream);

        return new BeatmapsetDownload
        {
            BeatmapsetId = beatmapsetId,
            OszFile = memoryStream
        };
    }

    public static async Task<ImmutableArray<BeatmapsetDownload>> DownloadBeatmapsets(
        IReadOnlyList<int> beatmapsetIds)
    {
        var beatmapsets = new List<BeatmapsetDownload>();

        foreach (var beatmapsetId in beatmapsetIds)
        {
            var beatmapset = await DownloadBeatmapset(beatmapsetId);
            beatmapsets.Add(beatmapset);
        }

        return beatmapsets.ToImmutableArray();
    }
}