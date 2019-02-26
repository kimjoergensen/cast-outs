using System;
using UnityEngine;
using UnityEngine.Assertions;
using WarclockBrawl;
using WarlockBrawl.Extensions;
using WarlockBrawl.Spells;
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

    public class PlayerMotor : MonoBehaviour {
        #region Inspector menues
        [Tooltip("Essential components for the PlayerMotor script.")]
        public PlayerMotorEssentials essentials;
        [Tooltip("Settings for the PlayerMotor behavior.")]
        public PlayerMotorSettings settings;
        #endregion

        #region Class variables
        private ISpell _pendingSpell;
        #endregion

        public SpellBase spell; // TODO: Remove this public accessor and use action bar to control pending spell.

        private void Start() {
            _pendingSpell = spell;
        }

        private void Update() {
            // Check if the player has a pending spell to cast and is pressing the FIRE spell input.
            if (_pendingSpell != null && Input.GetKeyDown(InputManager.PlayerInputs.Fire)) {
                ShootSpell();
            }
        }

        /// <summary>
        /// Shoot the currently selected spell stored in <see cref="_pendingSpell"/>.
        /// </summary>
        private void ShootSpell() {
            // Get the mouse position in world space to find the direction the player is casting the spell.
            // Escape the method if no position could be found.
            if (!MousePosition.TryGetPosition(out var mousePosition)) return;

            // Turn the player towards the desired direction.
            transform.LookAt(mousePosition);

            // Try to shoot the spell.
            if (_pendingSpell.Shoot(essentials.spellSpawnLocation.position, mousePosition))
                // Remove the spell from the pending spell slot, when the spell is successfully shot.
                Debug.Log("Remove pending spell.");
            //_pendingSpell = null;
        }

        #region Validation
        private void OnValidate() => Validate();

        /// <summary>
        /// Validate the code in the editor at compile time.
        /// </summary>
        private void Validate() {
            // References
            Assert.IsNotNull(essentials?.spellSpawnLocation, AssertUtility.ReferenceIsNotNullErrorMessage(nameof(Transform), this));
        }
        #endregion
    }
}