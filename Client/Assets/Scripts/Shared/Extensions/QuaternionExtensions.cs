namespace Assets.Scripts.Shared.Extensions
{
  using UnityEngine;

  /// <summary>
  /// Extension methods for Quaternions.
  /// </summary>
  public static class QuaternionExtensions
  {
    /// <summary>
    /// Returns if the rotation is within an approximately acceptable range of target rotation.
    /// </summary>
    /// <param name="rotation">The Quaternion object being checked.</param>
    /// <param name="targetRotation">The desired rotation of the Quaternion being checked.</param>
    /// <param name="range">The acceptable range in degrees.</param>
    /// <returns>True if the degrees between the rotation and targetRotation are within the range.</return>
    public static bool Approximately(this Quaternion rotation, Quaternion targetRotation, float range) {
      return 1 - Mathf.Abs(Quaternion.Dot(rotation, targetRotation)) < range / 360f;
    }
  }
}
