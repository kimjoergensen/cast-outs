using System;
using UnityEngine;
using UnityEngine.Assertions;
using WarlockBrawl.Extensions;

namespace WarclockBrawl.Player {
    [Serializable]
    public class PlayerControllerEssentials {
        [Tooltip("The camera component a player will be viewing the game from.")]
        public Camera Camera;
    }

    public class PlayerController : MonoBehaviour {
        #region Inspector menues
        [Tooltip("Essential components on the player game object.")]
        public PlayerControllerEssentials essentials;
        [Tooltip("User input for player controls.")]
        public InputManager.PlayerInputs inputs;
        #endregion

        #region Class variables
        // Input variables.
        private bool _moveInputPressed = false;
        private bool _fireInputPressed = false;
        private bool _stopInputPressed = false;
        #endregion

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
            // Check for user inputs.
            if(Input.anyKey) {
                CheckForInput();
            }
        }

        /// <summary>
        /// FixedUpdate counts the time from last frame update to keep
        /// every update within the same interval for all users.
        /// </summary>
        private void FixedUpdate() {
            // Execute player actions
            if(_moveInputPressed)
                PlayerActionMove();

            if(_fireInputPressed)
                PlayerActionFire();

            if(_stopInputPressed)
                PlayerActionStop();
        }

        /// <summary>
        /// Set player actions based on inputs from the user.
        /// </summary>
        private void CheckForInput() {
            // Check if the MOVE key has been pressed.
            _moveInputPressed = Input.GetKeyDown(inputs.Move)
                ? true
                : false;

            // Check if the FIRE key has been pressed.
            _fireInputPressed = Input.GetKeyDown(inputs.Fire)
                ? true
                : false;

            // Check if the STOP key has been pressed.
            _stopInputPressed = Input.GetKeyDown(inputs.Stop)
                ? true
                : false;
        }

        /// <summary>
        /// Start player movement towards current mouse position.
        /// </summary>
        private void PlayerActionMove() {
            Debug.Log("I'm moving!");
        }

        /// <summary>
        /// Fire currently selected spell.
        /// </summary>
        private void PlayerActionFire() {
            Debug.Log("I'm firing a spell!");
        }

        /// <summary>
        /// Stop all player actions.
        /// </summary>
        private void PlayerActionStop() {
            Debug.Log("I'm stopping!");
        }

        /// <summary>
        /// Validate the code in the editor at compile time.
        /// </summary>
        private void Validate() {
            // References
            Assert.IsNotNull(essentials?.Camera, AssertUtility.ReferenceIsNotNullErrorMessage(nameof(essentials.Camera), this));

            // Components
            Assert.IsNotNull(gameObject?.transform, AssertUtility.ComponentIsNotNullErrorMessage(nameof(Transform), gameObject));
            Assert.IsNotNull(GetComponent<CapsuleCollider>(), AssertUtility.ComponentIsNotNullErrorMessage(nameof(CapsuleCollider), gameObject));
        }
    }
}