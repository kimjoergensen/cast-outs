namespace CastOuts.Shared.Extensions
{
  using UnityEngine;

  /// <summary>
  /// Extension methods for Vector3.
  /// </summary>
  public static class Vector3Extensions
  {
    /// <summary>
    /// Limits the coordinates of <paramref name="position"/> X and Z axes by the values of <paramref name="limits"/> X and Y axes respectively.
    /// </summary>
    /// <param name="position">The position.</param>
    /// <param name="limits">The limits.</param>
    /// <param name="offset">The offset.</param>
    /// <returns>position with it's X and Z axes limited by the values of limits X and Y axes respectively.</returns>
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
