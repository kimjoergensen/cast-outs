using CastOuts.Utility;
using UnityEngine;

namespace CastOuts {
    public class GameManagerEssentials {

    }

    public class GameManagerSettings {

    }

    public class GameManager : Singleton<GameManager> {
        #region Inspector menues
        [Tooltip("Essential components for the GameManager script.")]
        public GameManagerEssentials essentials;
        [Tooltip("Settings for the GameManager behavior.")]
        public GameManagerSettings settings;
        #endregion

        #region Class variables

        #endregion

        private void Awake() {
            InitGame();
        }

        /// <summary>
        /// Inialize a game.
        /// </summary>
        private void InitGame() {

        }

        #region Validation
        private void OnValidate() => Validate();

        /// <summary>
        /// Validate the code in the editor at compile time.
        /// </summary>
        private void Validate() {

        }
        #endregion
    }
}
