namespace CastOuts.Shared
{
  using System;
  using UnityEngine;

  [Serializable]
  public class PlayerKeyBindings
  {
    [Tooltip("Set the input to move the player.")]
    public KeyCode Move = KeyCode.Mouse1;
    [Tooltip("Set the input to fire a spell.")]
    public KeyCode Fire = KeyCode.Mouse0;
    [Tooltip("Set the input to stop the player from all current actions.")]
    public KeyCode Stop = KeyCode.S;
  }

  [Serializable]
  public class ActionBarKeyBindings
  {
    [Tooltip("Set the hotkey for action bar button 1.")]
    public KeyCode ActionBarButton1 = KeyCode.Q;
    [Tooltip("Set the hotkey for action bar button 2.")]
    public KeyCode ActionBarButton2 = KeyCode.W;
    [Tooltip("Set the hotkey for action bar button 3.")]
    public KeyCode ActionBarButton3 = KeyCode.E;
    [Tooltip("Set the hotkey for action bar button 4.")]
    public KeyCode ActionBarButton4 = KeyCode.R;
    [Tooltip("Set the hotkey for action bar button 5.")]
    public KeyCode ActionBarButton5 = KeyCode.D;
    [Tooltip("Set the hotkey for action bar button 6.")]
    public KeyCode ActionBarButton6 = KeyCode.F;
  }

  [Serializable]
  public class CameraKeyBindings
  {
    [Tooltip("Set the hotkey to move the camera right.")]
    public KeyCode CameraMoveRight = KeyCode.RightArrow;
    [Tooltip("Set the hotkey to move the camera left.")]
    public KeyCode CamereMoveLeft = KeyCode.LeftArrow;
    [Tooltip("Set the hotkey to move the camera up.")]
    public KeyCode CameraMoveUp = KeyCode.UpArrow;
    [Tooltip("Set the hotkey to move the camera down.")]
    public KeyCode CameraMoveDown = KeyCode.DownArrow;
  }

  public enum KeyBinding
  {
    PlayerMove,
    PlayerFire,
    PlayerStop,
    ActionBarButton1,
    ActionBarButton2,
    ActionBarButton3,
    ActionBarButton4,
    ActionBarButton5,
    ActionBarButton6,
    CameraMoveRight,
    CameraMoveLeft,
    CameraMoveUp,
    CameraMoveDown
  }

  [CreateAssetMenu(fileName = "KeyBindings", menuName = "Key bindings")]
  public class KeyBindings : ScriptableObject
  {
    [Tooltip("Set the key bindings to control the player.")]
    public PlayerKeyBindings playerKeyBindings;
    [Tooltip("Set the key bindings for the action bar buttons.")]
    public ActionBarKeyBindings actionBarKeyBindings;
    [Tooltip("Set the key bindings to control the camera.")]
    public CameraKeyBindings cameraKeyBindings;

    public KeyCode GetKey(KeyBinding keybinding) {
      return keybinding switch {
        KeyBinding.PlayerMove => playerKeyBindings.Move,
        KeyBinding.PlayerFire => playerKeyBindings.Fire,
        KeyBinding.PlayerStop => playerKeyBindings.Stop,
        KeyBinding.ActionBarButton1 => actionBarKeyBindings.ActionBarButton1,
        KeyBinding.ActionBarButton2 => actionBarKeyBindings.ActionBarButton2,
        KeyBinding.ActionBarButton3 => actionBarKeyBindings.ActionBarButton3,
        KeyBinding.ActionBarButton4 => actionBarKeyBindings.ActionBarButton4,
        KeyBinding.ActionBarButton5 => actionBarKeyBindings.ActionBarButton5,
        KeyBinding.ActionBarButton6 => actionBarKeyBindings.ActionBarButton6,
        KeyBinding.CameraMoveRight => cameraKeyBindings.CameraMoveRight,
        KeyBinding.CameraMoveLeft => cameraKeyBindings.CamereMoveLeft,
        KeyBinding.CameraMoveUp => cameraKeyBindings.CameraMoveUp,
        KeyBinding.CameraMoveDown => cameraKeyBindings.CameraMoveDown,
        _ => KeyCode.None,
      };
    }
  }
}
