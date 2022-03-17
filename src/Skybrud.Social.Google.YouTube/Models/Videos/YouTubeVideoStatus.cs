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

        /// <summary>
        /// Gets the status of the uploaded video.
        /// </summary>
        public YouTubeVideoUploadStatus UploadStatus { get; }

        /// <summary>
        /// This value explains why a video failed to upload. This property is only present if the
        /// <see cref="UploadStatus"/> property indicates that the upload failed.
        /// </summary>
        public YouTubeVideoFailureReason? FailureReason { get; }

        /// <summary>
        /// This value explains why YouTube rejected an uploaded video. This property is only present if the
        /// <see cref="UploadStatus"/> property indicates that the upload was rejected.
        /// </summary>
        public YouTubeVideoRejectionReason? RejectionReason { get; }

        /// <summary>
        /// Gets the video's privacy status.
        /// </summary>
        public YouTubePrivacyStatus PrivacyStatus { get; }

        /// <summary>
        /// Gets the video's license.
        /// </summary>
        public YouTubeVideoLicense License { get; }

        /// <summary>
        /// Gets whether the video can be embedded on another website.
        /// </summary>
        public bool IsEmbeddable { get; }

        /// <summary>
        /// Gets whether the extended video statistics on the video's watch page are publicly viewable. By default,
        /// those statistics are viewable, and statistics like a video's viewcount and ratings will still be publicly
        /// visible even if this property's value is set to <c>false</c>.
        /// </summary>
        public bool IsPublicStatsViewable { get; }

        #endregion

        #region Constructor
        
        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected YouTubeVideoStatus(JObject json) : base(json) {


            // Parse the upload status
            string strUploadStatus = json.GetString("uploadStatus");
            if (!Enum.TryParse(strUploadStatus, true, out YouTubeVideoUploadStatus uploadStatus)) {
                throw new Exception("Unknown upload status \"" + strUploadStatus + "\" - please create an issue so it can be fixed https://github.com/abjerner/Skybrud.Social.Google/issues/new");
            }

            // Parse the failure reason
            YouTubeVideoFailureReason? failureReason = null;
            if (json.HasValue("failureReason")) {
                string strReason = json.GetString("failureReason");
                if (Enum.TryParse(strReason, out YouTubeVideoFailureReason reason)) {
                    failureReason = reason;
                } else {
                    throw new Exception("Unknown failure reason \"" + strReason + "\" - please create an issue so it can be fixed https://github.com/abjerner/Skybrud.Social.Google/issues/new");
                }
            }

            // Parse the rejection reason
            YouTubeVideoRejectionReason? rejectionReason = null;
            if (json.HasValue("rejectionReason")) {
                string strReason = json.GetString("rejectionReason");
                if (Enum.TryParse(strReason, out YouTubeVideoRejectionReason reason)) {
                    rejectionReason = reason;
                } else {
                    throw new Exception("Unknown rejection reason \"" + strReason + "\" - please create an issue so it can be fixed https://github.com/abjerner/Skybrud.Social.Google/issues/new");
                }
            }

            // Parse the privacy status
            string strPrivacyStatus = json.GetString("privacyStatus");
            if (!Enum.TryParse(strPrivacyStatus, true, out YouTubePrivacyStatus privacyStatus)) {
                throw new Exception("Unknown privacy status \"" + strPrivacyStatus + "\" - please create an issue so it can be fixed https://github.com/abjerner/Skybrud.Social.Google/issues/new");
            }

            // Parse the privacy status
            string strLicense = json.GetString("license");
            if (!Enum.TryParse(strLicense, true, out YouTubeVideoLicense videoLicense)) {
                throw new Exception("Unknown license \"" + strLicense + "\" - please create an issue so it can be fixed https://github.com/abjerner/Skybrud.Social.Google/issues/new");
            }

            // Update the properties
            UploadStatus = uploadStatus;
            PrivacyStatus = privacyStatus;
            FailureReason = failureReason;
            RejectionReason = rejectionReason;
            License = videoLicense;
            IsEmbeddable = json.GetBoolean("embeddable");
            IsPublicStatsViewable = json.GetBoolean("publicStatsViewable");

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="YouTubeVideoStatus"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="YouTubeVideoStatus"/>.</returns>
        public static YouTubeVideoStatus Parse(JObject json) {
            return json == null ? null : new YouTubeVideoStatus(json);
        }

        #endregion

    }

}