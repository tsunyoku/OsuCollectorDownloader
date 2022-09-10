using System.IO.Compression;
using OsuCollectorDownloaderLib.Helpers;

namespace OsuCollectorDownloader.Helpers;

public class ZipWriter : IWriter
{
    private readonly IReadOnlyList<BeatmapsetDownload> _beatmapsets;
    private readonly string _filePath;

    public ZipWriter(IReadOnlyList<BeatmapsetDownload> beatmapsets, string filePath)
    {
        _beatmapsets = beatmapsets;
        _filePath = filePath;
        
        if (File.Exists(_filePath))
            throw new Exception($"File {_filePath} already exists.");
    }

    public void Write()
    {
        var tempPath = Path.GetTempPath();

        foreach (var beatmapset in _beatmapsets)
        {
            var beatmapsetPath = Path.Combine(tempPath, $"{beatmapset.BeatmapsetId}.osz");
            File.WriteAllBytes(beatmapsetPath, beatmapset.OszFile.ToArray());
        }
        
        ZipFile.CreateFromDirectory(tempPath, _filePath);
        Directory.Delete(tempPath, recursive: true);
    }
}