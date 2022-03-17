using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Google.Models;
using Skybrud.Social.Google.YouTube.Options.Videos;

namespace Skybrud.Social.Google.YouTube.Models.Videos {

    /// <summary>
    /// Class representing a list of <see cref="YouTubeVideo"/> items.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/videos/list</cref>
    /// </see>
    public class YouTubeVideoList : GoogleResource {

        #region Properties

        /// <summary>
        /// Gets the token that can be used as the value of the <see cref="YouTubeGetVideoListOptions.PageToken"/>
        /// parameter to retrieve the next page in the result set.
        /// </summary>
        public string NextPageToken { get; }

        /// <summary>
        /// Gets the token that can be used as the value of the <see cref="YouTubeGetVideoListOptions.PageToken"/>
        /// parameter to retrieve the previous page in the result set.
        /// </summary>
        public string PrevPageToken { get; }

        /// <summary>
        /// Gets a reference to an object that encapsulates paging information for the result set.
        /// </summary>
        public YouTubePageInfo PageInfo { get; }

        /// <summary>
        /// Gets an array of the videos returned in the response.
        /// </summary>
        public YouTubeVideo[] Items { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected YouTubeVideoList(JObject json) : base(json) {
            NextPageToken = json.GetString("nextPageToken");
            PrevPageToken = json.GetString("prevPageToken");
            PageInfo = json.GetObject("pageInfo", YouTubePageInfo.Parse);
            Items = json.GetArray("items", YouTubeVideo.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubeVideoList"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubeVideoList"/>.</returns>
        public static YouTubeVideoList Parse(JObject json) {
            return json == null ? null : new YouTubeVideoList(json);
        }

        #endregion

    }

}