using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models.Videos {

    /// <summary>
    /// Class representing the <c>statistics</c> part of a YouTube video.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/videos#statistics</cref>
    /// </see>
    public class YouTubeVideoStatistics : GoogleObject {

        #region Properties

        public long ViewCount { get; }

        public long LikeCount { get; }

        public long DislikeCount { get; }

        public long FavoriteCount { get; }

        public long CommentCount { get; }

        #endregion

        #region Constructors

        protected YouTubeVideoStatistics(JObject obj) : base(obj) {
            ViewCount = obj.GetInt64("viewCount");
            LikeCount = obj.GetInt64("likeCount");
            DislikeCount = obj.GetInt64("dislikeCount");
            FavoriteCount = obj.GetInt64("favoriteCount");
            CommentCount = obj.GetInt64("commentCount");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubeVideoStatistics"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubeVideoStatistics"/>.</returns>
        public static YouTubeVideoStatistics Parse(JObject obj) {
            return obj == null ? null : new YouTubeVideoStatistics(obj);
        }

        #endregion

    }

}