using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models.PlaylistItems {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlistItems#snippet.thumbnails</cref>
    /// </see>
    public class YouTubePlaylistItemThumbnail : GoogleApiObject {

        #region Properties

        public string Url { get; }

        public int Width { get; }

        public int Height { get; }

        #endregion

        #region Constructors

        protected YouTubePlaylistItemThumbnail(JObject obj) : base(obj) {
            Url = obj.GetString("url");
            Width = obj.GetInt32("width");
            Height = obj.GetInt32("height");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubePlaylistItemThumbnail"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubePlaylistItemThumbnail"/>.</returns>
        public static YouTubePlaylistItemThumbnail Parse(JObject obj) {
            return obj == null ? null : new YouTubePlaylistItemThumbnail(obj);
        }

        #endregion

    }

}