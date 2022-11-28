using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models.PlaylistItems {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlistItems#snippet.thumbnails</cref>
    /// </see>
    public class YouTubePlaylistItemThumbnail : GoogleObject {

        #region Properties

        /// <summary>
        /// Gets the image's URL.
        /// </summary>
        public string Url { get; }

        /// <summary>
        /// Gets the image's width.
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Gets the image's height.
        /// </summary>
        public int Height { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected YouTubePlaylistItemThumbnail(JObject json) : base(json) {
            Url = json.GetString("url");
            Width = json.GetInt32("width");
            Height = json.GetInt32("height");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubePlaylistItemThumbnail"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubePlaylistItemThumbnail"/>.</returns>
        public static YouTubePlaylistItemThumbnail Parse(JObject json) {
            return json == null ? null : new YouTubePlaylistItemThumbnail(json);
        }

        #endregion

    }

}