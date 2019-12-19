namespace Skybrud.Social.Google.YouTube.Models.Videos {

    /// <summary>
    /// Enum class representing the reason why the upload of a YouTube video failed.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/videos#status.failureReason</cref>
    /// </see>
    public enum YouTubeVideoFailureReason {
        Codec,
        Conversion,
        EmptyFile,
        InvalidFile,
        TooSmall,
        UploadAborted
    }

}