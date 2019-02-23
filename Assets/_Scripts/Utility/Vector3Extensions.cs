using UnityEngine;

namespace WarlockBrawl.Utility {
    public static class Vector3Extensions{
        /// <summary>
        /// Limit the coordinates of a vector in all directions.
        /// </summary>
        /// <param name="limits">Vector3 containing the spectrum that the vector can move within.</param>
        /// <param name="offset">Add a Vector3 offset to exclude the offset from the calculations.</param>
        public static Vector3 LimitCoordinates(this Vector3 position, Vector2 limits, Vector3? offset = null) {
            // Add the offset from the limits calculations.
            position += offset ?? Vector3.zero;

            // Keep the camera's position within the limits.
            position.x = Mathf.Clamp(position.x, -limits.x, limits.x);
            position.z = Mathf.Clamp(position.z, -limits.y, limits.y);

            // Remove offsets position and return the position with the clamped values.
            position -= offset ?? Vector3.zero;

            return position;
        }
    }
}
