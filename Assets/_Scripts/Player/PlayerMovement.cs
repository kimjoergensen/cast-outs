using System;
using UnityEngine;
using UnityEngine.Assertions;
using WarclockBrawl;
using WarlockBrawl.Extensions;
using WarlockBrawl.Utility;

namespace WarlockBrawl.Player {
    [Serializable]
    public class PlayerMovementEssentials {

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
            if (Input.GetKeyDown(InputManager.PlayerInputs.Move))
                // Set the targeted position the player wants to move the player to.
                SetTargetPosition();
        }

        private void FixedUpdate() {
            if (_isMoving)
                PlayerActionMove();
        }

        /// <summary>
        /// Set the desired position the player wants to move the player to.
        /// </summary>
        private void SetTargetPosition() {
            // Check if the current position of the mouse hits a walkable area.
            // Store the position hit in a variable.
            if (!MouseUtility.TryGetPosition(out var position, true, LayerMask.NameToLayer("Walkable"))) return;

            // Set the target position to the point in space where the player clicked.
            _targetPosition = position;

            // Set is moving to true, to tell the fixed update method, the player is still moving.
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
            if (transform.position == _targetPosition)
                _isMoving = false;

            Debug.DrawLine(transform.position, _targetPosition, Color.red);
        }

        #region Validation
        private void OnValidate() => Validate();

        /// <summary>
        /// Validate the code in the editor at compile time.
        /// </summary>
        private void Validate() {
            // Components
            Assert.IsNotNull(gameObject?.transform, AssertUtility.ComponentNullErrorMessage(nameof(Transform), gameObject));
        }
        #endregion
    }
}
