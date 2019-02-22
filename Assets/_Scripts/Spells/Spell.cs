using System;
using System.Collections.Generic;
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
    }

    public class Spell : MonoBehaviour, ISpell {
        #region Inspector menues
        [Tooltip("Essential components for the Spell script.")]
        public SpellEssentials essentials;
        [Tooltip("Settings for the Spell behavior.")]
        public SpellSettings settings;
        #endregion

        #region Class variables
        private List<ParticleCollisionEvent> _collisionEvents;
        #endregion

        private void Start() {
            _collisionEvents = new List<ParticleCollisionEvent>();
        }

        private void OnParticleCollision(GameObject other) {
            // Get rigid body on hit game object.
            var rigidBody = other.GetComponent<Rigidbody>();

            // Do not apply collision events if the hit game object does not have a rigid body.
            if(rigidBody == null) return;

            // Get the number of collision events.
            int eventCount = essentials.particle.GetCollisionEvents(other, _collisionEvents);

            // Itterate each collision event.
            for(var i = 0; i < eventCount; i++) {
                var force = _collisionEvents[i].velocity;

                // Add pushback force to hit game object.
                rigidBody.AddForce(force);
            }
        }

        public void Shoot() {
            throw new NotImplementedException();
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
