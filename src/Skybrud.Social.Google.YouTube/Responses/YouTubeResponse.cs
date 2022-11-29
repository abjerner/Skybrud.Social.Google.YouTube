using System.Net;
using Skybrud.Essentials.Http;
using Skybrud.Social.Google.YouTube.Exceptions;
using Skybrud.Social.Google.YouTube.Models.Errors;

// ReSharper disable SwitchStatementHandlesSomeKnownEnumValuesWithDefault

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

            switch (response.StatusCode) {

                // Skip error checking if the server responds with a successful status code
                case HttpStatusCode.OK:
                case HttpStatusCode.Created:
                    return;

                default:
                    YouTubeErrorResult result = ParseJsonObject(response.Body, YouTubeErrorResult.Parse)!;
                    throw new YouTubeHttpException(response, result);

            }

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