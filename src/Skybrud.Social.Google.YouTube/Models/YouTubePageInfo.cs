using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models {

    public class YouTubePageInfo : GoogleApiObject {

        #region Properties

        public int TotalResults { get; }

        public int ResultsPerPage { get; }

        #endregion

        #region Constructors

        protected YouTubePageInfo(JObject obj) : base(obj) {
            TotalResults = obj.GetInt32("totalResults");
            ResultsPerPage = obj.GetInt32("resultsPerPage");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubePageInfo"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubePageInfo"/>.</returns>
        public static YouTubePageInfo Parse(JObject obj) {
            return obj == null ? null : new YouTubePageInfo(obj);
        }

        #endregion

    }

}