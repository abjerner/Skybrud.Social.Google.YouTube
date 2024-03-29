using System.Collections.Generic;

namespace Skybrud.Social.Google.YouTube.Options.Channels {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/channels/list#part</cref>
    /// </see>
    public static class YouTubeChannelParts {

        #region Properties

        /// <summary>
        /// Indicates that the response from the YouTube API should include the ID of the channel.
        /// </summary>
        public static readonly YouTubeChannelPart Id = new("id");

        /// <summary>
        /// Indicates that the response from the YouTube API should include the <c>snippet</c> object of the channel.
        /// </summary>
        public static readonly YouTubeChannelPart Snippet = new("snippet");

        /// <summary>
        /// Indicates that the response from the YouTube API should include the <c>contentDetails</c> object of the channel.
        /// </summary>
        public static readonly YouTubeChannelPart ContentDetails = new("contentDetails");

        /// <summary>
        /// Indicates that the response from the YouTube API should include the <c>statistics</c> object of the channel.
        /// </summary>
        public static readonly YouTubeChannelPart Statistics = new("statistics");

        /// <summary>
        /// Indicates that the response from the YouTube API should include the <c>status</c> object of the channel.
        /// </summary>
        public static readonly YouTubeChannelPart Status = new("status");

        /// <summary>
        /// Indicates that the response from the YouTube API should include the <c>topicDetails</c> object of the channel.
        /// </summary>
        public static readonly YouTubeChannelPart TopicDetails = new("topicDetails");

        /// <summary>
        /// Gets a collection of all parts available for a YouTube channel.
        /// </summary>
        public static readonly YouTubeChannelPartList All = new(
            Id, Snippet, ContentDetails, Statistics, Status, TopicDetails
        );

        /// <summary>
        /// Gets an array of <see cref="YouTubeChannelPart"/> representing all parts available for a YouTube channel.
        /// </summary>
        public static IReadOnlyList<YouTubeChannelPart> Values => All.ToArray();

        #endregion

    }

}