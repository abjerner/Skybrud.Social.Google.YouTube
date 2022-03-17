using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models.PlaylistItems {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlistItems#snippet.resourceId</cref>
    /// </see>
    public class YouTubePlaylistItemResourceId : GoogleObject {

        #region Properties
        
        /// <summary>
        /// Gets the kind, or type, of the referred resource.
        /// </summary>
        public string Kind { get; }
        
        /// <summary>
        /// If the <c>snippet.resourceId.kind</c> property's value is <c>youtube#video</c>, then this property will be
        /// present and its value will contain the ID that YouTube uses to uniquely identify the video in the playlist.
        /// </summary>
        public string VideoId { get; }

        #endregion
        
        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected YouTubePlaylistItemResourceId(JObject json) : base(json) {
            Kind = json.GetString("kind");
            VideoId = json.GetString("videoId");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubePlaylistItemResourceId"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubePlaylistItemResourceId"/>.</returns>
        public static YouTubePlaylistItemResourceId Parse(JObject json) {
            return json == null ? null : new YouTubePlaylistItemResourceId(json);
        }

        #endregion

    }

}