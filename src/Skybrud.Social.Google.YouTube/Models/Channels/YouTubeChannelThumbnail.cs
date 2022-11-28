using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models.Channels {

    /// <summary>
    /// Class representing a thumbnail image of a YouTube channel.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/channels#snippet.thumbnails</cref>
    /// </see>
    public class YouTubeChannelThumbnail : GoogleObject {

        #region Properties

        /// <summary>
        /// Gets the URL of the thumbnail image.
        /// </summary>
        public string Url { get; }

        // The YouTube API reference specifies "width" and "height" properties as well, but I haven't yet found
        // examples where they are actually specified, so I'll skip implementing them for now

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected YouTubeChannelThumbnail(JObject json) : base(json) {
            Url = json.GetString("url")!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubeChannelThumbnail"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubeChannelThumbnail"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static YouTubeChannelThumbnail? Parse(JObject? json) {
            return json == null ? null : new YouTubeChannelThumbnail(json);
        }

        #endregion

    }

}