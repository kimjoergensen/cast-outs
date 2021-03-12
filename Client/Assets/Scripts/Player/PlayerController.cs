namespace Assets.Scripts.Player
{
  using Assets.Scripts.ActionBar;
  using Assets.Scripts.Shared.KeyBinding;
  using Assets.Scripts.Shared.Utility;
  using Assets.Scripts.Spells.Bases;
  using Assets.Scripts.VariableReferences;
  using System;
  using System.Collections;
  using UnityEngine;

  [RequireComponent(typeof(PlayerMovement))]
  public class PlayerController : MonoBehaviour, IObserver<ActionBarButtonInfo>
  {
    [Serializable]
    private class SpellSpawnLocation
    {
      [Tooltip("Set a local transform reference.")]
      public Transform localReference;

      [Tooltip("Set a public variable reference for other scripts to reference.")]
      public TransformReference publicReference;
    }

    [SerializeField]
    [Tooltip("Set the spawn location of all spells cast by the player.")]
    private SpellSpawnLocation spellSpawnLocation;

    [Tooltip("Set the health of the player. Use a FloatVariable to let other objects interact with the value.")]
    public FloatReference health;

    private PlayerMovement _playerMovement;
    private Spell _pendingSpell;
    private IDisposable _cancellation;
    private Vector3 _mousePosition;

    private void Start() {
      _playerMovement = GetComponent<PlayerMovement>();
      _cancellation = ActionBar.Instance.Subscribe(this);
    }

    private void OnDestroy() {
      Unsubscribe();
    }

    private void Update() {
      // Update spellSpawnLocation reference values.
      UpdateSpellSpawn(spellSpawnLocation.localReference, spellSpawnLocation.publicReference.Value);

      // Check if the player has a pending spell to cast and is pressing the FIRE spell input.
      if (_pendingSpell != null
          && InputManager.Instance.GetKeyDown(KeyBinding.PlayerFire)
          && MouseUtility.TryGetPosition(out _mousePosition, true))
        StartCoroutine(ShootSpell(_mousePosition));

      // Check if the player is pressing the MOVE input key.
      if (InputManager.Instance.GetKey(KeyBinding.PlayerMove)
          && MouseUtility.TryGetPosition(out _mousePosition, true, LayerMask.NameToLayer("Walkable")))
        _playerMovement.MoveTowards(_mousePosition);
    }

    private IEnumerator ShootSpell(Vector3 target) {
      if (_pendingSpell is null) yield break;

      // Turn the player towards the target.
      yield return _playerMovement.LookAt(target);

      // Shoot the spell in the direction of the target.
      _pendingSpell.Activate(target);

      // Remove the spell from the pending spell slot.
      _pendingSpell = null;
    }

    private void UpdateSpellSpawn(Transform local, TransformOverride reference) {
      reference.position = local.position;
      reference.rotation = local.rotation;
      spellSpawnLocation.publicReference.Value = reference;
    }

    private void Unsubscribe() {
      _cancellation.Dispose();
    }

    public void OnCompleted() {
      throw new NotImplementedException();
    }

    public void OnError(Exception error) {
      throw new NotImplementedException();
    }

    public void OnNext(ActionBarButtonInfo info) {
      // Do nothing if no spell was passed.
      if (info.Spell == null) return;

      // Set pending spell to the spell passed in info.
      _pendingSpell = info.Spell;
    }
  }
}