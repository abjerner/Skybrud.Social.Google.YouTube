using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models.PlaylistItems {

    /// <summary>
    /// Class representing the <c>snippet</c> object of a YouTube playlist item.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlistItems#snippet</cref>
    /// </see> 
    public class YouTubePlaylistItemSnippet : GoogleObject {

        #region Properties
        
        /// <summary>
        /// gets the timestamp for when the item was added to the playlist.
        /// </summary>
        public EssentialsTime PublishedAt { get; }

        /// <summary>
        /// Gets the ID of the parent YouTube channel.
        /// </summary>
        public string ChannelId { get; }

        /// <summary>
        /// Gets the title of the playlist item.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Gets the description of the playlist item.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets a collection of thumbnails of the playlist item.
        /// </summary>
        public YouTubePlaylistItemThumbnails Thumbnails { get; }
        
        /// <summary>
        /// Gets the title of the parent YouTube channel.
        /// </summary>
        public string ChannelTitle { get; }

        /// <summary>
        /// Gets the title of the parent YouTube playlist.
        /// </summary>
        public string PlaylistId { get; }

        /// <summary>
        /// Gets the order in which the item appears in the parent playlist. The value uses a zero-based index, so the
        /// first item has a position of <c>0</c>, the second item has a position of <c>1</c>, and so forth.
        /// </summary>
        public int Position { get; }

        /// <summary>
        /// Gets information that can be used to uniquely identify the resource that is included in the playlist as the playlist item.
        /// </summary>
        public YouTubePlaylistItemResourceId ResourceId { get; }

        #endregion
        
        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected YouTubePlaylistItemSnippet(JObject json) : base(json) {
            PublishedAt = json.GetString("publishedAt", EssentialsTime.Parse);
            ChannelId = json.GetString("channelId");
            Title = json.GetString("title");
            Description = json.GetString("description");
            Thumbnails = json.GetObject("thumbnails", YouTubePlaylistItemThumbnails.Parse);
            ChannelTitle = json.GetString("channelTitle");
            PlaylistId = json.GetString("playlistId");
            Position = json.GetInt32("position");
            ResourceId = json.GetObject("resourceId", YouTubePlaylistItemResourceId.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubePlaylistItemSnippet"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubePlaylistItemSnippet"/>.</returns>
        public static YouTubePlaylistItemSnippet Parse(JObject json) {
            return json == null ? null : new YouTubePlaylistItemSnippet(json);
        }

        #endregion

    }

}