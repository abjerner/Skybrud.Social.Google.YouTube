using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models.Playlists {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlists#contentDetails</cref>
    /// </see>
    public class YouTubePlaylistContentDetails : GoogleObject {

        #region Properties

        /// <summary>
        /// Gets the number of videos in the playlist.
        /// </summary>
        public int ItemCount { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected YouTubePlaylistContentDetails(JObject json) : base(json) {
            ItemCount = json.GetInt32("itemCount");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubePlaylistContentDetails"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubePlaylistContentDetails"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static YouTubePlaylistContentDetails? Parse(JObject? json) {
            return json == null ? null : new YouTubePlaylistContentDetails(json);
        }

        #endregion

    }

}