using System.Text.Json.Serialization;

namespace OsuCollectorDownloaderLib.Models;

public class Beatmapset
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("favourite_count")]
    public int FavouriteCount { get; init; }

    [JsonPropertyName("title")]
    public string Title { get; init; } = default!;
    
    [JsonPropertyName("hype")]
    public Hype? Hype { get; init; }
    
    [JsonPropertyName("discussion_enabled")]
    public bool DiscussionEnabled { get; init; }
    
    [JsonPropertyName("video")]
    public bool Video { get; init; }
    
    [JsonPropertyName("submitted_date")]
    public DateTimeOffset SubmittedDate { get; init; }

    [JsonPropertyName("status")]
    public string RankedStatusString { get; init; } = default!;
    
    [JsonPropertyName("nsfw")]
    public bool Nsfw { get; init; }
    
    [JsonPropertyName("user_id")]
    public int UserId { get; init; }
    
    [JsonPropertyName("last_updated")]
    public DateTimeOffset LastUpdated { get; init; }

    [JsonPropertyName("legacy_thread_url")]
    public string LegacyThreadUrl { get; init; } = default!;

    [JsonPropertyName("title_unicode")]
    public string TitleUnicode { get; init; } = default!;

    [JsonPropertyName("discussion_locked")]
    public bool DiscussionLocked { get; init; }

    [JsonPropertyName("can_be_hyped")] 
    public bool CanBeHyped { get; init; }
    
    [JsonPropertyName("play_count")]
    public int PlayCount { get; init; }
    
    [JsonPropertyName("ranked_date")]
    public DateTimeOffset? RankedDate { get; init; }

    [JsonPropertyName("artist_unicode")]
    public string ArtistUnicode { get; init; } = default!;

    [JsonPropertyName("source")]
    public string? Source { get; init; }

    [JsonPropertyName("covers")]
    public IReadOnlyDictionary<string, string> Covers { get; init; } = default!;
    
    [JsonPropertyName("storyboard")]
    public bool Storyboard { get; init; }
    
    [JsonPropertyName("bpm")]
    public double Bpm { get; init; }
    
    [JsonPropertyName("is_scoreable")]
    public bool IsScoreable { get; init; }
    
    [JsonPropertyName("track_id")]
    public int? TrackId { get; init; }
    
    [JsonPropertyName("ranked")]
    public RankedStatus RankedStatus { get; init; }
    
    [JsonPropertyName("tags")]
    public string? Tags { get; init; }

    [JsonPropertyName("creator")]
    public string Creator { get; init; } = default!;

    [JsonPropertyName("availability")]
    public Availability Availability { get; init; } = default!;

    [JsonPropertyName("artist")]
    public string Artist { get; init; } = default!;

    [JsonPropertyName("preview_url")]
    public string PreviewUrl { get; init; } = default!;

    [JsonPropertyName("nominations_summary")]
    public NominationSummary NominationSummary { get; init; } = default!;

    [JsonPropertyName("ratings")]
    public IReadOnlyList<int> Ratings { get; init; } = default!;
}