using System;
using Skybrud.Social.Google.YouTube.Endpoints.Raw;
using Skybrud.Social.Google.YouTube.Options.Playlists;
using Skybrud.Social.Google.YouTube.Responses.Playlist;

namespace Skybrud.Social.Google.YouTube.Endpoints {

    /// <summary>
    /// Class representing the playlists endpoint.
    /// </summary>
    public class YouTubePlaylistsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the YouTube service implementation.
        /// </summary>
        public YouTubeHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public YouTubePlaylistsRawEndpoint Raw => Service.Client.Playlists;

        #endregion

        #region Constructors

        internal YouTubePlaylistsEndpoint(YouTubeHttpService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of playlists for the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="YouTubeGetPlaylistListResponse"/> representing the response.</returns>
        public YouTubeGetPlaylistListResponse GetPlaylists() {
            return YouTubeGetPlaylistListResponse.ParseResponse(Raw.GetPlaylists());
        }

        /// <summary>
        /// Gets a list of playlists for the specified <paramref name="channelId"/>.
        /// </summary>
        /// <param name="channelId">The ID of the channel.</param>
        /// <returns>An instance of <see cref="YouTubeGetPlaylistListResponse"/> representing the response.</returns>
        public YouTubeGetPlaylistListResponse GetPlaylists(string channelId) {
            return YouTubeGetPlaylistListResponse.ParseResponse(Raw.GetPlaylists(channelId));
        }

        /// <summary>
        /// Gets a list of playlists based on the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="YouTubeGetPlaylistListResponse"/> representing the response.</returns>
        public YouTubeGetPlaylistListResponse GetPlaylists(YouTubeGetPlaylistListOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return YouTubeGetPlaylistListResponse.ParseResponse(Raw.GetPlaylists(options));
        }

        #endregion

    }

}