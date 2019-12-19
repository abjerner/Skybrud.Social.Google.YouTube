using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models.Videos {

    /// <summary>
    /// Class representing a list of <see cref="YouTubeVideo"/> items.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/videos/list</cref>
    /// </see>
    public class YouTubeVideoList : GoogleApiResource {

        #region Properties

        public string NextPageToken { get; }

        public string PrevPageToken { get; }

        public YouTubePageInfo PageInfo { get; }

        public YouTubeVideo[] Items { get; }

        #endregion

        #region Constructors

        protected YouTubeVideoList(JObject obj) : base(obj) {
            NextPageToken = obj.GetString("nextPageToken");
            PrevPageToken = obj.GetString("prevPageToken");
            PageInfo = obj.GetObject("pageInfo", YouTubePageInfo.Parse);
            Items = obj.GetArray("items", YouTubeVideo.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubeVideoList"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubeVideoList"/>.</returns>
        public static YouTubeVideoList Parse(JObject obj) {
            return obj == null ? null : new YouTubeVideoList(obj);
        }

        #endregion

    }

}