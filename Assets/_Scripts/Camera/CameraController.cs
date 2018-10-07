using System;
using UnityEngine;
using UnityEngine.Assertions;
using WarlockBrawl.Utility;

namespace WarlockBrawl.Camera {
    [Serializable]
    public class CameraControllerEssentials {
        public UnityEngine.Camera camera;
    }

    [Serializable]
    public class CameraControllerSettings {

    }

    public class CameraController : MonoBehaviour {
        #region Inspector menues
        public CameraControllerEssentials essentials;
        public CameraControllerSettings settings;
        #endregion

        /// <summary>
        /// Gets called when CameraController is initialized.
        /// </summary>
        private void Awake() {
            essentials = new CameraControllerEssentials();
            settings = new CameraControllerSettings();
        }

        /// <summary>
        /// Editor validation
        /// </summary>
        private void OnValidate() {
            Validate();
        }

        /// <summary>
        /// Validate the code in the editor at compile time.
        /// </summary>
        private void Validate() {
            Assert.AreEqual(essentials.camera.GetType(), typeof(UnityEngine.Camera), AssertUtility.WrongTypeOrNullErrorMessage("Camera", essentials.camera, gameObject);
        }
    }
}
