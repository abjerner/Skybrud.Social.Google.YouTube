using System;

namespace Skybrud.Social.Google.YouTube.Exceptions {

    /// <summary>
    /// Class representing a basic YouTube exception.
    /// </summary>
    public class YouTubeException : Exception {

        /// <summary>
        /// Initializes a new exception with the specified <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        public YouTubeException(string message) : base(message) { }

    }

}