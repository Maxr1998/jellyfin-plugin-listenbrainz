using System.Text.Json.Serialization;

namespace Jellyfin.Plugin.ListenBrainz.MusicBrainzApi.Models;

/// <summary>
/// MusicBrainz recording.
/// </summary>
public class Recording
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Recording"/> class.
    /// </summary>
    public Recording()
    {
        this.Mbid = string.Empty;
        this.ArtistCredits = new List<ArtistCredit>();
    }

    /// <summary>
    /// Gets or sets recording MBID.
    /// </summary>
    [JsonPropertyName("id")]
    public string Mbid { get; set; }

    /// <summary>
    /// Gets or sets search match score.
    /// </summary>
    public int Score { get; set; }

    /// <summary>
    /// Gets or sets artist credits.
    /// </summary>
    [JsonPropertyName("artist-credit")]
    public IEnumerable<ArtistCredit> ArtistCredits { get; set; }
}
