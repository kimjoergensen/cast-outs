using System;
using UnityEngine;
using UnityEngine.Assertions;
using WarclockBrawl;
using WarlockBrawl.Extensions;
using WarlockBrawl.Utility;

namespace WarlockBrawl.Camera {
    [Serializable]
    public class CameraControllerEssentials {
        [Tooltip("A game object's transform that the camera will be offset from. Set it to the camera's own transform, if you don't want any offset.")]
        public Transform Offset;
    }

    [Serializable]
    public class CameraControllerSettings {
        [Tooltip("The movement speed of the camera.")]
        public float MovementSpeed;
        [Tooltip("The amount of pixels, from the edge of the screen, the mouse needs to enter, before moving the camera.")]
        public float EdgeBoundary;
        [Tooltip("The length the camera can move from it's initial position, on each axis.")]
        public Vector3 MovementLimit;
    }

    public class CameraController : MonoBehaviour {
        #region Inspector menues
        [Tooltip("Essential components on the camera game object.")]
        public CameraControllerEssentials essentials;
        [Tooltip("Settings for the camera behavior.")]
        public CameraControllerSettings settings;
        [Tooltip("User input for camera controls.")]
        public InputManager.CameraInputs inputs;
        #endregion

        #region Class variables
        private Vector3 _desiredCameraPosition;
        private Vector3 _offset;
        private int _screenWidth;
        private int _screenHeight;
        #endregion

        /// <summary>
        /// Gets called when CameraController is initialized.
        /// </summary>
        public CameraController() {
            essentials = new CameraControllerEssentials();
            settings = new CameraControllerSettings();
            inputs = new InputManager.CameraInputs();
        }

        /// <summary>
        /// Gets called after Awake for later instantiation.
        /// </summary>
        private void Start() {
            // Instantiate essential variables.
            _screenWidth = Screen.width;
            _screenHeight = Screen.height;
            _desiredCameraPosition = transform.position;
            _offset = transform.position - essentials.Offset.transform.position;
        }

        /// <summary>
        /// Editor validation
        /// </summary>
        private void OnValidate() {
            Validate();
        }

        /// <summary>
        /// Update is called once per frame.
        /// </summary>
        private void Update() {
            SetDesiredCameraPosition();
        }

        /// <summary>
        /// FixedUpdate counts the time from last frame update to keep
        /// every update within the same interval for all users.
        /// </summary>
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
            var position = _desiredCameraPosition;

            // Check if the mouse is within the boundary of the screen's right edge
            if(Input.mousePosition.x > _screenWidth - settings.EdgeBoundary || Input.GetKey(inputs.MoveRight))
                position.x += settings.MovementSpeed * Time.deltaTime;

            // Check if the mouse is within the boundary of the screen's left edge
            if(Input.mousePosition.x < settings.EdgeBoundary || Input.GetKey(inputs.MoveLeft))
                position.x -= settings.MovementSpeed * Time.deltaTime;

            // Check if the mouse is within the boundary of the screen's top edge
            if(Input.mousePosition.y > _screenHeight - settings.EdgeBoundary || Input.GetKey(inputs.MoveUp))
                position.z += settings.MovementSpeed * Time.deltaTime;

            // Check if the mouse is within the boundary of the screen's bottom edge
            if(Input.mousePosition.y < settings.EdgeBoundary || Input.GetKey(inputs.MoveDown))
                position.z -= settings.MovementSpeed * Time.deltaTime;

            // Keep the desired camera position within the directional limits.
            position = position.LimitCoordinates(settings.MovementLimit, _offset);

            _desiredCameraPosition = position;
        }

        /// <summary>
        /// Moves the camera from the current position towards the expected position.
        /// </summary>
        /// <param name="desiredCameraPosition">Expected position of the camera after movement.</param>
        private void MoveCamera(Vector3 desiredCameraPosition) {
            //transform.position = Vector3.SmoothDamp(transform.position, desiredCameraPosition, ref _velocity, settings.Smoothness); // Smoothed transition
            transform.position = desiredCameraPosition;
        }

        /// <summary>
        /// Validate the code in the editor at compile time.
        /// </summary>
        private void Validate() {
            // References
            Assert.IsNotNull(essentials?.Offset, AssertUtility.ReferenceIsNotNullErrorMessage(nameof(essentials.Offset), this));

            // Components
            Assert.IsNotNull(gameObject?.transform, AssertUtility.ComponentIsNotNullErrorMessage(nameof(Transform), gameObject));
            Assert.IsNotNull(GetComponent<UnityEngine.Camera>(), AssertUtility.ComponentIsNotNullErrorMessage(nameof(UnityEngine.Camera), gameObject));
            Assert.IsNotNull(GetComponent<AudioListener>(), AssertUtility.ComponentIsNotNullErrorMessage(nameof(AudioListener), gameObject));
        }
    }
}
