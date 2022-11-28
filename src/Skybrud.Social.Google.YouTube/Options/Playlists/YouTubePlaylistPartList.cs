using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Social.Google.YouTube.Options.Playlists {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlists/list#part</cref>
    /// </see>
    public class YouTubePlaylistPartList {

        #region Private fields

        private readonly List<YouTubePlaylistPart> _list = new();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the amount of parts currently in the collection.
        /// </summary>
        public int Count => _list.Count;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an empty collection.
        /// </summary>
        public YouTubePlaylistPartList() { }

        /// <summary>
        /// Initializes a collection containing the specified <paramref name="parts"/>.
        /// </summary>
        /// <param name="parts">The parts to add.</param>
        public YouTubePlaylistPartList(params YouTubePlaylistPart[] parts) {
            _list.AddRange(parts);
        }

        /// <summary>
        /// Initializes a collection containing the specified <paramref name="parts"/>.
        /// </summary>
        /// <param name="parts">The parts to add.</param>
        public YouTubePlaylistPartList(IEnumerable<YouTubePlaylistPart> parts) {
            _list.AddRange(parts);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds the specified <paramref name="part"/> to the collection.
        /// </summary>
        /// <param name="part">The part to add.</param>
        public void Add(YouTubePlaylistPart part) {
            _list.Add(part);
        }

        /// <summary>
        /// Adds the specified range of <paramref name="parts"/> to the collection.
        /// </summary>
        /// <param name="parts">The parts to add.</param>
        public void AddRange(IEnumerable<YouTubePlaylistPart> parts) {
            _list.AddRange(parts);
        }

        /// <summary>
        /// Gets an array of the parts currently in the collection.
        /// </summary>
        /// <returns>An array of <see cref="YouTubePlaylistPart"/> representing the parts of the collection.</returns>
        public YouTubePlaylistPart[] ToArray() {
            return _list.ToArray();
        }

        /// <summary>
        /// Gets a string array of the parts currently in the collection.
        /// </summary>
        /// <returns>An array of <see cref="string"/> representing the parts of the collection.</returns>
        public string[] ToStringArray() {
            return (from part in _list select part.Alias).ToArray();
        }

        /// <summary>
        /// Gets a string representation if the parts currently in the collection.
        /// </summary>
        /// <returns>An array of <see cref="string"/> representing the parts of the collection.</returns>
        public override string ToString() {
            return string.Join(",", from part in _list select part.Alias);
        }

        #endregion

        #region Operator overloading

        /// <summary>
        /// Initializes a new collection from the specified <paramref name="part"/>.
        /// </summary>
        /// <param name="part">The instance of <see cref="YouTubePlaylistPart"/> representing the part.</param>
        /// <returns>An instance of <see cref="YouTubePlaylistPartList"/>.</returns>
        public static implicit operator YouTubePlaylistPartList(YouTubePlaylistPart part) {
            return new YouTubePlaylistPartList(part);
        }

        /// <summary>
        /// Initializes a new collection from the specified <paramref name="parts"/>.
        /// </summary>
        /// <param name="parts">An array of <see cref="YouTubePlaylistPart"/> representing the parts.</param>
        /// <returns>An instance of <see cref="YouTubePlaylistPartList"/>.</returns>
        public static implicit operator YouTubePlaylistPartList(YouTubePlaylistPart[] parts) {
            return new YouTubePlaylistPartList(parts);
        }

        /// <summary>
        /// Adds the specified <paramref name="part"/> to <paramref name="collection"/>.
        /// </summary>
        /// <param name="collection">The collection to which <paramref name="part"/> should be added.</param>
        /// <param name="part">The part to be added to <paramref name="collection"/>.</param>
        /// <returns>An instance of <see cref="YouTubePlaylistPartList"/>.</returns>
        public static YouTubePlaylistPartList operator +(YouTubePlaylistPartList collection, YouTubePlaylistPart part) {
            collection.Add(part);
            return collection;
        }

        /// <summary>
        /// Initializes a new collection from the specified string array of <paramref name="parts"/>.
        /// </summary>
        /// <param name="parts">A string array of the parts that should make up the collection.</param>
        /// <returns>An instance of <see cref="YouTubePlaylistPartList"/>.</returns>
        public static implicit operator YouTubePlaylistPartList(string[] parts) {
            return new YouTubePlaylistPartList(from YouTubePlaylistPart part in parts select part);
        }

        #endregion

    }

}