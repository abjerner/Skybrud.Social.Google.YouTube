using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Google.OAuth;
using Skybrud.Social.Google.YouTube.Options.Channels;

namespace Skybrud.Social.Google.YouTube.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw channels endpoint.
    /// </summary>
    public class YouTubeChannelsRawEndpoint : YouTubeRawEndpointBase {

        #region Constructors

        internal YouTubeChannelsRawEndpoint(GoogleOAuthClient client) : base(client) { }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of channels for the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetChannels() {
            return GetChannels(new YouTubeGetChannelListOptions {
                Part = YouTubeChannelParts.Snippet,
                Mine = true
            });
        }

        /// <summary>
        /// Gets a list of channels for the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetChannels(string username) {
            return GetChannels(new YouTubeGetChannelListOptions {
                Part = YouTubeChannelParts.Snippet,
                Username = username
            });
        }

        /// <summary>
        /// Gets a list of channels based on the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetChannels(YouTubeGetChannelListOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}