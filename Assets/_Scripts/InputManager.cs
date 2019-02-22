using System;
using UnityEngine;

namespace WarclockBrawl {
    [Serializable]
    public static class InputManager {
        public static class PlayerInputs {
            public static KeyCode Move = KeyCode.Mouse1;            // Input to issue a character movement action.
            public static KeyCode Fire = KeyCode.Mouse0;            // Input to issue a character fire spell action.
            public static KeyCode Stop = KeyCode.Space;             // Input to issue the character to stop all actions.
        }

        public static class CameraInputs {
            public static KeyCode MoveRight = KeyCode.RightArrow;   // Input to move the camera right.
            public static KeyCode MoveLeft = KeyCode.LeftArrow;     // Input to move the camera left.
            public static KeyCode MoveUp = KeyCode.UpArrow;         // Input to move the camera up.
            public static KeyCode MoveDown = KeyCode.DownArrow;     // Input to move the camera down.
        }
    }
}
