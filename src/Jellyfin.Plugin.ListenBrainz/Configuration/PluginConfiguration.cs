using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;
using MediaBrowser.Model.Plugins;

namespace Jellyfin.Plugin.ListenBrainz.Configuration;

/// <summary>
/// ListenBrainz plugin configuration.
/// </summary>
public class PluginConfiguration : BasePluginConfiguration
{
    private string? _musicBrainzUrlOverride;
    private string? _listenBrainzUrlOverride;
    private bool? _isMusicBrainzEnabledOverride;
    private bool? _isAlternativeModeEnabled;

    /// <summary>
    /// Initializes a new instance of the <see cref="PluginConfiguration"/> class.
    /// </summary>
    public PluginConfiguration()
    {
        UserConfigs = new Collection<UserConfig>();
    }

    /// <summary>
    /// Gets or sets ListenBrainz API base URL.
    /// </summary>
    public string ListenBrainzApiUrl
    {
        get => _listenBrainzUrlOverride ?? Api.Resources.General.BaseUrl;
        set => _listenBrainzUrlOverride = value;
    }

    /// <summary>
    /// Gets a default ListenBrainz API base URL.
    /// </summary>
    [XmlIgnore]
    public string DefaultListenBrainzApiUrl => Api.Resources.General.BaseUrl;

    /// <summary>
    /// Gets or sets MusicBrainz API base URL.
    /// </summary>
    public string MusicBrainzApiUrl
    {
        get => _musicBrainzUrlOverride ?? MusicBrainzApi.Resources.Api.BaseUrl;
        set => _musicBrainzUrlOverride = value;
    }

    /// <summary>
    /// Gets a default MusicBrainz API base URL.
    /// </summary>
    [XmlIgnore]
    public string DefaultMusicBrainzApiUrl => MusicBrainzApi.Resources.Api.BaseUrl;

    /// <summary>
    /// Gets or sets a value indicating whether MusicBrainz integration is enabled.
    /// </summary>
    public bool IsMusicBrainzEnabled
    {
        get => _isMusicBrainzEnabledOverride ?? true;
        set => _isMusicBrainzEnabledOverride = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether alternative plugin mode is enabled.
    /// </summary>
    public bool IsAlternativeModeEnabled
    {
        get => _isAlternativeModeEnabled ?? false;
        set => _isAlternativeModeEnabled = value;
    }

    /// <summary>
    /// Gets or sets ListenBrainz user configurations.
    /// </summary>
    [SuppressMessage("Warning", "CA2227", Justification = "Needed for deserialization")]
    public Collection<UserConfig> UserConfigs { get; set; }
}
