using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models.Playlists {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlists#snippet</cref>
    /// </see>
    public class YouTubePlaylistSnippet : GoogleObject {

        #region Properties

        /// <summary>
        /// Gets the date and time that the playlist was created.
        /// </summary>
        public EssentialsTime PublishedAt { get; }

        /// <summary>
        /// Gets the ID that YouTube uses to uniquely identify the channel that published the playlist.
        /// </summary>
        public string ChannelId { get; }

        /// <summary>
        /// Gets the channel title of the channel that the video belongs to.
        /// </summary>
        public string ChannelTitle { get; }

        /// <summary>
        /// Gets the playlist's title.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Gets the playlist's description.
        /// </summary>
        public string Description { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected YouTubePlaylistSnippet(JObject json) : base(json) {
            ChannelId = json.GetString("channelId");
            ChannelTitle = json.GetString("channelTitle");
            PublishedAt = json.GetString("publishedAt", EssentialsTime.Parse);
            Title = json.GetString("title");
            Description = json.GetString("description");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubePlaylistSnippet"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubePlaylistSnippet"/>.</returns>
        public static YouTubePlaylistSnippet Parse(JObject json) {
            return json == null ? null : new YouTubePlaylistSnippet(json);
        }

        #endregion

    }

}