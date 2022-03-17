using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models.PlaylistItems {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlistItems#status</cref>
    /// </see>    
    public class YouTubePlaylistItemStatus : GoogleObject {

        #region Properties

        public YouTubePrivacyStatus PrivacyStatus { get; }

        #endregion

        #region Constructor

        protected YouTubePlaylistItemStatus(JObject obj) : base(obj) {

            // Parse the privacy status
            string strStatus = obj.GetString("privacyStatus");
            if (Enum.TryParse(strStatus, true, out YouTubePrivacyStatus status) == false) {
                throw new Exception("Unknown privacy status \"" + strStatus + "\" - please create an issue so it can be fixed https://github.com/abjerner/Skybrud.Social.Google.YouTube/issues/new");
            }

            PrivacyStatus = status;

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubePlaylistItemStatus"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubePlaylistItemStatus"/>.</returns>
        public static YouTubePlaylistItemStatus Parse(JObject obj) {
            return obj == null ? null : new YouTubePlaylistItemStatus(obj);
        }

        #endregion

    }

}