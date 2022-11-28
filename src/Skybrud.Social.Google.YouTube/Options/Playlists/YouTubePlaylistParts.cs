using System.Collections.Generic;

namespace Skybrud.Social.Google.YouTube.Options.Playlists {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlists/list#part</cref>
    /// </see>
    public class YouTubePlaylistParts {

        #region Properties

        /// <summary>
        /// Indicates that the response from the YouTube API should include the ID of the playlist.
        /// </summary>
        public static readonly YouTubePlaylistPart Id = new("id");

        /// <summary>
        /// Indicates that the response from the YouTube API should include the <c>snippet</c> object of the playlist.
        /// </summary>
        public static readonly YouTubePlaylistPart Snippet = new("snippet");

        /// <summary>
        /// Indicates that the response from the YouTube API should include the <c>snippet</c> object of the playlist.
        /// </summary>
        public static readonly YouTubePlaylistPart Status = new("status");

        /// <summary>
        /// Indicates that the response from the YouTube API should include the <c>snippet</c> object of the playlist.
        /// </summary>
        public static readonly YouTubePlaylistPart ContentDetails = new("contentDetails");

        /// <summary>
        /// Gets a collection of all parts available for a YouTube channel.
        /// </summary>
        public static readonly YouTubePlaylistPartList All = new(
            Id, Snippet, Status, ContentDetails
        );

        /// <summary>
        /// Gets an array of <see cref="YouTubePlaylistPart"/> representing all parts available for a YouTube playlist.
        /// </summary>
        public static IReadOnlyList<YouTubePlaylistPart> Values => All.ToArray();

        #endregion

    }

}