using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models.Playlists {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlists#resource</cref>
    /// </see>
    public class YouTubePlaylist : GoogleResource {

        #region Properties

        /// <summary>
        /// Gets the ID that YouTube uses to uniquely identify the playlist.
        /// </summary>
        public string Id { get; }
        
        /// <summary>
        /// Gets basic details about the playlist, such as its title and description.
        /// </summary>
        public YouTubePlaylistSnippet Snippet { get; }

        /// <summary>
        /// Gets status information for the playlist.
        /// </summary>
        public YouTubePlaylistStatus Status { get; }

        /// <summary>
        /// Gets information about the playlist content, including the number of videos in the playlist.
        /// </summary>
        public YouTubePlaylistContentDetails ContentDetails { get; }
        
        #endregion
        
        #region Constructors

        private YouTubePlaylist(JObject obj) : base(obj) {
            Id = obj.GetString("id");
            Snippet = obj.GetObject("snippet", YouTubePlaylistSnippet.Parse);
            Status = obj.GetObject("status", YouTubePlaylistStatus.Parse);
            ContentDetails = obj.GetObject("contentDetails", YouTubePlaylistContentDetails.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubePlaylist"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubePlaylist"/>.</returns>
        public static YouTubePlaylist Parse(JObject obj) {
            return obj == null ? null : new YouTubePlaylist(obj);
        }

        #endregion

    }

}