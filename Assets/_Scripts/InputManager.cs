using UnityEngine;

namespace CastOuts {
    /// <summary>
    /// Holds information of all hotkeys.
    /// </summary>
    public static class InputManager {
        /// <summary>
        /// Use this class to get or set player hotkeys.
        /// </summary>
        public static class Player {
            /// <summary>
            /// Get or set the <see cref="KeyCode"/> to issue the player to move to the current mouse position.
            /// </summary>
            public static KeyCode Move = KeyCode.Mouse1;

            /// <summary>
            /// Get or set the <see cref="KeyCode"/> to issue the player to fire their pending spell.
            /// </summary>
            public static KeyCode Fire = KeyCode.Mouse0;

            /// <summary>
            /// Get or set the <see cref="KeyCode"/> to issue the player to stop all their actions.
            /// </summary>
            public static KeyCode Stop = KeyCode.Space;
        }

        /// <summary>
        /// Use this class to get or set action bar button hotkeys.
        /// </summary>
        public class ActionBarButtons {
            /// <summary>
            /// Get or set the <see cref="KeyCode"/> to activate the object in <names
            /// </summary>
            public static KeyCode ActionBarSlot1 = KeyCode.Q;
            public static KeyCode ActionBarSlot2 = KeyCode.W;
            public static KeyCode ActionBarSlot3 = KeyCode.E;
            public static KeyCode ActionBarSlot4 = KeyCode.R;
            public static KeyCode ActionBarSlot5 = KeyCode.D;
            public static KeyCode ActionBarSlot6 = KeyCode.F;
        }

        /// <summary>
        /// Use this class to get or set cameta hotkeys.
        /// </summary>
        public static class Camera {
            public static KeyCode MoveRight = KeyCode.RightArrow;
            public static KeyCode MoveLeft = KeyCode.LeftArrow;
            public static KeyCode MoveUp = KeyCode.UpArrow;
            public static KeyCode MoveDown = KeyCode.DownArrow;
        }
    }
}
