using System;
using UnityEngine;

namespace WarclockBrawl {
    public class InputManager {
        [Serializable]
        public class PlayerInputs {
            [Tooltip("Input for moving the player towards the current mouse position.")]
            public KeyCode Move = KeyCode.Mouse1;
            [Tooltip("Input to fire the currently selected spell.")]
            public KeyCode Fire = KeyCode.Mouse0;
            [Tooltip("Input to stop ongoing player actions.")]
            public KeyCode Stop = KeyCode.Space;
        }

        [Serializable]
        public class CameraInputs {
            [Tooltip("Input for panning the camera right.")]
            public KeyCode MoveRight = KeyCode.RightArrow;
            [Tooltip("Input for panning the camera left.")]
            public KeyCode MoveLeft = KeyCode.LeftArrow;
            [Tooltip("Input for panning the camera up.")]
            public KeyCode MoveUp = KeyCode.UpArrow;
            [Tooltip("Input for panning the camera down.")]
            public KeyCode MoveDown = KeyCode.DownArrow;
        }
    }
}
