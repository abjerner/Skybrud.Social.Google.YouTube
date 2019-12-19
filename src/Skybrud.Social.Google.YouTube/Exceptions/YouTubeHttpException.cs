using System;
using System.Net;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Exceptions;

namespace Skybrud.Social.Google.YouTube.Exceptions {

    /// <summary>
    /// Class representing an exception/error returned by the YouTube API.
    /// </summary>
    public class YouTubeHttpException : Exception, IHttpException {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <see cref="IHttpResponse"/>.
        /// </summary>
        public IHttpResponse Response { get; }

        /// <summary>
        /// Gets the status code of the response.
        /// </summary>
        public HttpStatusCode StatusCode => Response.StatusCode;

        #endregion

        #region Constructors

        internal YouTubeHttpException(IHttpResponse response, string message) : base(message) {
            Response = response;
        }

        #endregion

    }

}