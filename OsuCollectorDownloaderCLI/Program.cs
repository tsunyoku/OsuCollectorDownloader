using System.Collections.Immutable;
using OsuCollectorDownloader.Helpers;
using OsuCollectorDownloaderCLI.Enums;
using OsuCollectorDownloaderLib;
using OsuCollectorDownloaderLib.Helpers;
using OsuCollectorDownloaderLib.Models;

Console.WriteLine("OsuCollector Downloader tool");
Console.Write("Enter collection IDs you wish to download, separated by a comma (,): ");

var collectionsString = Console.ReadLine()!;
var collectionIds = collectionsString.Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
    .Select(int.Parse).ToImmutableArray();

Console.Write("How would you like to save the collections?\n\n1) Save beatmaps to zip\n2) Save to .osdb file\n\nYour selection: ");
var downloadOption = (SaveOption)int.Parse(Console.ReadLine()!);

var collections = await OsuCollector.FetchCollections(collectionIds);

var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "collections");
if (!Directory.Exists(folderPath))
    Directory.CreateDirectory(folderPath);

foreach (var collection in collections)
{
    Console.WriteLine($"Fetched collection \"{collection.CollectionDetails.Name}\" (ID {collection.CollectionDetails.Id}).");

    var beatmapsetIds = collection.BeatmapDetails.Beatmaps.Select(x => x.BeatmapsetId).ToImmutableArray();

    var filePath = string.Empty;
    IWriter? writer = null;

    switch (downloadOption)
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
        throw new Exception($"Invalid download option {downloadOption}");

    writer.Write();
    Console.WriteLine($"Saved collection \"{collection.CollectionDetails.Name}\" to {filePath}");
}

Console.WriteLine("Finished fetching collections.");
Console.ReadKey();