using System;
using System.Collections;
using CastOuts.Controls;
using CastOuts.Shared.DataTransferObjects;
using CastOuts.Shared.Utility;
using CastOuts.Spells.Interfaces;
using UnityEngine;
using UnityEngine.Assertions;

namespace CastOuts.Player
{
  [Serializable]
  public class PlayerControllerEssentials
  {
    [Tooltip("Set the spawn location of all spells cast by the player.")]
    public Transform spellSpawnLocation;
  }

  [Serializable]
  public class PlayerControllerSettings
  {

  }

  [RequireComponent(typeof(PlayerMovement))]
  public class PlayerController : MonoBehaviour, IObserver<ActionBarButtonInfo>
  {
    [Tooltip("Essential components for the PlayerController script.")]
    public PlayerControllerEssentials essentials;
    [Tooltip("Settings for the PlayerController behavior.")]
    public PlayerControllerSettings settings;

    private PlayerMovement _playerMovement;
    private ISpell _pendingSpell;
    private IDisposable _cancellation;
    private Vector3 _mousePosition;

    private void Start()
    {
      _playerMovement = GetComponent<PlayerMovement>();
      Subscribe(ActionBar.Instance);
    }

    private void OnDestroy()
    {
      Unsubscribe();
    }

    private void Update()
    {
      // Check if the player has a pending spell to cast and is pressing the FIRE spell input.
      if (_pendingSpell != null
      && InputManager.Instance.GetKeyDown(Keybinding.PlayerFire)
      && MouseUtility.TryGetPosition(out _mousePosition, true))
        StartCoroutine(ShootSpell(_mousePosition));

      // Check if the player is pressing the MOVE input key.
      if (InputManager.Instance.GetKey(Keybinding.PlayerMove)
      && MouseUtility.TryGetPosition(out _mousePosition, true, LayerMask.NameToLayer("Walkable")))
        _playerMovement.MoveTowards(_mousePosition);
    }

    private IEnumerator ShootSpell(Vector3 position)
    {
      // Turn the player towards the position.
      yield return _playerMovement.LookAt(position);

      // Shoot the spell in the direction of the position.
      _pendingSpell.Shoot(essentials.spellSpawnLocation.position, position);

      // Remove the spell from the pending spell slot.
      _pendingSpell = null;
    }

    private void Subscribe(ActionBar provider)
    {
      _cancellation = provider.Subscribe(this);
    }

    private void Unsubscribe()
    {
      _cancellation.Dispose();
    }

    public void OnCompleted()
    {
      throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
      throw new NotImplementedException();
    }

    public void OnNext(ActionBarButtonInfo info)
    {
      // Do nothing if no spell was passed.
      if (info.Spell == null) return;

      // Set pending spell to the spell passed in info.
      _pendingSpell = info.Spell;
    }

    private void OnValidate() => Validate();
    private void Validate()
    {
      Assert.IsNotNull(essentials.spellSpawnLocation, AssertErrorMessage.NotNull<Transform>(nameof(essentials.spellSpawnLocation), gameObject));
    }
  }
}