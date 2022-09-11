using System.Collections.Immutable;
using OsuCollectorDownloader.Helpers;
using OsuCollectorDownloaderCLI.Enums;
using OsuCollectorDownloaderLib;
using OsuCollectorDownloaderLib.Helpers;
using OsuCollectorDownloaderLib.Models;

namespace OsuCollectorDownloaderCLI;

public static class CollectionProcessor
{
    public static async Task Process(ImmutableArray<Collection> collections, SaveOption saveOption)
    {
        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "collections");
        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        foreach (var collection in collections)
        {
            Console.WriteLine($"Fetched collection \"{collection.CollectionDetails.Name}\" (ID {collection.CollectionDetails.Id}).");

            var beatmapsetIds = collection.BeatmapDetails.Beatmaps.Select(x => x.BeatmapsetId).ToImmutableArray();

            var filePath = string.Empty;
            IWriter? writer = null;

            switch (saveOption)
            {
                case SaveOption.ZipFile:
                    filePath = Path.Combine(folderPath, $"{collection.CollectionDetails.Name}.zip");
                    var beatmapsetDownloads =
                        await BeatmapsetDownloader.DownloadBeatmapsets(beatmapsetIds);

                    writer = new ZipWriter(beatmapsetDownloads, filePath);
                    break;
                case SaveOption.OsdbFile:
                    filePath = Path.Combine(folderPath, $"{collection.CollectionDetails.Name}.osdb");
                    writer = new OsdbWriter(collection, filePath);
                    break;
            }

            if (writer is null)
                throw new Exception($"Invalid download option {saveOption}");

            writer.Write();
            Console.WriteLine($"Saved collection \"{collection.CollectionDetails.Name}\" to {filePath}");
        }
    }
}