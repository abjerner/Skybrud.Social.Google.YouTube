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
        public YouTubeChannelPartList Part { get; set; }

        /// <summary>
        /// Gets or sets whether only channel(s) with this username should be returned.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets a list of IDs for the channels to be returned.
        /// </summary>
        public string[] Ids { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of channels to be returned on each page (maximum is <c>50</c>).
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// Gets or sets whether only channels by the authenticated user should be returned.
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
        public YouTubeGetChannelListOptions() {
            Part = YouTubeChannelParts.Snippet;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            HttpQueryString query = new HttpQueryString();
            if (Part != null) query.Add("part", Part.ToString());
            if (!string.IsNullOrWhiteSpace(Username)) query.Add("forUsername", Username);
            if (Ids != null && Ids.Length > 0) query.Add("id", string.Join(",", Ids));
            if (MaxResults > 0) query.Add("maxResults", MaxResults);
            if (Mine) query.Add("mine", "true");
            if (!string.IsNullOrWhiteSpace(PageToken)) query.Add("pageToken", PageToken);

            return HttpRequest.Get("https://www.googleapis.com/youtube/v3/channels", query);

        }

        #endregion

    }

}