using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Google.YouTube.Models.Playlists;

namespace Skybrud.Social.Google.YouTube.Responses.Playlist {

    /// <summary>
    /// Class representing the response for getting a list of playlists.
    /// </summary>
    public class YouTubeGetPlaylistListResponse : YouTubeResponse<YouTubePlaylistList> {

        #region Constructors

        private YouTubeGetPlaylistListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, YouTubePlaylistList.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="YouTubeGetPlaylistListResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        public static YouTubeGetPlaylistListResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new YouTubeGetPlaylistListResponse(response);
        }

        #endregion

    }

}