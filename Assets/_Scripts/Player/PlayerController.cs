using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;
using WarlockBrawl.Utility;

namespace WarclockBrawl.Player {
    [Serializable]
    public class PlayerControllerEssentials {
        public Camera camera;
        public NavMeshAgent agent;
    }

    [Serializable]
    public class PlayerControllerSettings {

    }

    public class PlayerController : MonoBehaviour {
        #region Inspector menues
        [Tooltip("Set essential components on the player game object.")]
        public PlayerControllerEssentials essentials;
        [Tooltip("Set player game settings.")]
        public PlayerControllerSettings settings;
        [Tooltip("Set user input for player controls.")]
        public InputManager.PlayerInputs inputs;
        #endregion

        #region Private variables
        // Input variables.
        private bool _moveInputPressed = false;
        private bool _fireInputPressed = false;
        private bool _stopInputPressed = false;
        #endregion

        /// <summary>
        /// Constructor for initializing inspector menu class variables
        /// </summary>
        public PlayerController() {
            essentials = new PlayerControllerEssentials();
            settings = new PlayerControllerSettings();
            inputs = new InputManager.PlayerInputs();
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
            if(_moveInputPressed) {
                PlayerActionMove();
                _moveInputPressed = false;
            }

            if(_fireInputPressed) {
                PlayerActionFire();
                _fireInputPressed = false;
            }

            if(_stopInputPressed) {
                PlayerActionStop();
                _stopInputPressed = false;
            }
        }

        /// <summary>
        /// Set player actions based on inputs from the user.
        /// </summary>
        private void CheckForInput() {
            // Check if the MOVE key has been pressed.
            if(Input.GetKey(inputs.Move)) {
                _moveInputPressed = true;
            }

            // Check if the FIRE key has been pressed.
            if(Input.GetKeyDown(inputs.Fire)) {
                _fireInputPressed = true;
            }

            // Check if the STOP key has been pressed.
            if(Input.GetKeyDown(inputs.Stop)) {
                _stopInputPressed = true;
            }
        }

        /// <summary>
        /// Start player movement towards current mouse position.
        /// </summary>
        private void PlayerActionMove() {
            // Fire a ray from the camera towards the current mouse position;
            Ray ray = essentials.camera.ScreenPointToRay(Input.mousePosition);
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
            essentials.agent.SetDestination(hit.point);
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
            Assert.AreEqual(essentials.agent.GetType(), typeof(NavMeshAgent), AssertUtility.WrongTypeOrNullErrorMessage("Essentials.Agent", essentials.agent, gameObject));
            Assert.AreEqual(essentials.camera.GetType(), typeof(Camera), AssertUtility.WrongTypeOrNullErrorMessage("Essentials.Camera", essentials.camera, gameObject));
        }
    }
}