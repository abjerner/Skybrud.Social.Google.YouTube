using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models.PlaylistItems {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlistItems#snippet.thumbnails</cref>
    /// </see>
    public class YouTubePlaylistItemThumbnails : GoogleApiObject {

        #region Properties

        public YouTubePlaylistItemThumbnail Default { get; }

        public YouTubePlaylistItemThumbnail Medium { get; }

        public YouTubePlaylistItemThumbnail High { get; }

        public YouTubePlaylistItemThumbnail Standard { get; }

        public YouTubePlaylistItemThumbnail MaxRes { get; }

        #endregion

        #region Constructors

        protected YouTubePlaylistItemThumbnails(JObject obj) : base(obj) {
            Default = obj.GetObject("default", YouTubePlaylistItemThumbnail.Parse);
            Medium = obj.GetObject("medium", YouTubePlaylistItemThumbnail.Parse);
            High = obj.GetObject("high", YouTubePlaylistItemThumbnail.Parse);
            Standard = obj.GetObject("standard", YouTubePlaylistItemThumbnail.Parse);
            MaxRes = obj.GetObject("maxres", YouTubePlaylistItemThumbnail.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubePlaylistItemThumbnails"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubePlaylistItemThumbnails"/>.</returns>
        public static YouTubePlaylistItemThumbnails Parse(JObject obj) {
            return obj == null ? null : new YouTubePlaylistItemThumbnails(obj);
        }

        #endregion

    }

}