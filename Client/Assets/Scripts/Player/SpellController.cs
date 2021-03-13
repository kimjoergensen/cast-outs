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
  public class SpellController : MonoBehaviour, IObserver<ActionBarButtonInfo>
  {
    [Serializable]
    private class SpellSpawnLocation
    {
      [Tooltip("Set a local transform reference.")]
      public Transform localReference;

      [Tooltip("Set a public variable reference for the spells location.")]
      public Vector3Reference spawnLocationReference;

      [Tooltip("Set the public variable reference for the spells rotation.")]
      public QuaternionReference spawnRotationReference;
    }

    [SerializeField]
    [Tooltip("Set the spawn location for all spell cast relative to the players position.")]
    private SpellSpawnLocation spellSpawnLocation;

    private PlayerMovement _playerMovement;
    private Spell _pendingSpell;
    private IDisposable _cancellation;

    private void Start() {
      _playerMovement = GetComponent<PlayerMovement>();
      _cancellation = ActionBar.Instance.Subscribe(this);
    }

    private void Update() {
      // Update spellSpawnLocation reference values.
      UpdateSpellSpawn(spellSpawnLocation.localReference,
        spellSpawnLocation.spawnLocationReference, spellSpawnLocation.spawnRotationReference);

      // Check if the player has a pending spell to cast and is pressing the FIRE spell input.
      if (_pendingSpell is Spell
          && InputManager.Instance.GetKeyDown(KeyBinding.PlayerFire)
          && MouseUtility.TryGetPosition(out var mousePosition, true))
        StartCoroutine(ShootSpell(mousePosition));
    }

    private void OnDestroy() {
      _cancellation.Dispose();
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

    private void UpdateSpellSpawn(Transform reference, Vector3Reference location, QuaternionReference rotation) {
      location.Value = reference.position;
      rotation.Value = reference.rotation;
    }

    //private void UpdateSpellSpawn(Transform local, TransformOverride reference) {
    //  reference.position = local.position;
    //  reference.rotation = local.rotation;
    //  spellSpawnLocation.publicReference.Value = reference;
    //}

    public void OnCompleted() {
      _cancellation.Dispose();
    }

    public void OnError(Exception error) {
      Debug.LogException(error);
    }

    public void OnNext(ActionBarButtonInfo value) {
      // Do nothing if no spell was passed.
      if (value.Spell is null) return;

      // Set pending spell to the spell passed in info.
      _pendingSpell = value.Spell;
    }
  }
}
