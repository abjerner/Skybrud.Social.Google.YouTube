using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models.Playlists {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlists#contentDetails</cref>
    /// </see>
    public class YouTubePlaylistContentDetails : GoogleObject {

        #region Properties

        public int ItemCount { get; }

        #endregion

        #region Constructor

        protected YouTubePlaylistContentDetails(JObject obj) : base(obj) {
            ItemCount = obj.GetInt32("itemCount");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubePlaylistContentDetails"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubePlaylistContentDetails"/>.</returns>
        public static YouTubePlaylistContentDetails Parse(JObject obj) {
            return obj == null ? null : new YouTubePlaylistContentDetails(obj);
        }

        #endregion

    }

}