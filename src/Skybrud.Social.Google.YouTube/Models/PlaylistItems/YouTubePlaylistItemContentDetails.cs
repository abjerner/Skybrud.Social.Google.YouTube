using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models.PlaylistItems {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlistItems#contentDetails</cref>
    /// </see>
    public class YouTubePlaylistItemContentDetails : GoogleApiObject {

        #region Properties

        public string VideoId { get; }

        #endregion

        #region Constructor

        protected YouTubePlaylistItemContentDetails(JObject obj) : base(obj) {
            VideoId = obj.GetString("videoId");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubePlaylistItemContentDetails"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubePlaylistItemContentDetails"/>.</returns>
        public static YouTubePlaylistItemContentDetails Parse(JObject obj) {
            return obj == null ? null : new YouTubePlaylistItemContentDetails(obj);
        }

        #endregion

    }

}