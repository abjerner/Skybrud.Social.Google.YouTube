namespace Skybrud.Social.Google.YouTube.Options.PlaylistItems {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlistItems/list#part</cref>
    /// </see>
    public class YouTubePlaylistItemParts {

        #region Properties
        
        /// <summary>
        /// Indicates that the response from the YouTube API should include the ID of the playlist items.
        /// </summary>
        public static readonly YouTubePlaylistItemPart Id = new YouTubePlaylistItemPart("id");
        
        /// <summary>
        /// Indicates that the response from the YouTube API should include the <c>snippet</c> object of the playlist items.
        /// </summary>
        public static readonly YouTubePlaylistItemPart Snippet = new YouTubePlaylistItemPart("snippet");
        
        /// <summary>
        /// Indicates that the response from the YouTube API should include the <c>contentDetails</c> object of the playlist items.
        /// </summary>
        public static readonly YouTubePlaylistItemPart ContentDetails = new YouTubePlaylistItemPart("contentDetails");
        
        /// <summary>
        /// Indicates that the response from the YouTube API should include the <c>status</c> object of the playlist items.
        /// </summary>
        public static readonly YouTubePlaylistItemPart Status = new YouTubePlaylistItemPart("status");
        
        /// <summary>
        /// Gets a collection of all parts available for a YouTube channel.
        /// </summary>
        public static readonly YouTubePlaylistItemPartList All = new YouTubePlaylistItemPartList(
            Id, Snippet, ContentDetails, Status
        );

        /// <summary>
        /// Gets an array of <see cref="YouTubePlaylistItemPart"/> representing all parts available for a YouTube playlist item.
        /// </summary>
        public static YouTubePlaylistItemPart[] Values {
            get { return All.ToArray(); }
        }

        #endregion
    
    }

}