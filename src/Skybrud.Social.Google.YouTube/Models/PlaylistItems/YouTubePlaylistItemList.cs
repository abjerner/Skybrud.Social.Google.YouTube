using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.Google.Models;
using Skybrud.Social.Google.YouTube.Options.Playlists;

namespace Skybrud.Social.Google.YouTube.Models.PlaylistItems {

    /// <summary>
    /// Class representing a list of <see cref="YouTubePlaylistItem"/>.
    /// </summary>
    public class YouTubePlaylistItemList : GoogleResource {

        #region Properties

        /// <summary>
        /// Gets the token that can be used as the value of the <see cref="YouTubeGetPlaylistListOptions.PageToken"/>
        /// parameter to retrieve the next page in the result set.
        /// </summary>
        public string NextPageToken { get; }

        /// <summary>
        /// Gets the token that can be used as the value of the <see cref="YouTubeGetPlaylistListOptions.PageToken"/>
        /// parameter to retrieve the previous page in the result set.
        /// </summary>
        public string PrevPageToken { get; }

        /// <summary>
        /// Gets a reference to an object that encapsulates paging information for the result set.
        /// </summary>
        public YouTubePageInfo PageInfo { get; }

        /// <summary>
        /// Gets an array of the playlist items returned in the response.
        /// </summary>
        public YouTubePlaylistItem[] Items { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected YouTubePlaylistItemList(JObject json) : base(json) {
            NextPageToken = json.GetString("nextPageToken");
            PrevPageToken = json.GetString("prevPageToken");
            PageInfo = json.GetObject("pageInfo", YouTubePageInfo.Parse);
            Items = json.GetArray("items", YouTubePlaylistItem.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubePlaylistItemList"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubePlaylistItemList"/>.</returns>
        public static YouTubePlaylistItemList Parse(JObject json) {
            return json == null ? null : new YouTubePlaylistItemList(json);
        }

        #endregion

    }

}