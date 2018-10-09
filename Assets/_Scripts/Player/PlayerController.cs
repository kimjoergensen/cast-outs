using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;
using WarlockBrawl.Extensions;

namespace WarclockBrawl.Player {
    [Serializable]
    public class PlayerControllerEssentials {
        [Tooltip("The camera component a player will be viewing the game from.")]
        public Camera Camera;
        [Tooltip("The nav mesh agent component on the player object this script is applied to.")]
        public NavMeshAgent Agent;
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
        /// Gets called when PlayerController is initialized.
        /// </summary>
        public PlayerController() {
            essentials = new PlayerControllerEssentials();
            inputs = new InputManager.PlayerInputs();
        }

        /// <summary>
        /// Editor validation
        /// </summary>
        private void OnValidate() {
            Debug.Log($"Validating {this} script.");
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
            if(Input.GetKey(inputs.Move))
                _moveInputPressed = true;
            else
                _moveInputPressed = false;

            // Check if the FIRE key has been pressed.
            if(Input.GetKeyDown(inputs.Fire))
                _fireInputPressed = true;
            else
                _fireInputPressed = false;

            // Check if the STOP key has been pressed.
            if(Input.GetKeyDown(inputs.Stop))
                _stopInputPressed = true;
            else
                _stopInputPressed = false;
        }

        /// <summary>
        /// Start player movement towards current mouse position.
        /// </summary>
        private void PlayerActionMove() {
            // Fire a ray from the camera towards the current mouse position;
            Ray ray = essentials.Camera.ScreenPointToRay(Input.mousePosition);
            // Stores the world's X and Y coordinates where the raycast hit.
            RaycastHit hit;
            // Check if the raycast didn't hit any game objects.
            if(!Physics.Raycast(ray, out hit)) {
                // Escape function.
                return;
            }

            // Check if the game object hit doesn't have collider on it.
            if(!hit.transform) {
                // Escape function.
                return;
            }

            // Start moving the player to the point in world where the raycast hit an object.
            essentials.Agent.SetDestination(hit.point);
        }

        /// <summary>
        /// Fire currently selected spell.
        /// </summary>
        private void PlayerActionFire() {

        }

        /// <summary>
        /// Stop all player actions.
        /// </summary>
        private void PlayerActionStop() {

        }

        /// <summary>
        /// Validate the code in the editor at compile time.
        /// </summary>
        private void Validate() {
            // References
            Assert.IsNotNull(essentials?.Agent, AssertUtility.ReferenceIsNotNullErrorMessage(nameof(essentials.Agent), this));
            Assert.IsNotNull(essentials?.Camera, AssertUtility.ReferenceIsNotNullErrorMessage(nameof(essentials.Camera), this));

            // Components
            Assert.IsNotNull(gameObject?.transform, AssertUtility.ComponentIsNotNullErrorMessage(nameof(Transform), gameObject));
            Assert.IsNotNull(GetComponent<NavMeshAgent>(), AssertUtility.ComponentIsNotNullErrorMessage(nameof(NavMeshAgent), gameObject));
            Assert.IsNotNull(GetComponent<BoxCollider>(), AssertUtility.ComponentIsNotNullErrorMessage(nameof(BoxCollider), gameObject));
        }
    }
}