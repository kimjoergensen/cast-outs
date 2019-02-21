using System;
using UnityEngine;
using UnityEngine.Assertions;
using WarlockBrawl.Extensions;

namespace WarclockBrawl.Player {
    [Serializable]
    public class CharacterMotorEssentials {
        [Tooltip("Set the camera the player will control the character from.")]
        public Camera camera;
    }

    [Serializable]
    public class CharacterMotorSettings {

    }

    public class CharacterMotor : MonoBehaviour {
        #region Inspector menues
        [Tooltip("Essential components on the player game object.")]
        public CharacterMotorEssentials essentials;
        [Tooltip("Settings for the player behavior.")]
        public CharacterMotorSettings settings;
        [Tooltip("User input for player controls.")]
        public InputManager.PlayerInputs inputs;
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
            // Components
            Assert.IsNotNull(gameObject?.transform, AssertUtility.ComponentIsNotNullErrorMessage(nameof(Transform), gameObject));
            Assert.IsNotNull(GetComponent<CapsuleCollider>(), AssertUtility.ComponentIsNotNullErrorMessage(nameof(CapsuleCollider), gameObject));
        }
    }
}