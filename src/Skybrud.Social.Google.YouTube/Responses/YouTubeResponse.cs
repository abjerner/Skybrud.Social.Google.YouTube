using System.Net;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.Google.YouTube.Exceptions;

namespace Skybrud.Social.Google.YouTube.Responses {

    /// <summary>
    /// Class representing a response from the YouTube API.
    /// </summary>
    public class YouTubeResponse : HttpResponseBase {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The underlying raw response the instance should be based on.</param>
        protected YouTubeResponse(IHttpResponse response) : base(response) {

            // Skip error checking if the server responds with a successful status code
            if (response.StatusCode == HttpStatusCode.OK) return;
            if (response.StatusCode == HttpStatusCode.Created) return;

            JObject obj = ParseJsonObject(response.Body);

            JObject error = obj.GetObject("error")!;
            
            string message = error.GetString("message")!;

            // TODO: Parse "errors"

            throw new YouTubeHttpException(response, message);

        }

        #endregion

    }

    /// <summary>
    /// Class representing a response from the YouTube API.
    /// </summary>
    public class YouTubeResponse<T> : YouTubeResponse {

        /// <summary>
        /// Gets the body of the response.
        /// </summary>
        public T Body { get; protected set; } = default!;

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The underlying raw response the instance should be based on.</param>
        protected YouTubeResponse(IHttpResponse response) : base(response) { }

    }

}