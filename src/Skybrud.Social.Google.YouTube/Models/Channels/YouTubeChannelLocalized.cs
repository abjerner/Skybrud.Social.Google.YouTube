using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models.Channels {

    /// <summary>
    /// Class representing the <c>snippet.localized</c> property of a YouTubeChannel, which contains a localized
    /// title and description for the channel or it contains the channel's title and description in the default
    /// language for the channel's metadata.
    /// </summary>
    public class YouTubeChannelLocalized : GoogleObject {

        #region Properties

        /// <summary>
        /// Gets the localized title.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Gets the localized description.
        /// </summary>
        public string Description { get; }

        #endregion

        #region Constructors

        private YouTubeChannelLocalized(JObject obj) : base(obj) {
            Title = obj.GetString("title");
            Description = obj.GetString("description");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubeChannelLocalized"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubeChannelLocalized"/>.</returns>
        public static YouTubeChannelLocalized Parse(JObject obj) {
            return obj == null ? null : new YouTubeChannelLocalized(obj);
        }

        #endregion

    }

}