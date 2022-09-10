using OsuCollectorDownloaderLib.Helpers;

namespace OsuCollectorDownloaderLib.Models;

public class OsdbWriter : IWriter
{
    private readonly Collection _collection;
    private readonly string _collectionPath;

    public OsdbWriter(Collection collection, string collectionPath)
    {
        _collection = collection;
        _collectionPath = collectionPath;

        if (File.Exists(_collectionPath))
            throw new Exception($"File {_collectionPath} already exists.");
    }

    public void Write()
    {
        using var binaryWriter = new BinaryWriter(new FileStream(_collectionPath, FileMode.Create));
        
        // using version 6 removes the requirement for compression
        binaryWriter.Write("o!dm6");
        
        // time of collection creation
        binaryWriter.Write(DateTime.Now.ToOADate());

        binaryWriter.Write(_collection.CollectionDetails.Uploader.Username);
        
        // number of collections
        binaryWriter.Write(1);

        binaryWriter.Write(_collection.CollectionDetails.Name);
        binaryWriter.Write(_collection.BeatmapDetails.Beatmaps.Count);

        foreach (var beatmap in _collection.BeatmapDetails.Beatmaps)
        {
            binaryWriter.Write(beatmap.Id);
            binaryWriter.Write(beatmap.BeatmapsetId);

            binaryWriter.Write(beatmap.Beatmapset.Artist);
            binaryWriter.Write(beatmap.Beatmapset.Title);

            binaryWriter.Write(beatmap.DifficultyName);
            binaryWriter.Write(beatmap.Checksum);
            
            // user comment?
            binaryWriter.Write("");
            
            binaryWriter.Write((byte)beatmap.ModeInt);
            binaryWriter.Write(beatmap.StarRating);
        }
        
        // ?
        binaryWriter.Write(0);
        
        // fixed footer
        binaryWriter.Write("By Piotrekol");
    }
}