using System;
using UnityEngine;
using UnityEngine.Assertions;
using WarclockBrawl.Player;
using WarlockBrawl.Extensions;
using WarlockBrawl.Utility;

namespace WarlockBrawl.Player {
    [Serializable]
    public class CharacterMovementControllerEssentials {
        [Tooltip("Set the player motor this script controls.")]
        public CharacterMotor motor;
    }

    [Serializable]
    public class CharacterMovementControllerSettings {
        [Tooltip("Determines how fast the player walks.")]
        public float speed;
    }

    public class CharacterMovementController : MonoBehaviour
    {
        #region Inspector menues
        [Tooltip("Essential components for the player movement script.")]
        public CharacterMovementControllerEssentials essentials;
        [Tooltip("Settings for the player movement script.")]
        public CharacterMovementControllerSettings settings;
        #endregion

        #region Class variables
        private UnityEngine.Camera _camera;
        private Vector3 _targetPosition;
        private bool _isMoving;
        #endregion

        private void OnValidate() {
            Validate();
        }

        private void Start() {
            _camera.FindCamera(essentials.motor.essentials.camera);
        }

        private void Update() {
            // Check if the player has pressed the MOVE input key.
            if(Input.GetKeyDown(essentials.motor.inputs.Move))
                // Set the targeted position the player wants to move the character to.
                SetTargetPosition();
        }

        private void FixedUpdate() {
            if(_isMoving)
                PlayerActionMove();
        }

        /// <summary>
        /// Set the desired position the player wants to move the character to.
        /// </summary>
        private void SetTargetPosition() {
            // Don't move the player if the user did not click on a ground object.
            if(!Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out var hit, 100)) return;

            // Don't move the player if the object clicked on does not have a collider on it.
            if(!hit.transform) return;

            // Set the target position to the point in space where the player clicked.
            _targetPosition = hit.point;

            _isMoving = true;
        }

        /// <summary>
        /// Start character movement towards current mouse position.
        /// </summary>
        private void PlayerActionMove() {
            // Turn the player towards the target position and start moving the player to the location.
            transform.LookAt(_targetPosition);
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, settings.speed * Time.deltaTime);

            // Stop the character when they reach the target position.
            if(transform.position == _targetPosition)
                _isMoving = false;

            Debug.DrawLine(transform.position, _targetPosition, Color.red);
        }

        private void Validate() {
            // Components
            Assert.IsNotNull(GetComponent<CharacterMotor>(), AssertUtility.ComponentIsNotNullErrorMessage(nameof(CharacterMotor), gameObject));
        }
    }
}
