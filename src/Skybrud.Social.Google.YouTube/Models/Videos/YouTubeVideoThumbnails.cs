using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models.Videos {

    /// <summary>
    /// Class representing a collection of thumbnails for a YouTube video.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/videos#snippet.thumbnails</cref>
    /// </see>
    public class YouTubeVideoThumbnails : GoogleObject {

        #region Properties

        /// <summary>
        /// Gets the default thumbnail image of the video. The thumbnail is 120px wide and 90px tall.
        /// </summary>
        public YouTubeVideoThumbnail Default { get; }

        /// <summary>
        /// Gets whether the <see cref="Default"/> property has a value.
        /// </summary>
        public bool HasDefault => Default != null;

        /// <summary>
        /// Gets a higher resolution version of the thumbnail image, which is 320px wide and 180px tall.
        /// </summary>
        public YouTubeVideoThumbnail Medium { get; }

        /// <summary>
        /// Gets whether the <see cref="Medium"/> property has a value.
        /// </summary>
        public bool HasMedium => Medium != null;

        /// <summary>
        /// Gets a high resolution version of the thumbnail image, which is 480px wide and 360px tall.
        /// </summary>
        public YouTubeVideoThumbnail High { get; }

        /// <summary>
        /// Gets whether the <see cref="High"/> property has a value.
        /// </summary>
        public bool HasHigh => High != null;

        /// <summary>
        /// Gets an even higher resolution version of the thumbnail image than the high resolution image. This image is
        /// available for some videos. This image is 640px wide and 480px tall.
        /// </summary>
        public YouTubeVideoThumbnail Standard { get; }

        /// <summary>
        /// Gets whether the <see cref="Standard"/> property has a value.
        /// </summary>
        public bool HasStandard => Standard != null;

        /// <summary>
        /// Gets the highest resolution version of the thumbnail image. This image size is available for some videos.
        /// This image is 1280px wide and 720px tall.
        /// </summary>
        public YouTubeVideoThumbnail MaxRes { get; }

        /// <summary>
        /// Gets whether the <see cref="MaxRes"/> property has a value.
        /// </summary>
        public bool HasMaxRes => MaxRes != null;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected YouTubeVideoThumbnails(JObject json) : base(json) {
            Default = json.GetObject("default", YouTubeVideoThumbnail.Parse);
            Medium = json.GetObject("medium", YouTubeVideoThumbnail.Parse);
            High = json.GetObject("high", YouTubeVideoThumbnail.Parse);
            Standard = json.GetObject("standard", YouTubeVideoThumbnail.Parse);
            MaxRes = json.GetObject("maxres", YouTubeVideoThumbnail.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubeVideoThumbnails"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubeVideoThumbnails"/>.</returns>
        public static YouTubeVideoThumbnails Parse(JObject json) {
            return json == null ? null : new YouTubeVideoThumbnails(json);
        }

        #endregion

    }

}