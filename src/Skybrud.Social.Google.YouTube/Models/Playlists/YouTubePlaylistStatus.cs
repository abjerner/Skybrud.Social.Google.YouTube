using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models.Playlists {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlists#status</cref>
    /// </see>
    public class YouTubePlaylistStatus : GoogleObject {

        #region Properties

        /// <summary>
        /// Gets the playlist's privacy status.
        /// </summary>
        public YouTubePrivacyStatus PrivacyStatus { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected YouTubePlaylistStatus(JObject json) : base(json) {

            // Parse the privacy status
            string strStatus = json.GetString("privacyStatus");
            if (!Enum.TryParse(strStatus, true, out YouTubePrivacyStatus status)) {
                throw new Exception("Unknown privacy status \"" + strStatus + "\" - please create an issue so it can be fixed https://github.com/abjerner/Skybrud.Social/issues/new");
            }

            PrivacyStatus = status;

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubePlaylistStatus"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubePlaylistStatus"/>.</returns>
        public static YouTubePlaylistStatus Parse(JObject json) {
            return json == null ? null : new YouTubePlaylistStatus(json);
        }

        #endregion

    }

}