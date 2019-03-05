using CastOuts.Controls;
using CastOuts.Shared.DataTransferObjects;
using CastOuts.Shared.Utility;
using CastOuts.Spells.Interfaces;
using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace CastOuts.Player {
    [Serializable]
    public class PlayerMotorEssentials {
        [Tooltip("Set the location the player will shoot spells from.")]
        public Transform spellSpawnLocation;
    }

    [Serializable]
    public class PlayerMotorSettings {

    }

    /// <summary>
    /// Core script for the player game object.
    /// </summary>
    /// <remarks>Keeps track of the players health, knockback, buffs, debuffs.</remarks>
    public class PlayerMotor : MonoBehaviour, IObserver<ActionBarButtonInfo> {
        #region Inspector menues
        [Tooltip("Essential components for the PlayerMotor script.")]
        public PlayerMotorEssentials essentials;
        [Tooltip("Settings for the PlayerMotor behavior.")]
        public PlayerMotorSettings settings;
        #endregion

        #region Class variables
        private ISpell _pendingSpell;

        private IDisposable _cancellation;
        #endregion

        private void Start() {
            // Subscribe to action bar observables.
            Subscribe(ActionBar.Instance);
        }

        private void OnDestroy() {
            // Unsubscribe to action bar observables, when the player dies.
            Unsubscribe();
        }

        private void Update() {
            // Check if the player has a pending spell to cast and is pressing the FIRE spell input.
            if (_pendingSpell != null && Input.GetKeyDown(InputManager.Player.Fire))
                ShootSpell();
        }

        /// <summary>
        /// Shoot the currently selected spell stored in <see cref="_pendingSpell"/>.
        /// </summary>
        private void ShootSpell() {
            // Get the mouse position in world space to find the direction the player is casting the spell.
            // Escape the method if no position could be found.
            if (!MouseUtility.TryGetPosition(out var mousePosition)) return;

            // Turn the player towards the desired direction.
            transform.LookAt(mousePosition);

            // Try to shoot the spell.
            if (_pendingSpell.Shoot(essentials.spellSpawnLocation.position, mousePosition))
                // Remove the spell from the pending spell slot, when the spell is successfully shot.
                _pendingSpell = null;
        }

        #region IObserver methods
        /// <summary>
        /// Subscribes to the specified provider.
        /// </summary>
        /// <param name="provider">The provider.</param>
        public void Subscribe(ActionBar provider) {
            _cancellation = provider.Subscribe(this);
        }

        /// <summary>
        /// Unsubscribes this instance.
        /// </summary>
        public void Unsubscribe() {
            _cancellation.Dispose();
        }

        /// <summary>
        /// Called when [completed].
        /// </summary>
        public void OnCompleted() {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when [error].
        /// </summary>
        /// <param name="error">The error.</param>
        public void OnError(Exception error) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when [next].
        /// </summary>
        /// <param name="info">The information.</param>
        public void OnNext(ActionBarButtonInfo info) {
            // Do nothing if no spell was passed.
            if (info.Spell != null) return;

            // Set pending spell to the spell passed in info.
            _pendingSpell = info.Spell;
        }
        #endregion

        #region Validation
        private void OnValidate() => Validate();

        /// <summary>
        /// Validates this instance.
        /// </summary>
        private void Validate() {
            // Components

            // References
            Assert.IsNotNull(essentials.spellSpawnLocation, AssertErrorMessage.NotNull<Transform>(nameof(essentials.spellSpawnLocation), gameObject));
        }
        #endregion
    }
}