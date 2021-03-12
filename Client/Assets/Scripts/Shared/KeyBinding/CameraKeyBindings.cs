namespace Assets.Scripts.Shared.KeyBinding
{
  using UnityEngine;

  [CreateAssetMenu(fileName = "CameraKeyBindings", menuName = "Key Bindings/Camera Key Bindings", order = 2)]
  public class CameraKeyBindings : ScriptableObject
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
}