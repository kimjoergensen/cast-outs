using System;
using UnityEngine;
using UnityEngine.Assertions;
using WarlockBrawl.Extensions;
using WarlockBrawl.Spells.Interfaces;

namespace WarlockBrawl.Spells {
    [Serializable]
    public class SpellEssentials {
        [Tooltip("Set the particle system used for the spell.")]
        public ParticleSystem particle;
    }

    [Serializable]
    public class SpellSettings {
        [Tooltip("Name of the spell.")]
        public string name;
        [Tooltip("Amount of damage applied to target when hit by the spell.")]
        public float damage;
        [Tooltip("How fast the spell travels.")]
        public float speed;
    }

    public class Spell : MonoBehaviour, ISpell {
        #region Inspector menues
        [Tooltip("Essential components for the Spell script.")]
        public SpellEssentials essentials;
        [Tooltip("Settings for the Spell behavior.")]
        public SpellSettings settings;
        #endregion

        #region Class variables

        #endregion

        /// <summary>
        /// Start the <see cref="ParticleSystem"/> set on the spell script and shoot it in the direction of the mouse.
        /// </summary>
        /// <param name="player">The player issuing the spell to shoot.</param>
        public void Shoot(GameObject player) {
            // Get the current player and mouse position
            var playerPosition = player.transform.position;
            var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            mousePosition = UnityEngine.Camera.main.ScreenToWorldPoint(mousePosition);

            // Set Y coordinate to always be 2.
            playerPosition.y = 2;
            mousePosition.y = 2;

            // Instantiate the spell.
            var spell = Instantiate(gameObject, playerPosition, Quaternion.identity) as GameObject;
            spell.transform.LookAt(mousePosition);

            // Shoot the spell in the direction of the mouse position.
            transform.position = Vector3.MoveTowards(transform.position, mousePosition, settings.speed * Time.deltaTime);
            Debug.DrawLine(transform.position, mousePosition, Color.red);
        }

        #region Validation
        private void OnValidate() {
            Validate();
        }

        /// <summary>
        /// Validate the code in the editor at compile time.
        /// </summary>
        private void Validate() {
            // References
            Assert.IsNotNull(essentials?.particle, AssertUtility.ReferenceIsNotNullErrorMessage(nameof(essentials.particle), this));

            // Objects
            Assert.IsNotNull(GetComponent<ParticleSystem>(), AssertUtility.ComponentIsNotNullErrorMessage(nameof(ParticleSystem), gameObject));
        }
        #endregion
    }
}
