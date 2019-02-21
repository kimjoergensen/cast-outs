using System;
using UnityEngine;
using UnityEngine.Assertions;
using WarlockBrawl.Extensions;
using WarlockBrawl.Utility;

namespace WarlockBrawl.Camera {
    [Serializable]
    public class CameraMovementControllerEssentials {
        [Tooltip("Set the camera motor this script controls.")]
        public CameraMotor motor;
    }

    [Serializable]
    public class CameraMovementControllerSettings {
        [Tooltip("The movement speed of the camera.")]
        public float speed;
        [Tooltip("The amount of pixels from the screen edge the mouse needs to enter before moving the camera.")]
        public float edgeBoundary;
        [Tooltip("Limits the cameras movemen on the X and Z axis by the amount specified.")]
        public Vector2 limit;
    }

    public class CameraMovementController : MonoBehaviour
    {
        #region Inspector menues
        [Tooltip("Essential components for the camera movement script.")]
        public CameraMovementControllerEssentials essentials;
        [Tooltip("Settings for the camera movement script.")]
        public CameraMovementControllerSettings settings;
        #endregion

        #region Class variables
        private Vector3 _desiredCameraPosition;
        private int _screenWidth;
        private int _screenHeight;
        #endregion

        private void OnValidate() {
            Validate();
        }

        private void Start() {
            _screenWidth = Screen.width;
            _screenHeight = Screen.height;
        }

        private void Update() {
            // Get updates made to the desired movement of the camera.
            SetDesiredCameraPosition();
        }

        private void FixedUpdate() {
            // Check if the current camera position is not at the desired camera position.
            if(!transform.position.Equals(_desiredCameraPosition)) {
                // Move the camera towards the desired camera position.
                MoveCamera(_desiredCameraPosition);
            }
        }

        /// <summary>
        /// Checks if the mouse position is within the boundary limit of the screen edge.
        /// </summary>
        private void SetDesiredCameraPosition() {
            var position = transform.position;

            // Check if the mouse is within the boundary of the screen's right edge
            if(Input.mousePosition.x > _screenWidth - settings.edgeBoundary || Input.GetKey(essentials.motor.inputs.MoveRight))
                position.x += settings.speed * Time.deltaTime;

            // Check if the mouse is within the boundary of the screen's left edge
            if(Input.mousePosition.x < settings.edgeBoundary || Input.GetKey(essentials.motor.inputs.MoveLeft))
                position.x -= settings.speed * Time.deltaTime;

            // Check if the mouse is within the boundary of the screen's top edge
            if(Input.mousePosition.y > _screenHeight - settings.edgeBoundary || Input.GetKey(essentials.motor.inputs.MoveUp))
                position.z += settings.speed * Time.deltaTime;

            // Check if the mouse is within the boundary of the screen's bottom edge
            if(Input.mousePosition.y < settings.edgeBoundary || Input.GetKey(essentials.motor.inputs.MoveDown))
                position.z -= settings.speed * Time.deltaTime;

            // Keep the desired camera position within the directional limits.
            position.LimitCoordinates(settings.limit);

            _desiredCameraPosition = position;
        }

        /// <summary>
        /// Moves the camera from the current position towards the expected position.
        /// </summary>
        /// <param name="desiredCameraPosition">Expected position of the camera after movement.</param>
        private void MoveCamera(Vector3 desiredCameraPosition) {
            transform.position = Vector3.MoveTowards(transform.position, _desiredCameraPosition, settings.speed * Time.deltaTime);
        }

        /// <summary>
        /// Validate the code in the editor at compile time.
        /// </summary>
        private void Validate() {
            // Components
            Assert.IsNotNull(GetComponent<CameraMotor>(), AssertUtility.ComponentIsNotNullErrorMessage(nameof(CameraMotor), gameObject));
        }
    }
}
