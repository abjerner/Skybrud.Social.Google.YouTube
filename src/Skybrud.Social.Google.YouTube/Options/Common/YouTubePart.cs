namespace Skybrud.Social.Google.YouTube.Options.Common {

    /// <summary>
    /// Abstract class representing a part for a YouTube resource.
    /// </summary>
    public abstract class YouTubePart {

        #region Properties

        /// <summary>
        /// Gets the alias of the part.
        /// </summary>
        public string Alias { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new part with the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="alias">The alias  of the scope.</param>
        protected YouTubePart(string alias) {
            Alias = alias;
        }

        #endregion

    }

}