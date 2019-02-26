using System;
using UnityEngine;
using WarclockBrawl;
using WarlockBrawl.Spells;
using WarlockBrawl.Spells.Interfaces;

namespace WarlockBrawl.Player {
    [Serializable]
    public class PlayerMotorEssentials {

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

        public SpellBase spell;

        private void Start() {
            _pendingSpell = spell;
        }

        private void Update() {
            if (_pendingSpell != null && Input.GetKeyDown(InputManager.PlayerInputs.Fire)) {
                if (_pendingSpell.Shoot(gameObject))
                    Debug.Log("Spell shot");
                    //_pendingSpell = null;
            }
        }

        #region Validation
        private void OnValidate() {
            Validate();
        }

        /// <summary>
        /// Validate the code in the editor at compile time.
        /// </summary>
        private void Validate() {

        }
        #endregion
    }
}