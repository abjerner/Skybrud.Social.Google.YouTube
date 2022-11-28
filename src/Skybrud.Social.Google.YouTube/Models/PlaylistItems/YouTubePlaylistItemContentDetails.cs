using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models.PlaylistItems {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlistItems#contentDetails</cref>
    /// </see>
    public class YouTubePlaylistItemContentDetails : GoogleObject {

        #region Properties

        /// <summary>
        /// Gets the ID that YouTube uses to uniquely identify a video.
        /// </summary>
        public string VideoId { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected YouTubePlaylistItemContentDetails(JObject json) : base(json) {
            VideoId = json.GetString("videoId")!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubePlaylistItemContentDetails"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubePlaylistItemContentDetails"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static YouTubePlaylistItemContentDetails? Parse(JObject? json) {
            return json == null ? null : new YouTubePlaylistItemContentDetails(json);
        }

        #endregion

    }

}