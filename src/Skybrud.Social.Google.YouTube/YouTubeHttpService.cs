using Skybrud.Social.Google.YouTube.Endpoints;
using Skybrud.Social.Google.YouTube.Http;

namespace Skybrud.Social.Google.YouTube {

    /// <summary>
    /// Strongly typed implementation of the YouTube API.s
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

    }

}