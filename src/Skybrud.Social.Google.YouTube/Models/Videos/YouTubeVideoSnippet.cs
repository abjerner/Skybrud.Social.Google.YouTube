using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models.Videos {

    /// <summary>
    /// Class representing the <c>snippet</c> part of a YouTube video.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/videos#snippet</cref>
    /// </see>
    public class YouTubeVideoSnippet : GoogleObject {

        #region Properties
        
        /// <summary>
        /// Gets or sets the publish date of the video.
        /// </summary>
        public EssentialsTime PublishedAt { get; }

        /// <summary>
        /// Gets or sets the ID of the parent channel.
        /// </summary>
        public string ChannelId { get; }

        /// <summary>
        /// Gets or sets the title of the YouTube video.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Gets or sets the description of the video.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets or set information about the thumbnails available for the video.
        /// </summary>
        public YouTubeVideoThumbnails Thumbnails { get; }

        /// <summary>
        /// Gets or sets the title of the parent channel.
        /// </summary>
        public string ChannelTitle { get; }

        /// <summary>
        /// Gets an array with all tags of the video.
        /// </summary>
        public string[] Tags { get; }

        public string CategoryId { get; }

        /// <summary>
        /// Gets othe <c>liveBroadcastContent</c> property.
        /// </summary>
        public YouTubeVideoLiveBroadcastContent LiveBroadcastContent { get; } 

        #endregion
        
        #region Constructors

        private YouTubeVideoSnippet(JObject obj) : base(obj) {

            // Parse the "liveBroadcastContent" property
            string strBroadcast = obj.GetString("liveBroadcastContent");
            if (!Enum.TryParse(strBroadcast, true, out YouTubeVideoLiveBroadcastContent broadcast)) {
                throw new Exception("Unknown value for liveBroadcastContent \"" + strBroadcast + "\" - please create an issue so it can be fixed https://github.com/abjerner/Skybrud.Social.Google/issues/new");
            }

            // Initialize the snippet object
            PublishedAt = obj.GetString("publishedAt", EssentialsTime.Parse);
            ChannelId = obj.GetString("channelId");
            Title = obj.GetString("title");
            Description = obj.GetString("description");
            Thumbnails = obj.GetObject("thumbnails", YouTubeVideoThumbnails.Parse);
            ChannelTitle = obj.GetString("channelTitle");
            Tags = obj.GetStringArray("tags");
            CategoryId = obj.GetString("categoryId");
            LiveBroadcastContent = broadcast;

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubeVideoSnippet"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubeVideoSnippet"/>.</returns>
        public static YouTubeVideoSnippet Parse(JObject obj) {
            return obj == null ? null : new YouTubeVideoSnippet(obj);
        }

        #endregion

    }

}