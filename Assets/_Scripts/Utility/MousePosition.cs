using UnityEngine;

namespace WarlockBrawl.Utility {
    public static class MouseUtility {
        /// <summary>
        /// Shoot a <see cref="Ray"/> from the <see cref="UnityEngine.Camera"/> to the <see cref="Input.mousePosition"/>.
        /// Returns true if a <see cref="Vector3"/> position was found, else returns false.
        /// Out the <see cref="Vector3"/> position in world space where the <see cref="Ray"/> hit.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="shouldHaveTransform"></param>
        /// <param name="layerMask"></param>
        /// <returns></returns>
        public static bool TryGetPosition(out Vector3 position, bool shouldHaveTransform = false, LayerMask? layerMask = null) {
            // Set default value for position in case the methods returns false.
            position = new Vector3();

            // Return false if the raycast cast from the camera to the mouse position did not hit a valid object.
            RaycastHit hit;
            if (layerMask != null) {
                // Get the bit mask from the passer layer mask.
                int bitMask = 1 << (int)layerMask;

                if (!Physics.Raycast(UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000, bitMask)) return false;
            } else {
                if (!Physics.Raycast(UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000)) return false;
            }

            // Return false if the object hit by the raycast should have a transform, but does not.
            if (shouldHaveTransform && !hit.transform) return false;

            // Set the target position to the point in space where the mouse is.
            position = hit.point;

            return true;
        }
    }
}
