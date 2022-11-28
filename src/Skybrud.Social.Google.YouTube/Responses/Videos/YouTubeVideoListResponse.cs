using Skybrud.Essentials.Http;
using Skybrud.Social.Google.YouTube.Models.Videos;

namespace Skybrud.Social.Google.YouTube.Responses.Videos {

    /// <summary>
    /// Class representing the response for getting a list of videos.
    /// </summary>
    public class YouTubeVideoListResponse : YouTubeResponse<YouTubeVideoList> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The underlying raw response the instance should be based on.</param>
        public YouTubeVideoListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, YouTubeVideoList.Parse)!;
        }

    }

}