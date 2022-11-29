using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

#pragma warning disable CS1591

namespace Skybrud.Social.Google.YouTube.Models.Errors {

    public class YouTubeErrorResult {

        #region Properties

        public YouTubeError Error { get; }

        #endregion

        #region Constructors

        protected YouTubeErrorResult(JObject json) {
            Error = json.GetObject("error", YouTubeError.Parse)!;
        }

        #endregion

        #region Static methods

        [return: NotNullIfNotNull("json")]
        public static YouTubeErrorResult? Parse(JObject? json) {
            return json == null ? null : new YouTubeErrorResult(json);
        }

        #endregion

    }

}