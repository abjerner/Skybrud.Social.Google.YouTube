﻿using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models.Channels {

    /// <summary>
    /// Class representing a collection of thumbnail images for the channel.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/channels#snippet.thumbnails</cref>
    /// </see>
    public class YouTubeChannelThumbnails : GoogleObject {

        #region Properties

        /// <summary>
        /// Gets a reference to the default thumbnail of the channel. The default thumbnail for a channel is <c>88px</c> wide and <c>88px</c> tall.
        /// </summary>
        public YouTubeChannelThumbnail Default { get; }

        /// <summary>
        /// Gets a reference to a higher resolution version of the thumbnail image. For a channel, this image is <c>240px</c> wide and <c>240px</c> tall.
        /// </summary>
        public YouTubeChannelThumbnail Medium { get; }

        /// <summary>
        /// Gets a reference to a high resolution version of the thumbnail image. For a channel, this image is <c>800px</c> wide and <c>800px</c> tall.
        /// </summary>
        public YouTubeChannelThumbnail High { get; }

        #endregion

        #region Constructors

        private YouTubeChannelThumbnails(JObject obj) : base(obj) {
            Default = obj.GetObject("default", YouTubeChannelThumbnail.Parse);
            Medium = obj.GetObject("medium", YouTubeChannelThumbnail.Parse);
            High = obj.GetObject("high", YouTubeChannelThumbnail.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubeChannelThumbnails"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubeChannelThumbnails"/>.</returns>
        public static YouTubeChannelThumbnails Parse(JObject obj) {
            return obj == null ? null : new YouTubeChannelThumbnails(obj);
        }

        #endregion

    }

}