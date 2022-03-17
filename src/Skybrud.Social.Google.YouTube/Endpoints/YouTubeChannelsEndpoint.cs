using Skybrud.Social.Google.YouTube.Endpoints.Raw;
using Skybrud.Social.Google.YouTube.Options.Channels;
using Skybrud.Social.Google.YouTube.Responses.Channels;

namespace Skybrud.Social.Google.YouTube.Endpoints {

    /// <summary>
    /// Class representing the channels endpoint.
    /// </summary>
    public class YouTubeChannelsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the YouTube service implementation.
        /// </summary>
        public YouTubeHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public YouTubeChannelsRawEndpoint Raw => Service.Client.Channels;

        #endregion

        #region Constructors

        internal YouTubeChannelsEndpoint(YouTubeHttpService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of channels for the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="YouTubeChannelListResponse"/> representing the response.</returns>
        public YouTubeChannelListResponse GetChannels() {
            return new YouTubeChannelListResponse(Raw.GetChannels());
        }

        /// <summary>
        /// Gets a list of channels for the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>An instance of <see cref="YouTubeChannelListResponse"/> representing the response.</returns>
        public YouTubeChannelListResponse GetChannels(string username) {
            return new YouTubeChannelListResponse(Raw.GetChannels(username));
        }

        /// <summary>
        /// Gets a list of channels based on the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="YouTubeChannelListResponse"/> representing the response.</returns>
        public YouTubeChannelListResponse GetChannels(YouTubeGetChannelListOptions options) {
            return new YouTubeChannelListResponse(Raw.GetChannels(options));
        }

        #endregion

    }

}