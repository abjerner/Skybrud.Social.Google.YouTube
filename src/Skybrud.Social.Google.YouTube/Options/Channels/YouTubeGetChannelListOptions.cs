using System.Collections.Generic;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Google.YouTube.Options.Channels {

    /// <summary>
    /// Clas representing the options for getting a list of channels from the YouTube API.
    /// </summary>
    public class YouTubeGetChannelListOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets which properties that should be returned.
        /// </summary>
        public YouTubeChannelPartList Part { get; set; } = YouTubeChannelParts.Snippet;

        /// <summary>
        /// Gets or sets whether only channel(s) with this username should be returned.
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// Gets or sets a list of IDs for the channels to be returned.
        /// </summary>
        public List<string>? Ids { get; set; } = new();

        /// <summary>
        /// Gets or sets the maximum amount of channels to be returned on each page (maximum is <c>50</c>).
        /// </summary>
        public int? MaxResults { get; set; }

        /// <summary>
        /// Gets or sets whether only channels by the authenticated user should be returned.
        /// </summary>
        public bool? Mine { get; set; }

        /// <summary>
        /// Gets or sets the page token.
        /// </summary>
        public string? PageToken { get; set; }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            // Initialize the query string
            HttpQueryString query = new() { { "part", Part.ToString() } };

            // Add optional parameters
            if (!string.IsNullOrWhiteSpace(Username)) query.Add("forUsername", Username);
            if (Ids is { Count: > 0 }) query.Add("id", string.Join(",", Ids));
            if (MaxResults > 0) query.Add("maxResults", MaxResults);
            if (Mine is true) query.Add("mine", "true");
            if (!string.IsNullOrWhiteSpace(PageToken)) query.Add("pageToken", PageToken);

            // Initialize a new request
            return HttpRequest.Get("https://www.googleapis.com/youtube/v3/channels", query);

        }

        #endregion

    }

}