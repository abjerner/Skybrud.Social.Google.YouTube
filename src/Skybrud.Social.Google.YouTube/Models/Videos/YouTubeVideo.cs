using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models.Videos {

    /// <summary>
    /// Class representing a YouTube video:
    /// </summary>
    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/videos#resource</cref>
    /// </see>
    public class YouTubeVideo : GoogleResource {

        #region Properties

        /// <summary>
        /// Gets the ID of the video.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets a reference to the <strong>snippet</strong> part of the video.
        /// </summary>
        public YouTubeVideoSnippet? Snippet { get; }

        /// <summary>
        /// Gets whether the <see cref="Snippet"/> property was included in the response.
        /// </summary>
        [MemberNotNullWhen(true, nameof(Snippet))]
        public bool HasSnippet => Snippet != null;

        /// <summary>
        /// Gets a reference to the <strong>contentDetails</strong> part of the video.
        /// </summary>
        public YouTubeVideoContentDetails? ContentDetails { get; }

        /// <summary>
        /// Gets whether the <see cref="ContentDetails"/> property was included in the response.
        /// </summary>
        [MemberNotNullWhen(true, nameof(ContentDetails))]
        public bool HasContentDetails => ContentDetails != null;

        /// <summary>
        /// Gets a reference to the <strong>status</strong> part of the video.
        /// </summary>
        public YouTubeVideoStatus? Status { get; }

        /// <summary>
        /// Gets whether the <see cref="Status"/> property was included in the response.
        /// </summary>
        [MemberNotNullWhen(true, nameof(Status))]
        public bool HasStatus => Status != null;

        /// <summary>
        /// Gets a reference to the <strong>statistics</strong> part of the video.
        /// </summary>
        public YouTubeVideoStatistics? Statistics { get; }

        /// <summary>
        /// Gets whether the <see cref="Statistics"/> property was included in the response.
        /// </summary>
        [MemberNotNullWhen(true, nameof(Statistics))]
        public bool HasStatistics => Statistics != null;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected YouTubeVideo(JObject json) : base(json) {
            Id = json.GetString("id")!;
            Snippet = json.GetObject("snippet", YouTubeVideoSnippet.Parse);
            ContentDetails = json.GetObject("contentDetails", YouTubeVideoContentDetails.Parse);
            Status = json.GetObject("status", YouTubeVideoStatus.Parse);
            Statistics = json.GetObject("statistics", YouTubeVideoStatistics.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubeVideo"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubeVideo"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static YouTubeVideo? Parse(JObject? json) {
            return json == null ? null : new YouTubeVideo(json);
        }

        #endregion

    }

}