using System;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Social.Google.YouTube.Options.Videos {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/videos/list#part</cref>
    /// </see>
    public class YouTubeVideoPartList {

        #region Private fields

        private readonly List<YouTubeVideoPart> _list = new List<YouTubeVideoPart>();

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
        public YouTubeVideoPartList() { }

        /// <summary>
        /// Initializes a collection containing the specified <paramref name="parts"/>.
        /// </summary>
        /// <param name="parts">The parts to add.</param>
        public YouTubeVideoPartList(params YouTubeVideoPart[] parts) {
            _list.AddRange(parts);
        }

        /// <summary>
        /// Initializes a collection containing the specified <paramref name="parts"/>.
        /// </summary>
        /// <param name="parts">The parts to add.</param>
        public YouTubeVideoPartList(IEnumerable<YouTubeVideoPart> parts) {
            _list.AddRange(parts);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds the specified <paramref name="part"/> to the collection.
        /// </summary>
        /// <param name="part">The part to add.</param>
        public void Add(YouTubeVideoPart part) {
            _list.Add(part);
        }

        /// <summary>
        /// Adds the specified range of <paramref name="parts"/> to the collection.
        /// </summary>
        /// <param name="parts">The parts to add.</param>
        public void AddRange(IEnumerable<YouTubeVideoPart> parts) {
            _list.AddRange(parts);
        }

        /// <summary>
        /// Gets an array of the parts currently in the collection.
        /// </summary>
        /// <returns>An array of <see cref="YouTubeVideoPart"/> representing the parts of the collection.</returns>
        public YouTubeVideoPart[] ToArray() {
            return _list.ToArray();
        }

        /// <summary>
        /// Gets a string array of the parts currently in the collection.
        /// </summary>
        /// <returns>An array of <see cref="string"/> representing the parts of the collection.</returns>
        public string[] ToStringArray() {
            return (from part in _list select part.Name).ToArray();
        }

        /// <summary>
        /// Gets a string representation if the parts currently in the collection.
        /// </summary>
        /// <returns>An array of <see cref="string"/> representing the parts of the collection.</returns>
        public override string ToString() {
            return string.Join(",", from part in _list select part.Name);
        }

        #endregion

        #region Operator overloading

        /// <summary>
        /// Initializes a new collection from the specified <paramref name="part"/>.
        /// </summary>
        /// <param name="part">The instance of <see cref="YouTubeVideoPart"/> representing the part.</param>
        /// <returns>An instance of <see cref="YouTubeVideoPartList"/>.</returns>
        public static implicit operator YouTubeVideoPartList(YouTubeVideoPart part) {
            return new YouTubeVideoPartList(part);
        }

        /// <summary>
        /// Initializes a new collection from the specified <paramref name="parts"/>.
        /// </summary>
        /// <param name="parts">An array of <see cref="YouTubeVideoPart"/> representing the parts.</param>
        /// <returns>An instance of <see cref="YouTubeVideoPartList"/>.</returns>
        public static implicit operator YouTubeVideoPartList(YouTubeVideoPart[] parts) {
            return new YouTubeVideoPartList(parts);
        }

        /// <summary>
        /// Adds the specified <paramref name="part"/> to <paramref name="collection"/>.
        /// </summary>
        /// <param name="collection">The collection to which <paramref name="part"/> should be added.</param>
        /// <param name="part">The part to be added to <paramref name="collection"/>.</param>
        /// <returns>An instance of <see cref="YouTubeVideoPartList"/>.</returns>
        public static YouTubeVideoPartList operator +(YouTubeVideoPartList collection, YouTubeVideoPart part) {
            collection.Add(part);
            return collection;
        }

        /// <summary>
        /// Initializes a new collection from the specified string array of <paramref name="parts"/>.
        /// </summary>
        /// <param name="parts">A string array of the parts that should make up the collection.</param>
        /// <returns>An instance of <see cref="YouTubeVideoPartList"/>.</returns>
        public static implicit operator YouTubeVideoPartList(string[] parts) {
            return new YouTubeVideoPartList(from YouTubeVideoPart part in parts select part);
        }

        #endregion

    }

}