using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models.PlaylistItems {

    /// <summary>
    /// Class representing a YouTube playlist item.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlistItems#resource</cref>
    /// </see>
    public class YouTubePlaylistItem : GoogleResource {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the playlist item.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets a reference to the <c>statistics</c> object of the playlist item. 
        /// </summary>
        public YouTubePlaylistItemSnippet Snippet { get; }

        /// <summary>
        /// Gets a reference to the <c>contentDetails</c> object of the playlist item. 
        /// </summary>
        public YouTubePlaylistItemContentDetails ContentDetails { get; }

        /// <summary>
        /// Gets a reference to the <c>status</c> object of the playlist item. 
        /// </summary>
        public YouTubePlaylistItemStatus Status { get; }

        #region Shortcuts

        /// <summary>
        /// Gets the YouTube ID of the video.
        /// </summary>
        public string VideoId => Snippet.ResourceId.VideoId;

        /// <summary>
        /// Gets the title of the YouTube video.
        /// </summary>
        public string Title => Snippet.Title;

        /// <summary>
        /// Gets the publish date of the YouTube video.
        /// </summary>
        public EssentialsTime PublishedAt => Snippet.PublishedAt;

        #endregion

        #endregion

        #region Constructors

        private YouTubePlaylistItem(JObject obj) : base(obj) {
            Id = obj.GetString("id");
            Snippet = obj.GetObject("snippet", YouTubePlaylistItemSnippet.Parse);
            ContentDetails = obj.GetObject("contentDetails", YouTubePlaylistItemContentDetails.Parse);
            Status = obj.GetObject("status", YouTubePlaylistItemStatus.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubePlaylistItem"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubePlaylistItem"/>.</returns>
        public static YouTubePlaylistItem Parse(JObject obj) {
            return obj == null ? null : new YouTubePlaylistItem(obj);
        }

        #endregion

    }

}