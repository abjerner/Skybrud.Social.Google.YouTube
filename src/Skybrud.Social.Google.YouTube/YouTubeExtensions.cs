using System;
using Skybrud.Social.Google.OAuth;
using Skybrud.Social.Google.YouTube.Http;

namespace Skybrud.Social.Google.YouTube {

    public static class YouTubeExtensions {

        public static YouTubeHttpClient YouTube(this GoogleOAuthClient client) {
            if (client == null) throw new ArgumentNullException(nameof(client));
            return client.GetApiClient(() => new YouTubeHttpClient(client));
        }

        public static YouTubeService YouTube(this GoogleHttpService service) {
            if (service == null) throw new ArgumentNullException(nameof(service));
            return service.GetApiService(() => new YouTubeService(service));
        }

    }

}