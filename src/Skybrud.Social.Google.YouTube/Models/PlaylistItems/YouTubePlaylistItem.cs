using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
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
        public string Id { get; }

        /// <summary>
        /// Gets a reference to the <c>statistics</c> object of the playlist item. 
        /// </summary>
        public YouTubePlaylistItemSnippet? Snippet { get; }

        /// <summary>
        /// Gets a reference to the <c>contentDetails</c> object of the playlist item. 
        /// </summary>
        public YouTubePlaylistItemContentDetails? ContentDetails { get; }

        /// <summary>
        /// Gets a reference to the <c>status</c> object of the playlist item. 
        /// </summary>
        public YouTubePlaylistItemStatus? Status { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected YouTubePlaylistItem(JObject json) : base(json) {
            Id = json.GetString("id")!;
            Snippet = json.GetObject("snippet", YouTubePlaylistItemSnippet.Parse);
            ContentDetails = json.GetObject("contentDetails", YouTubePlaylistItemContentDetails.Parse);
            Status = json.GetObject("status", YouTubePlaylistItemStatus.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubePlaylistItem"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubePlaylistItem"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static YouTubePlaylistItem? Parse(JObject? json) {
            return json == null ? null : new YouTubePlaylistItem(json);
        }

        #endregion

    }

}