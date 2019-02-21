namespace WarlockBrawl.Utility {
    public static class CameraExtensions
    {
        /// <summary>
        /// Set the <paramref name="camera"/> to the <paramref name="cameraReference"/> <see cref="UnityEngine.Camera"/>.
        /// If no <see cref="UnityEngine.Camera"/> has been passed in the <paramref name="cameraReference"/> param
        /// it will set the <paramref name="camera"/> to <see cref="UnityEngine.Camera.main"/>
        /// </summary>
        /// <param name="camera">Extension object.</param>
        /// <param name="cameraReference">Set this param to set the <paramref name="camera"/> to the <paramref name="cameraReference"/> <see cref="UnityEngine.Camera"/></param>
        /// <returns></returns>
        public static void FindCamera(this UnityEngine.Camera camera, UnityEngine.Camera cameraReference = null) {
            if(cameraReference != null)
                camera = cameraReference;
            else
                camera = UnityEngine.Camera.main;
        }
    }
}
