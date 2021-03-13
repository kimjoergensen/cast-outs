namespace Assets.Scripts.Player
{
  using Assets.Scripts.Shared.KeyBinding;
  using Assets.Scripts.Shared.Utility;
  using Assets.Scripts.VariableReferences;
  using UnityEngine;

  [RequireComponent(typeof(PlayerMovement))]
  public class PlayerController : MonoBehaviour
  {
    [Tooltip("Set the health of the player. Use a FloatVariable to let other objects interact with the value.")]
    public FloatReference health;

    private PlayerMovement _playerMovement;

    private void Start() {
      _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update() {
      // Check if the player is pressing the MOVE input key.
      if (InputManager.Instance.GetKey(KeyBinding.PlayerMove)
          && MouseUtility.TryGetPosition(out var mousePosition, true, LayerMask.NameToLayer("Walkable")))
        _playerMovement.MoveTowards(mousePosition);
    }
  }
}