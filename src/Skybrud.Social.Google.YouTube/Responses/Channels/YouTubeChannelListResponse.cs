using Skybrud.Essentials.Http;
using Skybrud.Social.Google.YouTube.Models.Channels;

namespace Skybrud.Social.Google.YouTube.Responses.Channels {

    /// <summary>
    /// Class representing the response for getting a list of channels.
    /// </summary>
    public class YouTubeChannelListResponse : YouTubeResponse<YouTubeChannelList> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The underlying raw response the instance should be based on.</param>
        public YouTubeChannelListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, YouTubeChannelList.Parse)!;
        }

    }

}