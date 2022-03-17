using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Google.YouTube.Options.Playlists {

    /// <summary>
    /// Clas representing the options for getting a list of playlists from the YouTube API.
    /// </summary>
    public class YouTubeGetPlaylistListOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets which properties that should be returned.
        /// </summary>
        public YouTubePlaylistPartList Part { get; set; }

        /// <summary>
        /// Gets or sets a channel ID if only playlists for a specific channel should be returned.
        /// </summary>
        public string ChannelId { get; set; }

        /// <summary>
        /// Gets or sets a list of IDs for the playlists to be returned.
        /// </summary>
        public string[] Ids { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of playlists to be returned on each page (maximum is <c>50</c>).
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// Gets or sets whether only playlists by the authenticated user should be returned.
        /// </summary>
        public bool Mine { get; set; }

        /// <summary>
        /// Gets or sets the page token.
        /// </summary>
        public string PageToken { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public YouTubeGetPlaylistListOptions() {
            Part = YouTubePlaylistParts.Snippet;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="channelId"/>.
        /// </summary>
        /// <param name="channelId">The ID of the parent channel.</param>
        public YouTubeGetPlaylistListOptions(string channelId) {
            Part = YouTubePlaylistParts.Snippet;
            ChannelId = channelId;
        }

        /// <summary>
        /// Initializes a new instance to return playlists of the authenticated user.
        /// </summary>
        /// <param name="mine"></param>
        public YouTubeGetPlaylistListOptions(bool mine) {
            Part = YouTubePlaylistParts.Snippet;
            Mine = mine;
        }

        #endregion

        #region Member methods
        
        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            HttpQueryString query = new HttpQueryString();
            if (Part != null) query.Add("part", Part.ToString());
            if (!string.IsNullOrWhiteSpace(ChannelId)) query.Add("channelId", ChannelId);
            if (Ids != null && Ids.Length > 0) query.Add("id", string.Join(",", Ids));
            if (MaxResults > 0) query.Add("maxResults", MaxResults);
            if (Mine) query.Add("mine", "true");
            if (!string.IsNullOrWhiteSpace(PageToken)) query.Add("pageToken", PageToken);

            return HttpRequest.Get("https://www.googleapis.com/youtube/v3/playlists", query);

        }

        #endregion

    }

}