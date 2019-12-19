using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Google.YouTube.Models.Videos;

namespace Skybrud.Social.Google.YouTube.Responses.Videos {

    /// <summary>
    /// Class representing the response for getting a list of videos.
    /// </summary>
    public class YouTubeGetVideoListResponse : YouTubeResponse<YouTubeVideoList> {

        #region Constructors

        private YouTubeGetVideoListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, YouTubeVideoList.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="YouTubeGetVideoListResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        public static YouTubeGetVideoListResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new YouTubeGetVideoListResponse(response);
        }

        #endregion

    }

}