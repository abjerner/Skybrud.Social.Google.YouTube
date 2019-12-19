using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Google.YouTube.Models.Channels;

namespace Skybrud.Social.Google.YouTube.Responses.Channels {

    /// <summary>
    /// Class representing the response for getting a list of channels.
    /// </summary>
    public class YouTubeGetChannelListResponse : YouTubeResponse<YouTubeChannelList> {

        #region Constructors

        private YouTubeGetChannelListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, YouTubeChannelList.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="YouTubeGetChannelListResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        public static YouTubeGetChannelListResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new YouTubeGetChannelListResponse(response);
        }

        #endregion

    }

}