namespace Assets.Scripts.Shared.KeyBinding
{
  using UnityEngine;

  [CreateAssetMenu(fileName = "PlayerKeyBindings", menuName = "Key Bindings/Player Key Bindings", order = 2)]
  public class PlayerKeyBindings : ScriptableObject
  {
    [Tooltip("Set the input to move the player.")]
    public KeyCode Move = KeyCode.Mouse1;
    [Tooltip("Set the input to fire a spell.")]
    public KeyCode Fire = KeyCode.Mouse0;
    [Tooltip("Set the input to stop the player from all current actions.")]
    public KeyCode Stop = KeyCode.S;
  }
}