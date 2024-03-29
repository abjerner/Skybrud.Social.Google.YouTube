using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models.Videos {

    /// <summary>
    /// Class representing the <c>contentDetails</c> part of a YouTube video.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/videos#contentDetails</cref>
    /// </see>
    public class YouTubeVideoContentDetails : GoogleObject {

        #region Properties

        /// <summary>
        /// Gets the length of the video.
        /// </summary>
        public YouTubeVideoDuration Duration { get; }

        /// <summary>
        /// Gets the dimension of the video. Can either be in <c>3D</c> or in <c>2D</c>.
        /// </summary>
        public YouTubeVideoDimension Dimension { get; }

        /// <summary>
        /// Gets whether the video is available in high definition (HD) or only standard definition (SD). Can be either <c>hd</c> or <c>sd</c>.
        /// </summary>
        public YouTubeVideoDefinition Definition { get; }

        /// <summary>
        /// Gets whether the video has captions. Can be either <c>true</c> or <c>false</c>.
        /// </summary>
        public bool HasCaption { get; }

        /// <summary>
        /// Gets whether the video represents licensed content, which means that the content has been claimed by a
        /// YouTube content partner.
        /// </summary>
        public bool IsLicensedContent { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected YouTubeVideoContentDetails(JObject json) : base(json) {
            Duration = json.GetString("duration", YouTubeVideoDuration.Parse)!;
            Dimension = json.GetString("dimension", ParseDimension);
            Definition = json.GetString("definition", ParseDefinition);
            HasCaption = json.GetBoolean("caption");
            IsLicensedContent = json.GetBoolean("licensedContent");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubeVideoContentDetails"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubeVideoContentDetails"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static YouTubeVideoContentDetails? Parse(JObject? json) {
            return json == null ? null : new YouTubeVideoContentDetails(json);
        }

        private static YouTubeVideoDimension ParseDimension(string value) {
            switch (value) {
                case "2d":
                    return YouTubeVideoDimension.TwoDimensional;
                case "3d":
                    return YouTubeVideoDimension.ThreeDimensional;
                default:
                    throw new Exception($"Unknown video dimension '{value}' - please create an issue so it can be fixed {YouTubeConstants.NewIssueUrl}");
            }
        }

        private static YouTubeVideoDefinition ParseDefinition(string value) {
            switch (value) {
                case "hd":
                    return YouTubeVideoDefinition.HighDefinition;
                case "sd":
                    return YouTubeVideoDefinition.StandardDefinition;
                default:
                    throw new Exception($"Unknown video definition '{value}' - please create an issue so it can be fixed {YouTubeConstants.NewIssueUrl}");
            }
        }

        #endregion

    }

}