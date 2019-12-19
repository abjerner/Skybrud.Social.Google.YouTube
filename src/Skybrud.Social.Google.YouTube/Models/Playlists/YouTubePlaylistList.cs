using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models.Playlists {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlists/list</cref>
    /// </see>
    public class YouTubePlaylistList : GoogleApiResource {

        #region Properties

        public string NextPageToken { get; }

        public string PrevPageToken { get; }

        public YouTubePageInfo PageInfo { get; }

        public YouTubePlaylist[] Items { get; }

        #endregion

        #region Constructors

        protected YouTubePlaylistList(JObject obj) : base(obj) {
            NextPageToken = obj.GetString("nextPageToken");
            PrevPageToken = obj.GetString("prevPageToken");
            PageInfo = obj.GetObject("pageInfo", YouTubePageInfo.Parse);
            Items = obj.GetArray("items", YouTubePlaylist.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubePlaylistList"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubePlaylistList"/>.</returns>
        public static YouTubePlaylistList Parse(JObject obj) {
            return obj == null ? null : new YouTubePlaylistList(obj);
        }

        #endregion

    }

}