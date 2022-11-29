using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

#pragma warning disable CS1591

namespace Skybrud.Social.Google.YouTube.Models.Errors {

    public class YouTubeError {

        #region Properties

        public int Code { get; }

        public string Message { get; }

        public IReadOnlyList<YouTubeErrorItem> Errors { get; }

        public string? Status { get; }

        #endregion

        #region Constructors

        protected YouTubeError(JObject json) {
            Code = json.GetInt32("code");
            Message = json.GetString("message")!;
            Errors = json.GetArrayItems("errors", YouTubeErrorItem.Parse)!;
            Status = json.GetString("status");
        }

        #endregion

        #region Static methods

        [return: NotNullIfNotNull("json")]
        public static YouTubeError? Parse(JObject? json) {
            return json == null ? null : new YouTubeError(json);
        }

        #endregion

    }

}