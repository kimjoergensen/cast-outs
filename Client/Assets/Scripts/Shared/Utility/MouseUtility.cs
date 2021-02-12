using UnityEngine;

namespace CastOuts.Shared.Utility
{
  /// <summary>
  /// Utility class for mouse functionality.
  /// </summary>
  public static class MouseUtility
  {
    /// <summary>
    /// Tries to get the current mouse position in world space.
    /// </summary>
    /// <param name="position">The position.</param>
    /// <param name="shouldHaveTransform">if set to <c>true</c> [should have transform].</param>
    /// <param name="layerMask">The layer mask.</param>
    /// <returns>True if a position could be found, false if not.</returns>
    /// <example>
    /// Use the class with an if-statement, to check if the mouse position can be found, and store it as a local variable to use in the if-statement's code-block.
    /// <code>
    /// if (!MouseUtility.TryGetPosition(out var position, true, null) {
    ///     // Do something with the mouse position..
    /// }
    /// </code>
    /// </example>
    public static bool TryGetPosition(out Vector3 position, bool shouldHaveTransform = true, LayerMask? layerMask = null)
    {
      // Set default value for position in case the methods returns false.
      position = new Vector3();

      // Return false if the raycast cast from the camera to the mouse position did not hit a valid object.
      RaycastHit hit;
      if (layerMask != null)
      {
        // Get the bit mask from the passer layer mask.
        int bitMask = 1 << (int)layerMask;

        if (!Physics.Raycast(UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000, bitMask)) return false;
      }
      else if (!Physics.Raycast(UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000)) return false;

      // Return false if the object hit by the raycast should have a transform, but does not.
      if (shouldHaveTransform && !hit.transform) return false;

      // Set the target position to the point in space where the mouse is.
      position = hit.point;

      return true;
    }
  }
}
