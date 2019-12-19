using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Google.OAuth;
using Skybrud.Social.Google.YouTube.Options.Videos;

namespace Skybrud.Social.Google.YouTube.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw videos endpoint.
    /// </summary>
    public class YouTubeVideosRawEndpoint : YouTubeRawEndpointBase {

        #region Constructors

        internal YouTubeVideosRawEndpoint(GoogleOAuthClient client) : base(client) { }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of videos based on the specified <paramref name="videoId"/>.
        /// </summary>
        /// <param name="videoId">The ID of the video to be returned.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetVideos(string videoId) {
            if (string.IsNullOrWhiteSpace(videoId)) throw new ArgumentNullException(nameof(videoId));
            return GetVideos(new YouTubeGetVideoListOptions(videoId));
        }

        /// <summary>
        /// Gets a list of videos based on the specified <paramref name="videoIds"/>.
        /// </summary>
        /// <param name="videoIds">The IDs of videos to be returned.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetVideos(params string[] videoIds) {
            if (videoIds == null) throw new ArgumentNullException(nameof(videoIds));
            return GetVideos(new YouTubeGetVideoListOptions(videoIds));
        }

        /// <summary>
        /// Gets a list of videos based on the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetVideos(YouTubeGetVideoListOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}