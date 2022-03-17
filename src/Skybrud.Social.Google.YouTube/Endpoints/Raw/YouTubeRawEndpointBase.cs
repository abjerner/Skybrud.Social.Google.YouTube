using Skybrud.Social.Google.OAuth;

// ReSharper disable InconsistentNaming

namespace Skybrud.Social.Google.YouTube.Endpoints.Raw {

    /// <summary>
    /// Class representing a base for a raw endpoint implementation.
    /// </summary>
    public abstract class YouTubeRawEndpointBase {

        /// <summary>
        /// Gets a reference to the underlying <see cref="GoogleOAuthClient"/>.
        /// </summary>
        protected GoogleOAuthClient Client { get; }

        /// <summary>
        /// Initializes a new instance based on the specified OAuth <paramref name="client"/>.
        /// </summary>
        /// <param name="client">An instance of <see cref="GoogleOAuthClient"/>.</param>
        protected YouTubeRawEndpointBase(GoogleOAuthClient client) {
            Client = client;
        }

    }

}