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
        public static string PropertyWrongTypeOrNullErrorMessage<T>(string propertyName, T expectedType, GameObject gameObject) {
            return string.Format("{0} component on {1} is not set to an instance of {2}.", propertyName, gameObject.name, expectedType.GetType());
        }

        /// <summary>
        /// Print a formatted error message when asserting a game object's component is not null.
        /// </summary>
        /// <param name="component">The asserted component.</param>
        /// <param name="gameObject">Should always be gameObject.</param>
        /// <returns></returns>
        public static string ComponentNullErrorMessage(Component component, GameObject gameObject) {
            return string.Format("{0} is missing on {1}. Please add the component to the game object.", component.name, gameObject.name);
        }
    }
}
