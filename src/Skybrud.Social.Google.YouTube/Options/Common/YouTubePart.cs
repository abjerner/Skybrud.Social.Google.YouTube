namespace Skybrud.Social.Google.YouTube.Options.Common {

    /// <summary>
    /// Abstract class representing a part for a YouTube resource.
    /// </summary>
    public abstract class YouTubePart {

        #region Properties
        
        /// <summary>
        /// Gets the name of the part.
        /// </summary>
        public string Name { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new part with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        protected YouTubePart(string name) {
            Name = name;
        }

        #endregion
    
    }

}