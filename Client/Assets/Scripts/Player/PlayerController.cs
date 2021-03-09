namespace CastOuts.Player
{
  using CastOuts.ActionBar;
  using CastOuts.Shared;
  using CastOuts.Shared.DataTransferObjects;
  using CastOuts.Shared.Utility;
  using CastOuts.Spells.Interfaces;
  using System;
  using System.Collections;
  using UnityEngine;

  [RequireComponent(typeof(PlayerMovement))]
  public class PlayerController : MonoBehaviour, IObserver<ActionBarButtonInfo>
  {
    [Serializable]
    protected class Essentials
    {
      [Tooltip("Set the spawn location of all spells cast by the player.")]
      public Transform spellSpawnLocation;
    }

    [Serializable]
    protected class Settings
    {

    }

    [SerializeField]
    private Essentials _essentials;
    [SerializeField]
    private Settings _settings;

    private PlayerMovement _playerMovement;
    private ISpell _pendingSpell;
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

    private IEnumerator ShootSpell(Vector3 position) {
      // Turn the player towards the position.
      yield return _playerMovement.LookAt(position);

      // Check for race condition when the spell has been shot,
      // but the enumeration still yields next to _playerMovement.LookAt(position).
      if (_pendingSpell is null) yield break;

      // Shoot the spell in the direction of the position.
      _pendingSpell.Shoot(_essentials.spellSpawnLocation.position, position);

      // Remove the spell from the pending spell slot.
      _pendingSpell = null;
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