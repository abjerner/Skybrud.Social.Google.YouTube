using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models.Channels {

    /// <summary>
    /// Class representing a YouTube channel.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/channels#resource</cref>
    /// </see>
    public class YouTubeChannel : GoogleResource {

        #region Properties

        /// <summary>
        /// Gets the ID of the channel.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets a reference to the <c>snippet</c> object of the channel, which contains details such as the
        /// title, description and thumbnail images of the channel.
        /// </summary>
        public YouTubeChannelSnippet Snippet { get; }

        /// <summary>
        /// Gets a reference to the <c>statistics</c> object of the channel. 
        /// </summary>
        public YouTubeChannelStatistics Statistics { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected YouTubeChannel(JObject json) : base(json) {
            Id = json.GetString("id");
            Snippet = json.GetObject("snippet", YouTubeChannelSnippet.Parse);
            Statistics = json.GetObject("statistics", YouTubeChannelStatistics.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubeChannel"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubeChannel"/>.</returns>
        public static YouTubeChannel Parse(JObject json) {
            return json == null ? null : new YouTubeChannel(json);
        }

        #endregion

    }

}