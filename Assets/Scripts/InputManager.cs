using System;
using UnityEngine;

public class InputManager {
    [Serializable]
    public class PlayerInputs {
        [Tooltip("User input for moving the player towards the current mouse position.")]
        public KeyCode Move = KeyCode.Mouse1;
        [Tooltip("User input to fire the currently selected spell.")]
        public KeyCode Fire = KeyCode.Mouse0;
        [Tooltip("User input to stop ongoing player actions.")]
        public KeyCode Stop = KeyCode.Space;
    }
}
