using System.Collections.Generic;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Google.YouTube.Options.PlaylistItems {

    /// <summary>
    /// Clas representing the options for getting a list of playlist items from the YouTube API.
    /// </summary>
    public class YouTubeGetPlaylistItemListOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets which properties that should be returned.
        /// </summary>
        public YouTubePlaylistItemPartList Part { get; set; } = YouTubePlaylistItemParts.Snippet;

        /// <summary>
        /// Gets or sets a list of IDs for the playlist items to be returned.
        /// </summary>
        public List<string>? Ids { get; set; } = new();

        /// <summary>
        /// Gets or sets the maximum amount of playlist items to be returned on each page (maximum is <c>50</c>).
        /// </summary>
        public int? MaxResults { get; set; }

        /// <summary>
        /// Gets or sets the page token.
        /// </summary>
        public string? PageToken { get; set; }

        /// <summary>
        /// Gets or sets a playlist ID if only playlist items for a specific playlist should be returned.
        /// </summary>
        public string? PlaylistId { get; set; }

        /// <summary>
        /// Gets or sets a video ID if only playlist items for the specific video should be returned.
        /// </summary>
        public string? VideoId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public YouTubeGetPlaylistItemListOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="playlistId"/>.
        /// </summary>
        /// <param name="playlistId">The ID of the parent playlist.</param>
        public YouTubeGetPlaylistItemListOptions(string playlistId) {
            PlaylistId = playlistId;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            // Initialize the query string
            HttpQueryString query = new() { { "part", Part.ToString() } };

            // Add optional parameters
            if (Ids is { Count: > 0 }) query.Add("id", string.Join(",", Ids));
            if (MaxResults > 0) query.Add("maxResults", MaxResults);
            if (!string.IsNullOrWhiteSpace(PageToken)) query.Add("pageToken", PageToken);
            if (!string.IsNullOrWhiteSpace(PlaylistId)) query.Add("playlistId", PlaylistId);
            if (!string.IsNullOrWhiteSpace(VideoId)) query.Add("videoId", VideoId);

            // Initialize a new request
            return HttpRequest.Get("https://www.googleapis.com/youtube/v3/playlistItems", query);

        }

        #endregion

    }

}