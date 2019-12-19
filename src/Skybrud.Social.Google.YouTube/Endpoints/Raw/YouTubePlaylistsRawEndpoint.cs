using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Google.OAuth;
using Skybrud.Social.Google.YouTube.Options.Playlists;

namespace Skybrud.Social.Google.YouTube.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw playlists endpoint.
    /// </summary>
    public class YouTubePlaylistsRawEndpoint : YouTubeRawEndpointBase {

        #region Constructors

        internal YouTubePlaylistsRawEndpoint(GoogleOAuthClient client) : base(client) { }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of playlists for the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetPlaylists() {
            return GetPlaylists(new YouTubeGetPlaylistListOptions(true));
        }

        /// <summary>
        /// Gets a list of playlists for the specified <paramref name="channelId"/>.
        /// </summary>
        /// <param name="channelId">The ID of the channel.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetPlaylists(string channelId) {
            if (string.IsNullOrWhiteSpace(channelId)) throw new ArgumentNullException(nameof(channelId));
            return GetPlaylists(new YouTubeGetPlaylistListOptions(channelId));
        }

        /// <summary>
        /// Gets a list of playlists based on the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetPlaylists(YouTubeGetPlaylistListOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}