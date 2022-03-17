using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models.PlaylistItems {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlistItems#snippet.resourceId</cref>
    /// </see>
    public class YouTubePlaylistItemResourceId : GoogleObject {

        #region Properties
        
        public string Kind { get; }
        
        public string VideoId { get; }

        #endregion
        
        #region Constructors

        private YouTubePlaylistItemResourceId(JObject obj) : base(obj) {
            Kind = obj.GetString("kind");
            VideoId = obj.GetString("videoId");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubePlaylistItemResourceId"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubePlaylistItemResourceId"/>.</returns>
        public static YouTubePlaylistItemResourceId Parse(JObject obj) {
            return obj == null ? null : new YouTubePlaylistItemResourceId(obj);
        }

        #endregion

    }

}