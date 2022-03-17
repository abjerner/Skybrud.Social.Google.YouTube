using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models.PlaylistItems {

    public class YouTubePlaylistItemList : GoogleResource {

        #region Properties

        public string NextPageToken { get; }

        public string PrevPageToken { get; }

        public YouTubePageInfo PageInfo { get; }

        public YouTubePlaylistItem[] Items { get; }

        #endregion

        #region Constructors

        protected YouTubePlaylistItemList(JObject obj) : base(obj) {
            NextPageToken = obj.GetString("nextPageToken");
            PrevPageToken = obj.GetString("prevPageToken");
            PageInfo = obj.GetObject("pageInfo", YouTubePageInfo.Parse);
            Items = obj.GetArray("items", YouTubePlaylistItem.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubePlaylistItemList"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubePlaylistItemList"/>.</returns>
        public static YouTubePlaylistItemList Parse(JObject obj) {
            return obj == null ? null : new YouTubePlaylistItemList(obj);
        }

        #endregion

    }

}