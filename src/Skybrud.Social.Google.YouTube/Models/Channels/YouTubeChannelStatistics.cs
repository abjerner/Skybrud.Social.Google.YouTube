using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models.Channels {

    /// <summary>
    /// Class representing the <c>statistics</c> object of a TouTube channel.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/channels#statistics</cref>
    /// </see>
    public class YouTubeChannelStatistics : GoogleObject {

        #region Properties

        /// <summary>
        /// Gets the number of times the channel has been viewed.
        /// </summary>
        public long ViewCount { get; }

        /// <summary>
        /// Gets the number of comments the channel has received.
        /// </summary>
        public long CommentCount { get; }

        /// <summary>
        /// Gets the number of subscribers of the channel.
        /// </summary>
        public long SubscriberCount { get; }

        /// <summary>
        /// Gets whether the subscriber count of the channel is hidden or publicly visible.
        /// </summary>
        public bool HiddenSubscriberCount { get; }

        /// <summary>
        /// Gets the number of videos uploaded to the channel.
        /// </summary>
        public long VideoCount { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected YouTubeChannelStatistics(JObject json) : base(json) {
            ViewCount = json.GetInt64("viewCount");
            CommentCount = json.GetInt64("commentCount");
            SubscriberCount = json.GetInt64("subscriberCount");
            HiddenSubscriberCount = json.GetBoolean("hiddenSubscriberCount");
            VideoCount = json.GetInt64("videoCount");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubeChannelStatistics"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubeChannelStatistics"/>.</returns>
        public static YouTubeChannelStatistics Parse(JObject json) {
            return json == null ? null : new YouTubeChannelStatistics(json);
        }

        #endregion

    }

}