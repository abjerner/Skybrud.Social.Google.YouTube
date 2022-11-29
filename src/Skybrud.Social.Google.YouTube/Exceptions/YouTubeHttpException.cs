using System;
using System.Net;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Exceptions;
using Skybrud.Social.Google.YouTube.Models.Errors;

namespace Skybrud.Social.Google.YouTube.Exceptions {

    /// <summary>
    /// Class representing an exception/error returned by the YouTube API.
    /// </summary>
    public class YouTubeHttpException : Exception, IHttpException {

        #region Properties

        /// <summary>
        /// Gets the status code of the response.
        /// </summary>
        public HttpStatusCode StatusCode => Response.StatusCode;

        /// <summary>
        /// Gets a reference to the underlying <see cref="IHttpResponse"/>.
        /// </summary>
        public IHttpResponse Response { get; }

        /// <summary>
        /// Gets the result of the response.
        /// </summary>
        public YouTubeErrorResult Result { get; }

        #endregion

        #region Constructors

        internal YouTubeHttpException(IHttpResponse response, YouTubeErrorResult result) : base(result.Error.Message) {
            Response = response;
            Result = result;
        }

        #endregion

    }

}