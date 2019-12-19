using System.Linq;
using Skybrud.Social.Google.YouTube.Exceptions;
using Skybrud.Social.Google.YouTube.Options.Common;

namespace Skybrud.Social.Google.YouTube.Options.PlaylistItems {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlistItems/list#part</cref>
    /// </see>
    public class YouTubePlaylistItemPart : YouTubePart {

        #region Constructors

        /// <summary>
        /// Initializes a new part with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        public YouTubePlaylistItemPart(string name) : base(name) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="str"/> into an instance of <see cref="YouTubePlaylistItemPart"/>.
        /// </summary>
        /// <param name="str">The string with the name of the part.</param>
        /// <returns>An instance of <see cref="YouTubePlaylistItemPart"/> representing the part.</returns>
        public static YouTubePlaylistItemPart Parse(string str) {
            if (TryParse(str, out YouTubePlaylistItemPart part)) return part;
            throw new YouTubeUnknownPartException(str);
        }

        /// <summary>
        /// Attempts to parse the specified <paramref name="str"/> into an instance of <see cref="YouTubePlaylistItemPart"/>.
        /// </summary>
        /// <param name="str">The string with the name of the part.</param>
        /// <param name="part">The parsed part.</param>
        /// <returns><c>true</c> if <paramref name="str"/> matches a known part, otherwise <c>false</c>.</returns>
        public static bool TryParse(string str, out YouTubePlaylistItemPart part) {
            part = YouTubePlaylistItemParts.Values.FirstOrDefault(temp => temp.Name == str);
            return part != null;
        }

        #endregion

        #region Operator overloading

        /// <summary>
        /// Initializes a new part with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <returns>An instance of <see cref="YouTubePlaylistItemPartsCollection"/>.</returns>
        public static implicit operator YouTubePlaylistItemPart(string name) {
            return Parse(name);
        }

        /// <summary>
        /// Initializes a new collection based on <paramref name="left"/> and <paramref name="right"/>.
        /// </summary>
        /// <param name="left">The part to the left of the operator.</param>
        /// <param name="right">The part to the right of the operator.</param>
        /// <returns>An instance of <see cref="YouTubePlaylistItemPartsCollection"/>.</returns>
        public static YouTubePlaylistItemPartsCollection operator +(YouTubePlaylistItemPart left, YouTubePlaylistItemPart right) {
            return new YouTubePlaylistItemPartsCollection(left, right);
        }

        #endregion
    
    }

}