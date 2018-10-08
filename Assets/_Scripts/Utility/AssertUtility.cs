using UnityEngine;

namespace WarlockBrawl.Extensions {
    /// <summary>
    /// Prints error messages for the Assert library.
    /// </summary>
	public static class AssertUtility {
        /// <summary>
        /// Used in Assert.IsNotNull for variables references.
        /// </summary>
        /// <param name="asserted">The asserted reference.</param>
        /// <param name="script">Should always be 'this'</param>
        public static string ReferenceIsNotNullErrorMessage<TAsserted, TScript>(TAsserted asserted, TScript script) {
            return $"{asserted} is not being initialized in '{script}' script.";
        }

        /// <summary>
        /// Used in Assert.IsNotNull for the game object's components.
        /// </summary>
        /// <param name="asserted">The asserted component.</param>
        /// <param name="gameObject">Should always be 'gameObject'</param>
        public static string ComponentIsNotNullErrorMessage<T>(T asserted, GameObject gameObject) {
            return $"{asserted} component is missing on '{gameObject.name}' game object.";
        }
    }
}
