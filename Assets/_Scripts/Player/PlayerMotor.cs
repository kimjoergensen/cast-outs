using System;
using UnityEngine;

namespace WarlockBrawl.Player {
    [Serializable]
    public class PlayerMotorEssentials {

    }

    [Serializable]
    public class PlayerMotorSettings {

    }

    public class PlayerMotor : MonoBehaviour {
        #region Inspector menues
        [Tooltip("Essential components on the player game object.")]
        public PlayerMotorEssentials essentials;
        [Tooltip("Settings for the player behavior.")]
        public PlayerMotorSettings settings;
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

        }
    }
}