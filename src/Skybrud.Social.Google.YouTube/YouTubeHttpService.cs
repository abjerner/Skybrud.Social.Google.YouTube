using Skybrud.Social.Google.YouTube.Endpoints;
using Skybrud.Social.Google.YouTube.Http;

namespace Skybrud.Social.Google.YouTube {

    /// <summary>
    /// Strongly typed implementation of the YouTube APIs.
    /// </summary>
    public class YouTubeHttpService : GoogleHttpServiceBase {

        #region Properties

        /// <summary>
        /// Gets a reference to the raw YouTube endpoint.
        /// </summary>
        public YouTubeHttpClient Client => Service.Client.YouTube();

        /// <summary>
        /// Gets a reference to the channels endpoint.
        /// </summary>
        public YouTubeChannelsEndpoint Channels { get; }

        /// <summary>
        /// Gets a reference to the playlists endpoint.
        /// </summary>
        public YouTubePlaylistsEndpoint Playlists { get; }

        /// <summary>
        /// Gets a reference to the playlists items endpoint.
        /// </summary>
        public YouTubePlaylistItemsEndpoint PlaylistItems { get; }

        /// <summary>
        /// Gets a reference to the videos endpoint.
        /// </summary>
        public YouTubeVideosEndpoint Videos { get; }

        #endregion

        #region Constructors

        internal YouTubeHttpService(GoogleHttpService service) : base(service) {
            Channels = new YouTubeChannelsEndpoint(this);
            Playlists = new YouTubePlaylistsEndpoint(this);
            PlaylistItems = new YouTubePlaylistItemsEndpoint(this);
            Videos = new YouTubeVideosEndpoint(this);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="apiKey"/>. The API key is tied to
        /// your app, whereas an access token or refresh token is tied the a specific user of your app. Calling this
        /// method will not make any calls to the Google Accounts API.
        /// </summary>
        /// <param name="apiKey">The API key of your app.</param>
        /// <returns>An instance of <see cref="YouTubeHttpService"/>.</returns>
        public static YouTubeHttpService CreateFromApiKey(string apiKey) {
            return GoogleHttpService.CreateFromApiKey(apiKey).YouTube();
        }

        /// <summary>
        /// Initializes a new instance based on an access token. Calling this method will not make any calls to the
        /// Google Accounts API.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <returns>An instance of <see cref="YouTubeHttpService"/>.</returns>
        public static YouTubeHttpService CreateFromAccessToken(string accessToken) {
            return GoogleHttpService.CreateFromAccessToken(accessToken).YouTube();
        }

        /// <summary>
        /// Initializes a new instance based on the specified refresh token. The refresh token is used for making a
        /// call to the Google Accounts API to get a new access token. Access tokens typically expire after an hour
        /// (3600 seconds).
        /// </summary>
        /// <param name="clientId">The client ID.</param>
        /// <param name="clientSecret">The client secret.</param>
        /// <param name="refreshToken">The refresh token of the user.</param>
        /// <returns>An instance of <see cref="YouTubeHttpService"/>.</returns>
        public static YouTubeHttpService CreateFromRefreshToken(string clientId, string clientSecret, string refreshToken) {
            return GoogleHttpService.CreateFromRefreshToken(clientId, clientSecret, refreshToken).YouTube();
        }

        #endregion

    }

}