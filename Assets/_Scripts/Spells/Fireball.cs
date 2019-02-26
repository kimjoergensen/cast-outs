using System;
using UnityEngine;

namespace WarlockBrawl.Spells {
    [Serializable]
    public class FireballEssentials {

    }

    [Serializable]
    public class FireballSettings {
        public string name;
        public float damage;
        public float speed;
        public float distance;
    }

    public class Fireball : SpellBase {
        #region Inspector menues
        [Tooltip("Essential components for the Fireball script.")]
        public FireballEssentials essentials;
        [Tooltip("Settings for the Fireball behavior.")]
        public FireballSettings settings;
        #endregion

        #region SpellBase properties
        public override string Name { get => settings.name; set => settings.name = value; }
        public override float Damage { get => settings.damage; set => settings.damage = value; }
        public override float Speed { get => settings.speed; set => settings.speed = value; }
        public override float Distance { get => settings.distance; set => settings.distance = value; }
        #endregion

        #region Class variables

        #endregion

        /// <inheritdoc />
        /// <see cref="Interfaces.ISpell"/>
        public override bool Shoot(Vector3 spawnLocation, Vector3 targetLocation) {
            // Instantiate the fireball at the spawn location, looking towards the target location.
            var fireball = Instantiate(gameObject, spawnLocation, Quaternion.identity) as GameObject;
            fireball.transform.LookAt(targetLocation);

            // Move the fireball in a straight line.
            var rigidbody = fireball.GetComponent<Rigidbody>();
            rigidbody.velocity = fireball.transform.forward * settings.speed;

            // Return spell successfully shot.
            return true;
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
