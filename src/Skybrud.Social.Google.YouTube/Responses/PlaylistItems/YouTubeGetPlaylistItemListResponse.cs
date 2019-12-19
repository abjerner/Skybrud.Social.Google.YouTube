using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Google.YouTube.Models.PlaylistItems;

namespace Skybrud.Social.Google.YouTube.Responses.PlaylistItems {

    /// <summary>
    /// Class representing the response for getting a list of playlist items.
    /// </summary>
    public class YouTubeGetPlaylistItemListResponse : YouTubeResponse<YouTubePlaylistItemList> {

        #region Constructors

        private YouTubeGetPlaylistItemListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, YouTubePlaylistItemList.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="YouTubeGetPlaylistItemListResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        public static YouTubeGetPlaylistItemListResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new YouTubeGetPlaylistItemListResponse(response);
        }

        #endregion

    }

}