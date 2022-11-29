using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

#pragma warning disable CS1591

namespace Skybrud.Social.Google.YouTube.Models.Errors {

    public class YouTubeErrorItem {

        #region Properties

        public string Message { get; }

        public string Domain { get; }

        public string Reason { get; }

        public string? Location { get; }

        public string? LocationType { get; }

        #endregion

        #region Constructors

        protected YouTubeErrorItem(JObject json) {
            Message = json.GetString("message")!;
            Domain = json.GetString("domain")!;
            Reason = json.GetString("reason")!;
            Location = json.GetString("location");
            LocationType = json.GetString("locationType");
        }

        #endregion

        #region Static methods

        [return: NotNullIfNotNull("json")]
        public static YouTubeErrorItem? Parse(JObject? json) {
            return json == null ? null : new YouTubeErrorItem(json);
        }

        #endregion

    }

}