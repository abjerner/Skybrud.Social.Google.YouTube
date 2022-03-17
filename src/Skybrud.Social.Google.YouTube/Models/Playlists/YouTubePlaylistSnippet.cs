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

        public EssentialsTime PublishedAt { get; }
        
        public string ChannelId { get; }
        
        public string ChannelTitle { get; }
        
        public string Title { get; }
        
        public string Description { get; }

        #endregion

        #region Constructor

        protected YouTubePlaylistSnippet(JObject obj) : base(obj) {
            ChannelId = obj.GetString("channelId");
            ChannelTitle = obj.GetString("channelTitle");
            PublishedAt = obj.GetString("publishedAt", EssentialsTime.Parse);
            Title = obj.GetString("title");
            Description = obj.GetString("description");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubePlaylistSnippet"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubePlaylistSnippet"/>.</returns>
        public static YouTubePlaylistSnippet Parse(JObject obj) {
            return obj == null ? null : new YouTubePlaylistSnippet(obj);
        }

        #endregion

    }

}