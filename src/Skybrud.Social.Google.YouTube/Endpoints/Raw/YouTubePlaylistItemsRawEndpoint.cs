using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Google.OAuth;
using Skybrud.Social.Google.YouTube.Options.PlaylistItems;

namespace Skybrud.Social.Google.YouTube.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw playlist items endpoint.
    /// </summary>
    public class YouTubePlaylistItemsRawEndpoint : YouTubeRawEndpointBase {

        #region Constructors

        internal YouTubePlaylistItemsRawEndpoint(GoogleOAuthClient client) : base(client) { }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of playlist items for the specified <paramref name="playlistId"/>.
        /// </summary>
        /// <param name="playlistId">The ID of the playlist.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetPlaylistItems(string playlistId) {
            if (string.IsNullOrWhiteSpace(playlistId)) throw new ArgumentNullException(nameof(playlistId));
            return GetPlaylistItems(new YouTubeGetPlaylistItemListOptions(playlistId));
        }

        /// <summary>
        /// Gets a list of playlist items based on the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetPlaylistItems(YouTubeGetPlaylistItemListOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}