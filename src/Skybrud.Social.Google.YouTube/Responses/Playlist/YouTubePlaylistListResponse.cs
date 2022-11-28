using Skybrud.Essentials.Http;
using Skybrud.Social.Google.YouTube.Models.Playlists;

namespace Skybrud.Social.Google.YouTube.Responses.Playlist {

    /// <summary>
    /// Class representing the response for getting a list of playlists.
    /// </summary>
    public class YouTubePlaylistListResponse : YouTubeResponse<YouTubePlaylistList> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The underlying raw response the instance should be based on.</param>
        public YouTubePlaylistListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, YouTubePlaylistList.Parse)!;
        }

    }

}