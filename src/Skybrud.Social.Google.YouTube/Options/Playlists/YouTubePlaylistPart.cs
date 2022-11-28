using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Skybrud.Social.Google.YouTube.Exceptions;
using Skybrud.Social.Google.YouTube.Options.Common;

namespace Skybrud.Social.Google.YouTube.Options.Playlists {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlists/list#part</cref>
    /// </see>
    public class YouTubePlaylistPart : YouTubePart {

        #region Constructors

        /// <summary>
        /// Initializes a new part with the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="alias">The alias of the scope.</param>
        public YouTubePlaylistPart(string alias) : base(alias) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="str"/> into an instance of <see cref="YouTubePlaylistPart"/>.
        /// </summary>
        /// <param name="str">The string with the name of the part.</param>
        /// <returns>An instance of <see cref="YouTubePlaylistPart"/> representing the part.</returns>
        public static YouTubePlaylistPart Parse(string str) {
            if (TryParse(str, out YouTubePlaylistPart? part)) return part;
            throw new YouTubeUnknownPartException(str);
        }

        /// <summary>
        /// Attempts to parse the specified <paramref name="str"/> into an instance of <see cref="YouTubePlaylistPart"/>.
        /// </summary>
        /// <param name="str">The string with the name of the part.</param>
        /// <param name="part">The parsed part.</param>
        /// <returns><c>true</c> if <paramref name="str"/> matches a known part, otherwise <c>false</c>.</returns>
        public static bool TryParse(string str, [NotNullWhen(true)] out YouTubePlaylistPart? part) {
            part = YouTubePlaylistParts.Values.FirstOrDefault(temp => temp.Alias == str);
            return part != null;
        }

        #endregion

        #region Operator overloading

        /// <summary>
        /// Initializes a new part with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        public static implicit operator YouTubePlaylistPart(string name) {
            return Parse(name);
        }

        /// <summary>
        /// Initializes a new collection based on <paramref name="left"/> and <paramref name="right"/>.
        /// </summary>
        /// <param name="left">The part to the left of the operator.</param>
        /// <param name="right">The part to the right of the operator.</param>
        public static YouTubePlaylistPartList operator +(YouTubePlaylistPart left, YouTubePlaylistPart right) {
            return new YouTubePlaylistPartList(left, right);
        }

        #endregion

    }

}