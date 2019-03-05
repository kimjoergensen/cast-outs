using CastOuts.Shared.Utility;
using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace CastOuts {
    [Serializable]
    public class InputManagerEssentials {
        public KeyBindings keyBindings;
    }

    [Serializable]
    public class InputManagerSettings {

    }

    /// <summary>
    /// Replaces Unity's input manager.
    /// Used to have better control of key bindings.
    /// </summary>
    public class InputManager : Singleton<InputManager> {
        #region Inspector menus
        [Tooltip("Essential components for the InputManager script.")]
        public InputManagerEssentials essentials;
        [Tooltip("Settings for the InputManager behavior.")]
        public InputManagerSettings settings;
        #endregion

        #region Class variables

        #endregion

        /// <summary>
        /// Prevents a default instance of the <see cref="InputManager"/> class from being created.
        /// </summary>
        private InputManager() { }

        /// <summary>
        /// Returns true while the user holds down the key identified by the <see cref="Keybinding"/>.
        /// </summary>
        public bool GetKey(Keybinding hotkey) {
            return Input.GetKey(essentials.keyBindings.GetKey(hotkey));
        }

        /// <summary>
        /// Returns true during the frame the user starts pressing down the key identified by the <see cref="Keybinding"/>.
        /// </summary>
        public bool GetKeyDown(Keybinding hotkey) {
            return Input.GetKeyDown(essentials.keyBindings.GetKey(hotkey));
        }

        #region Validation
        private void OnValidate() => Validate();

        /// <summary>
        /// Validate the code in the editor at compile time.
        /// </summary>
        private void Validate() {
            // Components

            // References
            Assert.IsNotNull(essentials.keyBindings, AssertErrorMessage.NotNull<KeyBindings>(nameof(essentials.keyBindings), gameObject));
        }
        #endregion
    }
}
