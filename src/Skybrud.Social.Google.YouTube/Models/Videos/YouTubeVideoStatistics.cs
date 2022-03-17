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

        /// <summary>
        /// Gets the number of times the video has been viewed.
        /// </summary>
        public long ViewCount { get; }

        /// <summary>
        /// Gets the number of users who have indicated that they liked the video.
        /// </summary>
        public long LikeCount { get; }

        /// <summary>
        /// Gets the number of users who have indicated that they disliked the video.
        /// </summary>
        public long DislikeCount { get; }

        /// <summary>
        /// Gets the number of comments for the video.
        /// </summary>
        public long CommentCount { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected YouTubeVideoStatistics(JObject json) : base(json) {
            ViewCount = json.GetInt64("viewCount");
            LikeCount = json.GetInt64("likeCount");
            DislikeCount = json.GetInt64("dislikeCount");
            CommentCount = json.GetInt64("commentCount");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubeVideoStatistics"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubeVideoStatistics"/>.</returns>
        public static YouTubeVideoStatistics Parse(JObject json) {
            return json == null ? null : new YouTubeVideoStatistics(json);
        }

        #endregion

    }

}