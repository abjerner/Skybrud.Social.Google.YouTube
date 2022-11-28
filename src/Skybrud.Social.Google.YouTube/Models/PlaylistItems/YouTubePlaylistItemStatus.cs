using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models.PlaylistItems {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlistItems#status</cref>
    /// </see>    
    public class YouTubePlaylistItemStatus : GoogleObject {

        #region Properties

        /// <summary>
        /// Gets the playlist item's privacy status. The channel that uploaded the video that the playlist item
        /// represents can set this value using either the <c>videos.insert</c> or <c>videos.update</c> method.
        /// </summary>
        public YouTubePrivacyStatus PrivacyStatus { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected YouTubePlaylistItemStatus(JObject json) : base(json) {

            // Parse the privacy status
            string strStatus = json.GetString("privacyStatus");
            if (Enum.TryParse(strStatus, true, out YouTubePrivacyStatus status) == false) {
                throw new Exception("Unknown privacy status \"" + strStatus + "\" - please create an issue so it can be fixed https://github.com/abjerner/Skybrud.Social.Google.YouTube/issues/new");
            }

            PrivacyStatus = status;

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubePlaylistItemStatus"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubePlaylistItemStatus"/>.</returns>
        public static YouTubePlaylistItemStatus Parse(JObject json) {
            return json == null ? null : new YouTubePlaylistItemStatus(json);
        }

        #endregion

    }

}