using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Skybrud.Social.Google.YouTube.Exceptions;
using Skybrud.Social.Google.YouTube.Options.Common;

namespace Skybrud.Social.Google.YouTube.Options.Videos {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/videos/list#part</cref>
    /// </see>
    public class YouTubeVideoPart : YouTubePart {

        #region Constructors

        /// <summary>
        /// Initializes a new part with the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="alias">The alias of the scope.</param>
        public YouTubeVideoPart(string alias) : base(alias) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="str"/> into an instance of <see cref="YouTubeVideoPart"/>.
        /// </summary>
        /// <param name="str">The string with the name of the part.</param>
        /// <returns>An instance of <see cref="YouTubeVideoPart"/> representing the part.</returns>
        public static YouTubeVideoPart Parse(string str) {
            if (TryParse(str, out YouTubeVideoPart? part)) return part;
            throw new YouTubeUnknownPartException(str);
        }

        /// <summary>
        /// Attempts to parse the specified <paramref name="str"/> into an instance of <see cref="YouTubeVideoPart"/>.
        /// </summary>
        /// <param name="str">The string with the name of the part.</param>
        /// <param name="part">The parsed part.</param>
        /// <returns><c>true</c> if <paramref name="str"/> matches a known part, otherwise <c>false</c>.</returns>
        public static bool TryParse(string str, [NotNullWhen(true)] out YouTubeVideoPart? part) {
            part = YouTubeVideoParts.Values.FirstOrDefault(temp => temp.Alias == str);
            return part != null;
        }

        #endregion

        #region Operator overloading

        /// <summary>
        /// Initializes a new part with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        public static implicit operator YouTubeVideoPart(string name) {
            return Parse(name);
        }

        /// <summary>
        /// Initializes a new collection based on <paramref name="left"/> and <paramref name="right"/>.
        /// </summary>
        /// <param name="left">The part to the left of the operator.</param>
        /// <param name="right">The part to the right of the operator.</param>
        public static YouTubeVideoPartList operator +(YouTubeVideoPart left, YouTubeVideoPart right) {
            return new YouTubeVideoPartList(left, right);
        }

        #endregion

    }

}