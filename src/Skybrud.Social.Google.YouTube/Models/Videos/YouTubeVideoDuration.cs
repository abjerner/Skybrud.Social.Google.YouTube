using System;
using System.Xml;

namespace Skybrud.Social.Google.YouTube.Models.Videos {

    /// <summary>
    /// Class representing the duration of a YouTube video.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/videos#contentDetails.duration</cref>
    /// </see>
    public class YouTubeVideoDuration {

        #region Properties

        /// <summary>
        /// Gets the raw string with the ISO 8601 duration.
        /// </summary>
        public string Raw { get; }

        /// <summary>
        /// Gets the days component of the video's duration.
        /// </summary>
        public int Days => Value.Days;

        /// <summary>
        /// Gets the hours component of the video's duration.
        /// </summary>
        public int Hours => Value.Hours;

        /// <summary>
        /// Gets the minutes component of the video's duration.
        /// </summary>
        public int Minutes => Value.Minutes;

        /// <summary>
        /// Gets the seconds component of the video's duration.
        /// </summary>
        public int Seconds => Value.Seconds;

        /// <summary>
        /// Gets an instance of <see cref="TimeSpan"/> representing the total duration of the video.
        /// </summary>
        public TimeSpan Value { get; }

        #endregion

        #region Constructors

        private YouTubeVideoDuration(string raw, TimeSpan duration) {
            Raw = raw;
            Value = duration;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubeVideoDuration"/> parsed from the specified <paramref name="value"/>.
        /// </summary>
        /// <param name="value">A string representing the duration.</param>
        /// <returns>An instance of <see cref="YouTubeVideoDuration"/>.</returns>
        public static YouTubeVideoDuration Parse(string value) {
            return new YouTubeVideoDuration(value, XmlConvert.ToTimeSpan(value));
        }

        #endregion

    }

}