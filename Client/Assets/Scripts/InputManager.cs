namespace Assets.Scripts
{
  using Assets.Scripts.Shared;
  using Assets.Scripts.Shared.KeyBinding;
  using UnityEngine;

  /// <summary>
  /// Replaces Unity's input manager.
  /// </summary>
  public class InputManager : Singleton<InputManager>
  {
    [Tooltip("Set a key binding object to store key binding settings for the user.")]
    public KeyBindings keyBindings;

    private InputManager() { }

    /// <summary>
    /// Returns true while the user holds down the key identified by keybinding.
    /// </summary>
    public bool GetKey(KeyBinding keybinding) {
      return Input.GetKey(keyBindings.GetKey(keybinding));
    }

    /// <summary>
    /// Returns true during the frame the user starts pressing the key identified by keybinding.
    /// </summary>
    public bool GetKeyDown(KeyBinding keybinding) {
      return Input.GetKeyDown(keyBindings.GetKey(keybinding));
    }

    /// <summary>
    /// Returns the KeyCode associated with the keybinding.
    /// </summary>
    public KeyCode GetHotkey(KeyBinding keybinding) {
      return keyBindings.GetKey(keybinding);
    }
  }
}
