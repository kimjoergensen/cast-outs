using UnityEngine;

namespace WarlockBrawl.Utility {
    /// <summary>
    /// Prints formatted error messages for assertions.
    /// </summary>
	public class AssertUtility : MonoBehaviour {
        /// <summary>
        /// Print a formatted error message when asserting a property is set to the correct type.
        /// </summary>
        /// <typeparam name="T">Type of asserted class.</typeparam>
        /// <param name="propertyName">A string containing the property's reference name.</param>
        /// <param name="nullComponentType">The actual type asserted against the expected type in the assertion.</param>
        /// <param name="gameObject">Should always be gameObject.</param>
        /// <returns></returns>
        public static string WrongTypeOrNullErrorMessage<T>(string propertyName, T expectedType, GameObject gameObject) {
            return string.Format("{0} component on {1} is not set to an instance of {2}.", propertyName, gameObject.name, expectedType.GetType());
        }
    }
}
