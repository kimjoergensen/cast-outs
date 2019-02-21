using UnityEngine;

namespace WarlockBrawl.Utility {
    public static class Vector3Extensions{
        /// <summary>
        /// Limit the coordinates of a vector in all directions.
        /// </summary>
        /// <param name="limits">Vector3 containing the spectrum that the vector can move within.</param>
        /// <param name="offset">Add a Vector3 offset to exclude the offset from the calculations.</param>
        public static void LimitCoordinates(this Vector3 position, Vector2 limits, Vector3? offset = null) {
            // Remove the offset from the limits calculations
            position -= offset ?? Vector3.zero;

            // Keep the camera's position within the limits.
            position.x = Mathf.Clamp(position.x, -limits.x, limits.x);
            position.y = Mathf.Clamp(position.z, -limits.y, limits.y);

            // Add the offset again to get the actual position of the camera with it's offset values.
            position += offset ?? Vector3.zero;
        }
    }
}
