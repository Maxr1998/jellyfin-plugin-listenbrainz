using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Jellyfin.Plugin.ListenBrainz.Configuration;

/// <summary>
/// ListenBrainz user configuration.
/// </summary>
public class UserConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserConfig"/> class.
    /// </summary>
    public UserConfig()
    {
        IsListenSubmitEnabled = false;
        ApiToken = string.Empty;
    }

    /// <summary>
    /// Gets or sets Jellyfin user id.
    /// </summary>
    public Guid JellyfinUserId { get; set; }

    /// <summary>
    /// Gets or sets ListenBrainz API token.
    /// </summary>
    public string ApiToken { get; set; }

    /// <summary>
    /// Gets or sets ListenBrainz API token in plaintext.
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public string PlaintextApiToken
    {
        get => Encoding.UTF8.GetString(Convert.FromBase64String(ApiToken));
        set => ApiToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
    }

    /// <summary>
    /// Gets or sets a value indicating whether ListenBrainz submission is enabled.
    /// </summary>
    public bool IsListenSubmitEnabled { get; set; }

    /// <summary>
    /// Gets a value indicating whether ListenBrainz submission is not enabled.
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public bool IsNotListenSubmitEnabled => !IsListenSubmitEnabled;

    /// <summary>
    /// Gets or sets a value indicating whether ListenBrainz favorites sync is enabled.
    /// </summary>
    public bool IsFavoritesSyncEnabled { get; set; }
}
