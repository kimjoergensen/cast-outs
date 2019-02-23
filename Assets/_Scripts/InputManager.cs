using System;
using UnityEngine;

namespace WarclockBrawl {
    [Serializable]
    public static class InputManager {
        public static class PlayerInputs {
            public static KeyCode Move = KeyCode.Mouse1;            // Issue a player movement action.
            public static KeyCode Fire = KeyCode.Mouse0;            // Issue a player fire spell action.
            public static KeyCode Stop = KeyCode.Space;             // Issue the player to stop all actions.

            // Action bar hotkeys
            public static KeyCode ActionBarSlot1 = KeyCode.Q;       // Activate object in action bar slot 1.
        }

        public static class CameraInputs {
            public static KeyCode MoveRight = KeyCode.RightArrow;   // Move the camera right.
            public static KeyCode MoveLeft = KeyCode.LeftArrow;     // Move the camera left.
            public static KeyCode MoveUp = KeyCode.UpArrow;         // Move the camera up.
            public static KeyCode MoveDown = KeyCode.DownArrow;     // Move the camera down.
        }
    }
}
