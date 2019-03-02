using System;
using UnityEngine;
using UnityEngine.Assertions;
using WarclockBrawl;
using WarlockBrawl.Controls;
using WarlockBrawl.Extensions;
using WarlockBrawl.Spells.Interfaces;
using WarlockBrawl.Utility;

namespace WarlockBrawl.Player {
    [Serializable]
    public class PlayerMotorEssentials {
        [Tooltip("Set the location the player will shoot spells from.")]
        public Transform spellSpawnLocation;
    }

    [Serializable]
    public class PlayerMotorSettings {

    }

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
            if (_pendingSpell != null && Input.GetKeyDown(InputManager.PlayerInputs.Fire))
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
        public void Subscribe(ActionBar provider) {
            _cancellation = provider.Subscribe(this);
        }

        public void Unsubscribe() {
            _cancellation.Dispose();
        }

        public void OnCompleted() {
            throw new NotImplementedException();
        }

        public void OnError(Exception error) {
            throw new NotImplementedException();
        }

        public void OnNext(ActionBarButtonInfo info) {
            // Do nothing if no spell is passed in info.
            if (info.Spell == null) return;

            // Set pending spell to the spell passed in info.
            _pendingSpell = info.Spell;
        }
        #endregion

        #region Validation
        private void OnValidate() => Validate();

        /// <summary>
        /// Validate the code in the editor at compile time.
        /// </summary>
        private void Validate() {
            Assert.IsNotNull(essentials.spellSpawnLocation, AssertErrorMessage.NotNull<Transform>(nameof(essentials.spellSpawnLocation), gameObject));
        }
        #endregion
    }
}