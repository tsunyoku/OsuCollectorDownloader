using System.Text.Json.Serialization;

namespace OsuCollectorDownloaderLib.Models;

public class Beatmap
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("checksum")]
    public string Checksum { get; init; } = default!;

    [JsonPropertyName("url")]
    public string Url { get; init; } = default!;

    [JsonPropertyName("user_id")]
    public int UserId { get; init; }
    
    [JsonPropertyName("ranked")]
    public RankedStatus RankedStatus { get; init; }
    
    [JsonPropertyName("status")]
    public string RankedStatusString { get; init; } = default!;

    [JsonPropertyName("deleted_at")]
    public DateTimeOffset? DeletedAt { get; init; }
    
    [JsonPropertyName("bpm")]
    public double Bpm { get; init; }
    
    [JsonPropertyName("count_circles")]
    public int CircleCount { get; init; }
    
    [JsonPropertyName("count_spinners")]
    public int SpinnerCount { get; init; }
    
    [JsonPropertyName("hit_length")]
    public int HitLength { get; init; }

    [JsonPropertyName("failtimes")]
    public FailTimes FailTimes { get; init; } = default!;

    [JsonPropertyName("passcount")]
    public int Passcount { get; init; }
    
    [JsonPropertyName("playcount")]
    public int Playcount { get; init; }

    [JsonPropertyName("version")]
    public string DifficultyName { get; init; } = default!;
    
    [JsonPropertyName("last_updated")]
    public DateTimeOffset LastUpdated { get; init; }

    [JsonPropertyName("beatmapset")]
    public Beatmapset Beatmapset { get; init; } = default!;
    
    [JsonPropertyName("cs")]
    public double CircleSize { get; init; }

    [JsonPropertyName("mode")]
    public string Mode { get; init; } = default!;

    [JsonPropertyName("accuracy")]
    public double OverallDifficulty { get; init; }
    
    [JsonPropertyName("beatmapset_id")]
    public int BeatmapsetId { get; init; }
    
    [JsonPropertyName("is_scoreable")]
    public bool IsScoreable { get; init; }
    
    [JsonPropertyName("mode_int")]
    public int ModeInt { get; init; }
    
    [JsonPropertyName("convert")]
    public bool Convert { get; init; }
    
    [JsonPropertyName("drain")]
    public double HealthPoints { get; init; }
    
    [JsonPropertyName("difficulty_rating")]
    public double StarRating { get; init; }
    
    [JsonPropertyName("total_length")]
    public int TotalLength { get; init; }
    
    [JsonPropertyName("max_combo")]
    public int? MaxCombo { get; init; }
    
    [JsonPropertyName("count_sliders")]
    public int SliderCount { get; init; }
    
    [JsonPropertyName("ar")]
    public double ApproachRate { get; init; }
}