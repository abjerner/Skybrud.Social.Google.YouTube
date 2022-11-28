using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models {

    /// <summary>
    /// Encapsulates paging information for the result set.
    /// </summary>
    public class YouTubePageInfo : GoogleObject {

        #region Properties

        /// <summary>
        /// Gets the total number of results in the result set.
        /// </summary>
        public int TotalResults { get; }

        /// <summary>
        /// Gets the number of results included in the API response.
        /// </summary>
        public int ResultsPerPage { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected YouTubePageInfo(JObject json) : base(json) {
            TotalResults = json.GetInt32("totalResults");
            ResultsPerPage = json.GetInt32("resultsPerPage");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubePageInfo"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubePageInfo"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static YouTubePageInfo? Parse(JObject? json) {
            return json == null ? null : new YouTubePageInfo(json);
        }

        #endregion

    }

}