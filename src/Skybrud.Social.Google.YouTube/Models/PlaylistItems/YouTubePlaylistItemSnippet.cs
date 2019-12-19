using System;
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
    public class YouTubePlaylistItemSnippet : GoogleApiObject {

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

        public YouTubePlaylistItemResourceId ResourceId { get; }

        #endregion
        
        #region Constructors

        private YouTubePlaylistItemSnippet(JObject obj) : base(obj) {
            PublishedAt = obj.GetString("publishedAt", EssentialsTime.Parse);
            ChannelId = obj.GetString("channelId");
            Title = obj.GetString("title");
            Description = obj.GetString("description");
            Thumbnails = obj.GetObject("thumbnails", YouTubePlaylistItemThumbnails.Parse);
            ChannelTitle = obj.GetString("channelTitle");
            PlaylistId = obj.GetString("playlistId");
            Position = obj.GetInt32("position");
            ResourceId = obj.GetObject("resourceId", YouTubePlaylistItemResourceId.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubePlaylistItemSnippet"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubePlaylistItemSnippet"/>.</returns>
        public static YouTubePlaylistItemSnippet Parse(JObject obj) {
            return obj == null ? null : new YouTubePlaylistItemSnippet(obj);
        }

        #endregion

    }

}