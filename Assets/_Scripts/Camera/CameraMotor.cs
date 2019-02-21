using System;
using UnityEngine;
using UnityEngine.Assertions;
using WarclockBrawl;
using WarlockBrawl.Extensions;
using WarlockBrawl.Utility;

namespace WarlockBrawl.Camera {
    [Serializable]
    public class CameraMotorEssentials {
        [Tooltip("Set the camera to control from the motor.")]
        public UnityEngine.Camera camera;
    }

    [Serializable]
    public class CameraMotorSettings {
        [Tooltip("The movement speed of the camera.")]
        public float MovementSpeed;
        [Tooltip("The amount of pixels, from the edge of the screen, the mouse needs to enter, before moving the camera.")]
        public float EdgeBoundary;
        [Tooltip("The length the camera can move from it's initial position, on each axis.")]
        public Vector3 MovementLimit;
    }

    public class CameraMotor : MonoBehaviour {
        #region Inspector menues
        [Tooltip("Essential components on the camera game object.")]
        public CameraMotorEssentials essentials;
        [Tooltip("Settings for the camera behavior.")]
        public CameraMotorSettings settings;
        [Tooltip("User input for camera controls.")]
        public InputManager.CameraInputs inputs;
        #endregion

        #region Class variables

        #endregion

        private void OnValidate() {
            Validate();
        }

        /// <summary>
        /// Validate the code in the editor at compile time.
        /// </summary>
        private void Validate() {
            // References
            Assert.IsNotNull(essentials?.camera, AssertUtility.ReferenceIsNotNullErrorMessage(nameof(essentials.camera), this));

            // Components
            Assert.IsNotNull(gameObject?.transform, AssertUtility.ComponentIsNotNullErrorMessage(nameof(Transform), gameObject));
            Assert.IsNotNull(GetComponent<UnityEngine.Camera>(), AssertUtility.ComponentIsNotNullErrorMessage(nameof(UnityEngine.Camera), gameObject));
            Assert.IsNotNull(GetComponent<AudioListener>(), AssertUtility.ComponentIsNotNullErrorMessage(nameof(AudioListener), gameObject));
        }
    }
}
