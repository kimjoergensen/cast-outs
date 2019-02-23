using System;
using UnityEngine;
using UnityEngine.Assertions;
using WarclockBrawl;
using WarlockBrawl.Extensions;
using WarlockBrawl.Utility;

namespace WarlockBrawl.Camera {
    [Serializable]
    public class CameraMovementEssentials {
        [Tooltip("Set the camera offset. Use camera's own offset if no offset should be applied.")]
        public Transform offset;
    }

    [Serializable]
    public class CameraMovementSettings {
        [Tooltip("The movement speed of the camera.")]
        public float speed;
        [Tooltip("The amount of pixels from the screen edge the mouse needs to enter before moving the camera.")]
        public float boundary;
        [Tooltip("Limits the cameras movemen on the X and Z axis by the amount specified.")]
        public Vector2 limits;
    }

    public class CameraMovement : MonoBehaviour {
        #region Inspector menues
        [Tooltip("Essential components for the CameraMovement script.")]
        public CameraMovementEssentials essentials;
        [Tooltip("Settings for the CameraMovement behavior.")]
        public CameraMovementSettings settings;
        #endregion

        #region Class variables
        private Vector3 _desiredCameraPosition;
        private int _screenWidth;
        private int _screenHeight;
        #endregion

        private void Start() {
            _desiredCameraPosition = transform.position;
            _screenWidth = Screen.width;
            _screenHeight = Screen.height;
        }

        private void Update() {
            // Get updates made to the desired movement of the camera.
            SetDesiredCameraPosition();
        }

        private void FixedUpdate() {
            // Check if the current camera position is not at the desired camera position.
            if (!transform.position.Equals(_desiredCameraPosition)) {
                // Move the camera towards the desired camera position.
                MoveCamera();
            }
        }

        /// <summary>
        /// Checks if the mouse position is within the boundary limit of the screen edge.
        /// </summary>
        private void SetDesiredCameraPosition() {
            // Get the current desired camera position.
            var position = _desiredCameraPosition;

            // Check if the mouse is within the boundary of the screen's right edge
            if (Input.mousePosition.x > _screenWidth - settings.boundary || Input.GetKey(InputManager.CameraInputs.MoveRight))
                position.x += settings.speed * Time.deltaTime;

            // Check if the mouse is within the boundary of the screen's left edge
            if (Input.mousePosition.x < settings.boundary || Input.GetKey(InputManager.CameraInputs.MoveLeft))
                position.x -= settings.speed * Time.deltaTime;

            // Check if the mouse is within the boundary of the screen's top edge
            if (Input.mousePosition.y > _screenHeight - settings.boundary || Input.GetKey(InputManager.CameraInputs.MoveUp))
                position.z += settings.speed * Time.deltaTime;

            // Check if the mouse is within the boundary of the screen's bottom edge
            if (Input.mousePosition.y < settings.boundary || Input.GetKey(InputManager.CameraInputs.MoveDown))
                position.z -= settings.speed * Time.deltaTime;

            // TODO: Limit camera movement.
            // Keep the desired camera position within the directional limits.
            //position = position.LimitCoordinates(settings.limits, essentials.offset.position);

            _desiredCameraPosition = position;
        }

        /// <summary>
        /// Set the camera's position to the desired position.
        /// </summary>
        private void MoveCamera() {
            transform.position = _desiredCameraPosition;
        }

        #region Validation
        private void OnValidate() {
            Validate();
        }

        /// <summary>
        /// Validate the code in the editor at compile time.
        /// </summary>
        private void Validate() {
            // References
            Assert.IsNotNull(essentials?.offset, AssertUtility.ReferenceIsNotNullErrorMessage(nameof(Transform), this));

            // Components
            Assert.IsNotNull(gameObject?.transform, AssertUtility.ComponentIsNotNullErrorMessage(nameof(Transform), gameObject));
            Assert.IsNotNull(GetComponent<UnityEngine.Camera>(), AssertUtility.ComponentIsNotNullErrorMessage(nameof(UnityEngine.Camera), gameObject));
        }
        #endregion
    }
}
