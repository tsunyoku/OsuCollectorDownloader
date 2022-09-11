using System.Collections.Immutable;

namespace OsuCollectorDownloaderLib;

public static class BeatmapsetDownloader
{
    private static readonly HttpClient HttpClient = new()
    {
        BaseAddress = new Uri("https://mirror.tsunyoku.xyz/")
    };

    public static async Task<BeatmapsetDownload?> DownloadBeatmapset(int beatmapsetId)
    {
        byte[] data;
        try
        {
            data = await HttpClient.GetByteArrayAsync($"d/{beatmapsetId}");
        }
        catch (Exception)
        {
            // TODO: do better than this lol
            return null;
        }

        return new BeatmapsetDownload
        {
            BeatmapsetId = beatmapsetId,
            OszFile = new MemoryStream(data)
        };
    }

    public static async Task<ImmutableArray<BeatmapsetDownload>> DownloadBeatmapsets(
        IReadOnlyList<int> beatmapsetIds)
    {
        var beatmapsets = new List<BeatmapsetDownload>();
        var tasks = new List<Task>();

        foreach (var beatmapsetId in beatmapsetIds)
        {
            async Task BeatmapsetDownloadTask()
            {
                // to avoid ratelimits
                await Task.Delay(TimeSpan.FromMilliseconds(50));

                var beatmapset = await DownloadBeatmapset(beatmapsetId);
                if (beatmapset != null)
                {
                    beatmapsets.Add(beatmapset);
                    Console.WriteLine($"Downloaded beatmapset {beatmapsetId}");
                }
            }

            tasks.Add(BeatmapsetDownloadTask());
        }

        // wait for all maps to download
        await Task.WhenAll(tasks);

        return beatmapsets.ToImmutableArray();
    }
}