using Skybrud.Essentials.Http;
using Skybrud.Social.Google.YouTube.Models.PlaylistItems;

namespace Skybrud.Social.Google.YouTube.Responses.PlaylistItems {

    /// <summary>
    /// Class representing the response for getting a list of playlist items.
    /// </summary>
    public class YouTubePlaylistItemListResponse : YouTubeResponse<YouTubePlaylistItemList> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The underlying raw response the instance should be based on.</param>
        public YouTubePlaylistItemListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, YouTubePlaylistItemList.Parse)!;
        }

    }

}