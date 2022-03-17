using Skybrud.Social.Google.Http;
using Skybrud.Social.Google.OAuth;
using Skybrud.Social.Google.YouTube.Endpoints.Raw;

namespace Skybrud.Social.Google.YouTube.Http {

    /// <summary>
    /// Class representing the raw YouTube endpoint / API implementation.
    /// </summary>
    public class YouTubeHttpClient : GoogleHttpClientBase {

        #region Properties

        /// <summary>
        /// Gets a reference to raw channels endpoint.
        /// </summary>
        public YouTubeChannelsRawEndpoint Channels { get; }

        /// <summary>
        /// Gets a reference to raw playlists endpoint.
        /// </summary>
        public YouTubePlaylistsRawEndpoint Playlists { get; }

        /// <summary>
        /// Gets a reference to raw playlist items endpoint.
        /// </summary>
        public YouTubePlaylistItemsRawEndpoint PlaylistItems { get; }

        /// <summary>
        /// Gets a reference to raw videos endpoint.
        /// </summary>
        public YouTubeVideosRawEndpoint Videos { get; }

        #endregion

        #region Constructors

        internal YouTubeHttpClient(GoogleOAuthClient client) : base(client) {
            Channels = new YouTubeChannelsRawEndpoint(client);
            Playlists = new YouTubePlaylistsRawEndpoint(client);
            PlaylistItems = new YouTubePlaylistItemsRawEndpoint(client);
            Videos = new YouTubeVideosRawEndpoint(client);
        }

        #endregion

    }

}