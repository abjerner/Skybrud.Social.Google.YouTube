namespace Skybrud.Social.Google.YouTube.Options.Playlists {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlists/list#part</cref>
    /// </see>
    public class YouTubePlaylistParts {

        #region Properties

        /// <summary>
        /// Indicates that the response from the YouTube API should include the ID of the playlist.
        /// </summary>
        public static readonly YouTubePlaylistPart Id = new YouTubePlaylistPart("id");

        /// <summary>
        /// Indicates that the response from the YouTube API should include the <c>snippet</c> object of the playlist.
        /// </summary>
        public static readonly YouTubePlaylistPart Snippet = new YouTubePlaylistPart("snippet");

        /// <summary>
        /// Indicates that the response from the YouTube API should include the <c>snippet</c> object of the playlist.
        /// </summary>
        public static readonly YouTubePlaylistPart Status = new YouTubePlaylistPart("status");

        /// <summary>
        /// Indicates that the response from the YouTube API should include the <c>snippet</c> object of the playlist.
        /// </summary>
        public static readonly YouTubePlaylistPart ContentDetails = new YouTubePlaylistPart("contentDetails");

        /// <summary>
        /// Gets a collection of all parts available for a YouTube channel.
        /// </summary>
        public static readonly YouTubePlaylistPartsCollection All = new YouTubePlaylistPartsCollection(
            Id, Snippet, Status, ContentDetails
        );

        /// <summary>
        /// Gets an array of <see cref="YouTubePlaylistPart"/> representing all parts available for a YouTube playlist.
        /// </summary>
        public static YouTubePlaylistPart[] Values => All.ToArray();

        #endregion
    
    }

}