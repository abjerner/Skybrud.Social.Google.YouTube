using System;
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
        public YouTubeVideoPartsCollection Part { get; set; }

        /// <summary>
        /// Gets or sets a list of IDs for the videos to be returned.
        /// </summary>
        public string[] Ids { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of videos to be returned on each page (maximum is <c>50</c>).
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// Gets or sets the page token.
        /// </summary>
        public string PageToken { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public YouTubeGetVideoListOptions() {
            Part = YouTubeVideoParts.Snippet;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="videoId"/>.
        /// </summary>
        public YouTubeGetVideoListOptions(string videoId) {
            if (string.IsNullOrWhiteSpace(videoId)) throw new ArgumentNullException(nameof(videoId));
            Part = YouTubeVideoParts.Snippet;
            Ids = new[] { videoId };
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="videoIds"/>.
        /// </summary>
        public YouTubeGetVideoListOptions(params string[] videoIds) {
            Part = YouTubeVideoParts.Snippet;
            Ids = videoIds ?? throw new ArgumentNullException(nameof(videoIds));
        }

        #endregion

        #region Member methods

        public IHttpRequest GetRequest() {

            HttpQueryString query = new HttpQueryString();
            if (Part != null) query.Add("part", Part.ToString());
            if (Ids != null && Ids.Length > 0) query.Add("id", string.Join(",", Ids));
            if (MaxResults > 0) query.Add("maxResults", MaxResults);
            if (!string.IsNullOrWhiteSpace(PageToken)) query.Add("pageToken", PageToken);

            return HttpRequest.Get("https://www.googleapis.com/youtube/v3/videos", query);

        }

        #endregion

    }

}