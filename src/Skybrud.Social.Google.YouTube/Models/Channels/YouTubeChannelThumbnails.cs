using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
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
        public YouTubeChannelThumbnail? Default { get; }

        /// <summary>
        /// Gets a reference to a higher resolution version of the thumbnail image. For a channel, this image is <c>240px</c> wide and <c>240px</c> tall.
        /// </summary>
        public YouTubeChannelThumbnail? Medium { get; }

        /// <summary>
        /// Gets a reference to a high resolution version of the thumbnail image. For a channel, this image is <c>800px</c> wide and <c>800px</c> tall.
        /// </summary>
        public YouTubeChannelThumbnail? High { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected YouTubeChannelThumbnails(JObject json) : base(json) {
            Default = json.GetObject("default", YouTubeChannelThumbnail.Parse);
            Medium = json.GetObject("medium", YouTubeChannelThumbnail.Parse);
            High = json.GetObject("high", YouTubeChannelThumbnail.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubeChannelThumbnails"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubeChannelThumbnails"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static YouTubeChannelThumbnails? Parse(JObject? json) {
            return json == null ? null : new YouTubeChannelThumbnails(json);
        }

        #endregion

    }

}