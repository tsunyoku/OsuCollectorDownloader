using System.Collections.Immutable;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace OsuCollectorDownloaderLib;

public static class OsuCollector
{
    private static readonly HttpClient HttpClient = new()
    {
        BaseAddress = new Uri("https://osucollector.com/api/")
    };

    private static bool _initialized;

    private static void Initialize()
    {
        if (_initialized)
            return;

        HttpClient.DefaultRequestHeaders.UserAgent.ParseAdd(
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10.12; rv:55.0) Gecko/20100101 Firefox/55.0");

        _initialized = true;
    }

    public static async Task<Collection> FetchCollection(int collectionId)
    {
        Initialize();

        var collection = await
            HttpClient.GetFromJsonAsync<CollectionResponse?>($"collections/{collectionId}");

        if (collection is null)
            throw new Exception($"Collection ID {collectionId} not found.");

        var collectionBeatmaps = await
            HttpClient.GetFromJsonAsync<CollectionBeatmapsResponse?>(
                $"collections/{collectionId}/beatmapsv2?perPage=5000&sortBy=beatmapset.artist&orderBy=asc");

        if (collectionBeatmaps is null)
            throw new Exception($"Failed to get beatmaps for collection ID {collectionId}.");

        return new Collection
        {
            CollectionDetails = collection,
            BeatmapDetails = collectionBeatmaps
        };
    }

    public static async Task<ImmutableArray<Collection>> FetchCollections(IReadOnlyList<int> collectionIds)
    {
        Initialize();

        var collections = new List<Collection>();

        foreach (var collectionId in collectionIds)
        {
            var collection = await FetchCollection(collectionId);
            collections.Add(collection);
        }

        return collections.ToImmutableArray();
    }
}