namespace CastOuts
{
  using CastOuts.Shared;
  using System;
  using UnityEngine;

  /// <summary>
  /// Replaces Unity's input manager.
  /// </summary>
  public class InputManager : Singleton<InputManager>
  {
    [Serializable]
    protected class Essentials
    {
      [Tooltip("Set a key binding object to store key binding settings for the user.")]
      public KeyBindings keyBindings;
    }

    [Serializable]
    protected class Settings
    {

    }

    [SerializeField]
    private Essentials essentials;
    [SerializeField]
    private Settings settings;

    private InputManager() { }

    /// <summary>
    /// Returns true while the user holds down the key identified by keybinding.
    /// </summary>
    public bool GetKey(KeyBinding keybinding) {
      return Input.GetKey(essentials.keyBindings.GetKey(keybinding));
    }

    /// <summary>
    /// Returns true during the frame the user starts pressing the key identified by keybinding.
    /// </summary>
    public bool GetKeyDown(KeyBinding keybinding) {
      return Input.GetKeyDown(essentials.keyBindings.GetKey(keybinding));
    }

    /// <summary>
    /// Returns the KeyCode associated with the keybinding.
    /// </summary>
    public KeyCode GetHotkey(KeyBinding keybinding) {
      return essentials.keyBindings.GetKey(keybinding);
    }
  }
}
