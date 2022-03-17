using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models.Channels {

    /// <summary>
    /// Class representing the <c>snippet</c> object of a YouTube channel.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/channels#snippet</cref>
    /// </see>
    public class YouTubeChannelSnippet : GoogleObject {

        #region Properties

        /// <summary>
        /// Gets the title of the channel.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Gets the description of the channel.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets the timestamp for when the channel was published.
        /// </summary>
        public EssentialsTime PublishedAt { get; }

        /// <summary>
        /// Gets a collection of thumbnails of the channel.
        /// </summary>
        public YouTubeChannelThumbnails Thumbnails { get; }

        /// <summary>
        /// Gets a reference to an object containing a localized title and description for the channel or the channel's
        /// title and description in the default language.
        /// </summary>
        public YouTubeChannelLocalized Localized { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected  YouTubeChannelSnippet(JObject json) : base(json) {
            Title = json.GetString("title");
            Description = json.GetString("description");
            PublishedAt = json.GetString("publishedAt", EssentialsTime.Parse);
            Thumbnails = json.GetObject("thumbnails", YouTubeChannelThumbnails.Parse);
            Localized = json.GetObject("localized", YouTubeChannelLocalized.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubeChannelSnippet"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubeChannelSnippet"/>.</returns>
        public static YouTubeChannelSnippet Parse(JObject json) {
            return json == null ? null : new YouTubeChannelSnippet(json);
        }

        #endregion

    }

}