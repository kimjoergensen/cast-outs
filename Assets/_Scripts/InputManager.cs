using UnityEngine;

namespace CastOuts {
    /// <summary>
    /// Store all key bindings for the user.
    /// </summary>
    public static class InputManager {
        /// <summary>
        /// Player input key bindings.
        /// </summary>
        public static class Player {
            /// <summary>
            /// Gets or sets the the move key binding.
            /// </summary>
            public static KeyCode Move { get => KeyCode.Mouse1; set => Move = value; }

            /// <summary>
            /// Gets og sets the fire spell key binding.
            /// </summary>
            public static KeyCode Fire { get => KeyCode.Mouse0; set => Fire = value; }

            /// <summary>
            /// Gets og sets the stop all actions key binding.
            /// </summary>
            public static KeyCode Stop { get => KeyCode.Space; set => Stop = value; }
        }

        /// <summary>
        /// Action bar button key bindings.
        /// </summary>
        public class ActionBarButtons {
            /// <summary>
            /// Gets or sets the action bar slot 1 key binding.
            /// </summary>
            public static KeyCode ActionBarSlot1 { get => KeyCode.Q; set => ActionBarSlot1 = value; }

            /// <summary>
            /// Gets or set the action bar slot 2 key binding.
            /// </summary>
            public static KeyCode ActionBarSlot2 { get => KeyCode.W; set => ActionBarSlot2 = value; }

            /// <summary>
            /// Gets or set the action bar slot 3 key binding.
            /// </summary>
            public static KeyCode ActionBarSlot3 { get => KeyCode.E; set => ActionBarSlot3 = value; }

            /// <summary>
            /// Gets or sets the action bar slot 4 key binding.
            /// </summary>
            public static KeyCode ActionBarSlot4 { get => KeyCode.R; set => ActionBarSlot4 = value; }

            /// <summary>
            /// Gets or sets the action bar slot 5 key binding.
            /// </summary>
            public static KeyCode ActionBarSlot5 { get => KeyCode.D; set => ActionBarSlot5 = value; }

            /// <summary>
            /// Gets or sets the action bar slot 6 key binding.
            /// </summary>
            public static KeyCode ActionBarSlot6 { get => KeyCode.F; set => ActionBarSlot6 = value; }
        }

        /// <summary>
        /// Camera input key bindings.
        /// </summary>
        public static class Camera {
            /// <summary>
            /// Gets or sets the move right key binding.
            /// </summary>
            public static KeyCode MoveRight { get => KeyCode.RightArrow; set => MoveRight = value; }

            /// <summary>
            /// Gets or sets the move right left binding.
            /// </summary>
            public static KeyCode MoveLeft { get => KeyCode.LeftArrow; set => MoveLeft = value; }

            /// <summary>
            /// Gets or sets the move up key binding.
            /// </summary>
            public static KeyCode MoveUp { get => KeyCode.UpArrow; set => MoveUp = value; }

            /// <summary>
            /// Gets or sets the move down key binding.
            /// </summary>
            public static KeyCode MoveDown { get => KeyCode.DownArrow; set => MoveDown = value; }
        }
    }
}
