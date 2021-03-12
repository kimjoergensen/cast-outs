namespace Assets.Scripts.Shared.KeyBinding
{
  using UnityEngine;

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

  [CreateAssetMenu(fileName = "KeyBindings", menuName = "Key Bindings/Key Bindings", order = 1)]
  public class KeyBindings : ScriptableObject
  {
    [Tooltip("Set the key bindings for the action bar buttons.")]
    public ActionBarKeyBindings actionBarKeyBindings;
    [Tooltip("Set the key bindings to control the camera.")]
    public CameraKeyBindings cameraKeyBindings;
    [Tooltip("Set the key bindings to control the player.")]
    public PlayerKeyBindings playerKeyBindings;

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
