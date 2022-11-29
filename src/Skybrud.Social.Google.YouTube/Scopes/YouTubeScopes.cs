using System.Collections.Generic;
using Skybrud.Social.Google.Attributes;
using Skybrud.Social.Google.Scopes;

namespace Skybrud.Social.Google.YouTube.Scopes {

    /// <summary>
    /// Static class containing references to known scopes of the YouTube API.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/guides/auth/server-side-web-apps#Obtaining_Access_Tokens</cref>
    /// </see>
    [GoogleScopes("YouTube")]
    public static class YouTubeScopes {

        #region Readonly properties

        /// <summary>
        /// Manage your YouTube account.
        /// </summary>
        public static readonly YouTubeScope Manage = new(
            "https://www.googleapis.com/auth/youtube",
            "Manage",
            "Manage your YouTube account."
        );

        /// <summary>
        /// View your YouTube account.
        /// </summary>
        public static readonly YouTubeScope Readonly = new(
            "https://www.googleapis.com/auth/youtube.readonly",
            "Readonly",
            "View your YouTube account."
        );

        /// <summary>
        /// Upload YouTube videos and manage your YouTube videos.
        /// </summary>
        public static readonly YouTubeScope Upload = new(
            "https://www.googleapis.com/auth/youtube.upload",
            "Upload",
            "Upload YouTube videos and manage your YouTube videos."
        );

        /// <summary>
        /// Retrieve the auditDetails part in a channel resource.
        /// </summary>
        public static readonly YouTubeScope PartnerChannelAudit = new(
            "https://www.googleapis.com/auth/youtubepartner-channel-audit",
            "Audit partner channel",
            "Retrieve the auditDetails part in a channel resource."
        );

        /// <summary>
        /// Gets an array of all YouTube scopes.
        /// </summary>
        public static readonly IReadOnlyList<GoogleScope> All = new GoogleScope[] {
            Manage, Readonly, Upload, PartnerChannelAudit
        };

        #endregion

    }

}