using System;
using System.Reflection;
using UnityEngine;

namespace WarclockBrawl {
    public static class InputManager {
        public static class PlayerInputs {
            public static KeyCode Move = KeyCode.Mouse1;                // Issue a player movement action.
            public static KeyCode Fire = KeyCode.Mouse0;                // Issue a player fire spell action.
            public static KeyCode Stop = KeyCode.Space;                 // Issue the player to stop all actions.
        }

        public class ActionBarHotkeys {
            public static KeyCode ActionBarSlot1 = KeyCode.Q;           // Activate object in action bar slot 1.
            public static KeyCode ActionBarSlot2 = KeyCode.W;           // Activate object in action bar slot 2.
            public static KeyCode ActionBarSlot3 = KeyCode.E;           // Activate object in action bar slot 3.
            public static KeyCode ActionBarSlot4 = KeyCode.R;           // Activate object in action bar slot 4.
            public static KeyCode ActionBarSlot5 = KeyCode.D;           // Activate object in action bar slot 5.
            public static KeyCode ActionBarSlot6 = KeyCode.F;           // Activate object in action bar slot 6.
        }

        public static class CameraInputs {
            public static KeyCode MoveRight = KeyCode.RightArrow;       // Move the camera right.
            public static KeyCode MoveLeft = KeyCode.LeftArrow;         // Move the camera left.
            public static KeyCode MoveUp = KeyCode.UpArrow;             // Move the camera up.
            public static KeyCode MoveDown = KeyCode.DownArrow;         // Move the camera down.
        }
    }
}
