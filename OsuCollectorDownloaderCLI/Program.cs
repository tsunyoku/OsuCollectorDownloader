using System.Collections.Immutable;
using OsuCollectorDownloaderCLI;
using OsuCollectorDownloaderCLI.Enums;
using OsuCollectorDownloaderLib;

Console.WriteLine("OsuCollector Downloader tool");
Console.Write("Enter collection IDs you wish to download, separated by a comma (,): ");

var collectionsString = Console.ReadLine()!;
var collectionIds = collectionsString.Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
    .Select(int.Parse).ToImmutableArray();

Console.Write("How would you like to save the collections?\n\n1) Save beatmaps to zip\n2) Save to .osdb file\n\nYour selection: ");
var saveOption = (SaveOption)int.Parse(Console.ReadLine()!);

try
{
    var collections = await OsuCollector.FetchCollections(collectionIds);
    await CollectionProcessor.Process(collections, saveOption);
}
catch (Exception e)
{
    Console.WriteLine(e);
    Console.ReadKey();

    return;
}

Console.WriteLine("Finished fetching collections.");
Console.ReadKey();