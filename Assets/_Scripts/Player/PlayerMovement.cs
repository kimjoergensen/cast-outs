using System;
using UnityEngine;
using UnityEngine.Assertions;
using WarclockBrawl;
using WarlockBrawl.Extensions;

namespace WarlockBrawl.Player {
    [Serializable]
    public class PlayerMovementEssentials {
        [Tooltip("Set the camera the user will control the player from.")]
        public UnityEngine.Camera camera;
    }

    [Serializable]
    public class PlayerMovementSettings {
        [Tooltip("Determines how fast the player moves.")]
        public float speed;
    }

    public class PlayerMovement : MonoBehaviour {
        #region Inspector menues
        [Tooltip("Essential components for the PlayerMovement script.")]
        public PlayerMovementEssentials essentials;
        [Tooltip("Settings for the PlayerMovement behavior.")]
        public PlayerMovementSettings settings;
        #endregion

        #region Class variables
        private Vector3 _targetPosition;
        private bool _isMoving;
        #endregion

        private void Update() {
            // Check if the player has pressed the MOVE input key.
            if(Input.GetKeyDown(InputManager.PlayerInputs.Move))
                // Set the targeted position the player wants to move the player to.
                SetTargetPosition();
        }

        private void FixedUpdate() {
            if(_isMoving)
                PlayerActionMove();
        }

        /// <summary>
        /// Set the desired position the player wants to move the player to.
        /// </summary>
        private void SetTargetPosition() {
            // Don't move the player if the user did not click on a ground object.
            if(!Physics.Raycast(essentials.camera.ScreenPointToRay(Input.mousePosition), out var hit, 100)) return;

            // Don't move the player if the object clicked on does not have a collider on it.
            if(!hit.transform) return;

            // Set the target position to the point in space where the player clicked.
            _targetPosition = hit.point;

            _isMoving = true;
        }

        /// <summary>
        /// Start player movement towards current mouse position.
        /// </summary>
        private void PlayerActionMove() {
            // Turn the player towards the target position and start moving the player to the location.
            transform.LookAt(_targetPosition);
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, settings.speed * Time.deltaTime);

            // Stop the player when they reach the target position.
            if(transform.position == _targetPosition)
                _isMoving = false;

            Debug.DrawLine(transform.position, _targetPosition, Color.red);
        }

        #region Validation
        private void OnValidate() {
            Validate();
        }

        /// <summary>
        /// Validate the code in the editor at compile time.
        /// </summary>
        private void Validate() {
            // Referencess
            Assert.IsNotNull(essentials?.camera, AssertUtility.ReferenceIsNotNullErrorMessage(nameof(Camera), this));

            // Components
            Assert.IsNotNull(gameObject?.transform, AssertUtility.ComponentIsNotNullErrorMessage(nameof(Transform), gameObject));
        }
        #endregion
    }
}
