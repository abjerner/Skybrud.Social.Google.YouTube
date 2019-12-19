using Skybrud.Social.Google.OAuth;

// ReSharper disable InconsistentNaming

namespace Skybrud.Social.Google.YouTube.Endpoints.Raw {

    /// <summary>
    /// Class representing a base for a raw endpoint implementation.
    /// </summary>
    public abstract class YouTubeRawEndpointBase {

        protected GoogleOAuthClient Client { get; }

        protected YouTubeRawEndpointBase(GoogleOAuthClient client) {
            Client = client;
        }

    }

}