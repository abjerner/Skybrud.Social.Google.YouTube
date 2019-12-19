using Skybrud.Social.Google.YouTube.Endpoints.Raw;
using Skybrud.Social.Google.YouTube.Options.PlaylistItems;
using Skybrud.Social.Google.YouTube.Responses.PlaylistItems;

namespace Skybrud.Social.Google.YouTube.Endpoints {

    /// <summary>
    /// Class representing the playlist items endpoint.
    /// </summary>
    public class YouTubePlaylistItemsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the YouTube service implementation.
        /// </summary>
        public YouTubeService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public YouTubePlaylistItemsRawEndpoint Raw => Service.Client.PlaylistItems;

        #endregion

        #region Constructors

        internal YouTubePlaylistItemsEndpoint(YouTubeService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of playlist items for the specified <paramref name="playlistId"/>.
        /// </summary>
        /// <param name="playlistId">The ID of the playlist.</param>
        /// <returns>An instance of <see cref="YouTubeGetPlaylistItemListResponse"/> representing the response.</returns>
        public YouTubeGetPlaylistItemListResponse GetPlaylistItems(string playlistId) {
            return YouTubeGetPlaylistItemListResponse.ParseResponse(Raw.GetPlaylistItems(playlistId));
        }

        /// <summary>
        /// Gets a list of playlist items based on the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="YouTubeGetPlaylistItemListResponse"/> representing the response.</returns>
        public YouTubeGetPlaylistItemListResponse GetPlaylistItems(YouTubeGetPlaylistItemListOptions options) {
            return YouTubeGetPlaylistItemListResponse.ParseResponse(Raw.GetPlaylistItems(options));
        }

        #endregion

    }

}