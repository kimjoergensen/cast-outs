using UnityEngine;

namespace WarlockBrawl.Extensions {
    /// <summary>
    /// Prints error messages for the Assert library.
    /// </summary>
	public static class AssertUtility {
        /// <summary>
        /// Used in Assert.IsNotNull for variable references.
        /// </summary>
        /// <example>
        /// Assert.IsNotNull(variable, AssertUtility.ReferenceNullErrorMessage(nameof(variable), this));
        /// </example>
        /// <param name="asserted">The asserted reference.</param>
        /// <param name="script">Should always be 'gameObject'</param>
        public static string ReferenceNullErrorMessage<T>(T asserted, GameObject gameObject) {
            return $"{asserted} is not being initialized on '{gameObject.name}'.";
        }

        /// <summary>
        /// Used in Assert.IsNotNull for the game object's components.
        /// </summary>
        /// <example>
        /// Assert.IsNotNull(GetComponent<T>(), AssertUtility.ComponentNullErrorMessage(nameof(T), gameObject));
        /// </example>
        /// <param name="asserted">The asserted component.</param>
        /// <param name="gameObject">Should always be 'gameObject'</param>
        public static string ComponentNullErrorMessage<T>(T asserted, GameObject gameObject) {
            return $"{asserted} component is missing on '{gameObject.name}'.";
        }

        /// <summary>
        /// Used in Assert.IsTrue for asserting the count of a list is greater than 0.
        /// </summary>
        /// <example>
        /// Assert.IsTrue(list.Count > 0, AssertUtility.ListEmptyErrorMessage(nameof(list), gameObject));
        /// </example>
        /// <param name="asserted">The asserted list.</param>
        /// <param name="gameObject">Should always be 'gameObject'</param>
        public static string ListEmptyErrorMessage<T>(T asserted, GameObject gameObject) {
            return $"{asserted}'s list is empty on '{gameObject.name}'.";
        }

        /// <summary>
        /// Used in Assert.IsTrue for asserting the count of a list is equal to a <paramref name="expectedCount"/>
        /// </summary>
        /// <example>
        /// Assert.IsTrue(list.Count = 7, AssertUtility.ListEmptyErrorMessage(nameof(list), 7, gameObject));
        /// </example>
        /// <typeparam name="T"></typeparam>
        /// <param name="asserted"></param>
        /// <param name="expectedCount"></param>
        /// <param name="gameObject">Should alwyas be 'gameObject'</param>
        public static string ListNotExpectedCountErrorMessage<T>(T asserted, int expectedCount, GameObject gameObject) {
            return $"{asserted} did not have expected count of {expectedCount} on '{gameObject.name}'.";
        }
    }
}
