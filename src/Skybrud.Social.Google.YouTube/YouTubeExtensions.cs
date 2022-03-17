using System;
using Skybrud.Social.Google.OAuth;
using Skybrud.Social.Google.YouTube.Http;

namespace Skybrud.Social.Google.YouTube {

    /// <summary>
    /// Static class with extension methods for the YouTube API integration.
    /// </summary>
    public static class YouTubeExtensions {

        /// <summary>
        /// Gets a reference to the YouTube HTTP client.
        /// </summary>
        /// <param name="client">The Google OAuth client instance.</param>
        /// <returns>An instance of <see cref="YouTubeHttpClient"/>.</returns>
        public static YouTubeHttpClient YouTube(this GoogleOAuthClient client) {
            if (client == null) throw new ArgumentNullException(nameof(client));
            return client.GetHttpClient(() => new YouTubeHttpClient(client));
        }

        /// <summary>
        /// Gets a reference to the YouTube HTTP service.
        /// </summary>
        /// <param name="service">A Google HTTP service instance.</param>
        /// <returns>An instance of <see cref="YouTubeHttpService"/>.</returns>
        public static YouTubeHttpService YouTube(this GoogleHttpService service) {
            if (service == null) throw new ArgumentNullException(nameof(service));
            return service.GetHttpService(() => new YouTubeHttpService(service));
        }

    }

}