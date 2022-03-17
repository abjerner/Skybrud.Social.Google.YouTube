using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Google.Models;

namespace Skybrud.Social.Google.YouTube.Models.Videos {

    /// <summary>
    /// Class representing the <c>status</c> part of a YouTube video.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/videos#status</cref>
    /// </see>
    public class YouTubeVideoStatus : GoogleObject {

        #region Properties

        public YouTubeVideoUploadStatus UploadStatus { get; }

        public YouTubeVideoFailureReason? FailureReason { get; }

        public YouTubeVideoRejectionReason? RejectionReason { get; }

        public YouTubePrivacyStatus PrivacyStatus { get; }

        public YouTubeVideoLicense License { get; }

        public bool IsEmbeddable { get; }

        public bool PublicStatsViewable { get; }

        #endregion

        #region Constructor

        protected YouTubeVideoStatus(JObject obj) : base(obj) {


            // Parse the upload status
            string strUploadStatus = obj.GetString("uploadStatus");
            if (!Enum.TryParse(strUploadStatus, true, out YouTubeVideoUploadStatus uploadStatus)) {
                throw new Exception("Unknown upload status \"" + strUploadStatus + "\" - please create an issue so it can be fixed https://github.com/abjerner/Skybrud.Social.Google/issues/new");
            }

            // Parse the failure reason
            YouTubeVideoFailureReason? failureReason = null;
            if (obj.HasValue("failureReason")) {
                string strReason = obj.GetString("failureReason");
                if (Enum.TryParse(strReason, out YouTubeVideoFailureReason reason)) {
                    failureReason = reason;
                } else {
                    throw new Exception("Unknown failure reason \"" + strReason + "\" - please create an issue so it can be fixed https://github.com/abjerner/Skybrud.Social.Google/issues/new");
                }
            }

            // Parse the rejection reason
            YouTubeVideoRejectionReason? rejectionReason = null;
            if (obj.HasValue("rejectionReason")) {
                string strReason = obj.GetString("rejectionReason");
                if (Enum.TryParse(strReason, out YouTubeVideoRejectionReason reason)) {
                    rejectionReason = reason;
                } else {
                    throw new Exception("Unknown rejection reason \"" + strReason + "\" - please create an issue so it can be fixed https://github.com/abjerner/Skybrud.Social.Google/issues/new");
                }
            }

            // Parse the privacy status
            string strPrivacyStatus = obj.GetString("privacyStatus");
            if (!Enum.TryParse(strPrivacyStatus, true, out YouTubePrivacyStatus privacyStatus)) {
                throw new Exception("Unknown privacy status \"" + strPrivacyStatus + "\" - please create an issue so it can be fixed https://github.com/abjerner/Skybrud.Social.Google/issues/new");
            }

            // Parse the privacy status
            string strLicense = obj.GetString("license");
            if (!Enum.TryParse(strLicense, true, out YouTubeVideoLicense videoLicense)) {
                throw new Exception("Unknown license \"" + strLicense + "\" - please create an issue so it can be fixed https://github.com/abjerner/Skybrud.Social.Google/issues/new");
            }

            // Update the properties
            UploadStatus = uploadStatus;
            PrivacyStatus = privacyStatus;
            FailureReason = failureReason;
            RejectionReason = rejectionReason;
            License = videoLicense;
            IsEmbeddable = obj.GetBoolean("embeddable");
            PublicStatsViewable = obj.GetBoolean("publicStatsViewable");

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubeVideoStatus"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubeVideoStatus"/>.</returns>
        public static YouTubeVideoStatus Parse(JObject obj) {
            return obj == null ? null : new YouTubeVideoStatus(obj);
        }

        #endregion

    }

}