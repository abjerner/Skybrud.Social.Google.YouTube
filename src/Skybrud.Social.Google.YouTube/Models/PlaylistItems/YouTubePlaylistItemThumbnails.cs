using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models.PlaylistItems {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlistItems#snippet.thumbnails</cref>
    /// </see>
    public class YouTubePlaylistItemThumbnails : GoogleObject {

        #region Properties

        /// <summary>
        /// Gets the default thumbnail image. The default thumbnail for a video – or a resource that refers to a video, such as a playlist item or search result – is 120px wide and 90px tall. The default thumbnail for a channel is 88px wide and 88px tall.
        /// </summary>
        public YouTubePlaylistItemThumbnail Default { get; }

        /// <summary>
        /// Gets a higher resolution version of the thumbnail image. For a video (or a resource that refers to a video), this image is 320px wide and 180px tall. For a channel, this image is 240px wide and 240px tall.
        /// </summary>
        public YouTubePlaylistItemThumbnail Medium { get; }

        /// <summary>
        /// Gets a high resolution version of the thumbnail image. For a video (or a resource that refers to a video), this image is 480px wide and 360px tall. For a channel, this image is 800px wide and 800px tall.
        /// </summary>
        public YouTubePlaylistItemThumbnail High { get; }

        /// <summary>
        /// Gets an even higher resolution version of the thumbnail image than the <see cref="High"/> resolution image. This image is available for some videos and other resources that refer to videos, like playlist items or search results. This image is 640px wide and 480px tall.
        /// </summary>
        public YouTubePlaylistItemThumbnail Standard { get; }

        /// <summary>
        /// Gets the highest resolution version of the thumbnail image. This image size is available for some videos and other resources that refer to videos, like playlist items or search results. This image is 1280px wide and 720px tall.
        /// </summary>
        public YouTubePlaylistItemThumbnail MaxRes { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected YouTubePlaylistItemThumbnails(JObject json) : base(json) {
            Default = json.GetObject("default", YouTubePlaylistItemThumbnail.Parse);
            Medium = json.GetObject("medium", YouTubePlaylistItemThumbnail.Parse);
            High = json.GetObject("high", YouTubePlaylistItemThumbnail.Parse);
            Standard = json.GetObject("standard", YouTubePlaylistItemThumbnail.Parse);
            MaxRes = json.GetObject("maxres", YouTubePlaylistItemThumbnail.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubePlaylistItemThumbnails"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubePlaylistItemThumbnails"/>.</returns>
        public static YouTubePlaylistItemThumbnails Parse(JObject json) {
            return json == null ? null : new YouTubePlaylistItemThumbnails(json);
        }

        #endregion

    }

}