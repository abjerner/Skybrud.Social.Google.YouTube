using System;
using System.Collections.Generic;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Google.YouTube.Options.Videos {

    /// <summary>
    /// Class representing the options for getting a list of videos from the YouTube API.
    /// </summary>
    public class YouTubeGetVideoListOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets which properties that should be returned.
        /// </summary>
        public YouTubeVideoPartList Part { get; set; } = YouTubeVideoParts.Snippet;

        /// <summary>
        /// Gets or sets a list of IDs for the videos to be returned.
        /// </summary>
        public List<string>? Ids { get; set; } = new();

        /// <summary>
        /// Gets or sets the maximum amount of videos to be returned on each page (maximum is <c>50</c>).
        /// </summary>
        public int? MaxResults { get; set; }

        /// <summary>
        /// Gets or sets the page token.
        /// </summary>
        public string? PageToken { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public YouTubeGetVideoListOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="videoId"/>.
        /// </summary>
        public YouTubeGetVideoListOptions(string videoId) {
            if (string.IsNullOrWhiteSpace(videoId)) throw new ArgumentNullException(nameof(videoId));
            Ids = new List<string> { videoId };
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="videoIds"/>.
        /// </summary>
        public YouTubeGetVideoListOptions(params string[] videoIds) {
            if (videoIds is null) throw new ArgumentNullException(nameof(videoIds));
            Ids = new List<string>(videoIds);
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

            // Initialize a new request
            return HttpRequest.Get("https://www.googleapis.com/youtube/v3/videos", query);

        }

        #endregion

    }

}