using CastOuts.Shared.Utility;
using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace CastOuts.Spells {
    [Serializable]
    public class FireballEssentials {

    }

    [Serializable]
    public class FireballSettings {
        public string name;
        public float damage;
        public float speed;
        public float range;
        public Sprite image;
    }

    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(SphereCollider))]
    [RequireComponent(typeof(ParticleSystem))]
    public class Fireball : SpellBase {
        #region Inspector menues
        [Tooltip("Essential components for the Fireball script.")]
        public FireballEssentials essentials;
        [Tooltip("Settings for the Fireball behavior.")]
        public FireballSettings settings;
        #endregion

        #region SpellBase properties
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public override string Name { get => settings.name; set => settings.name = value; }

        /// <summary>
        /// Gets or sets the damage.
        /// </summary>
        public override float Damage { get => settings.damage; set => settings.damage = value; }

        /// <summary>
        /// Gets or sets the speed.
        /// </summary>
        public override float Speed { get => settings.speed; set => settings.speed = value; }

        /// <summary>
        /// Gets or sets the range.
        /// </summary>
        public override float Range { get => settings.range; set => settings.range = value; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        public override Sprite Image { get => settings.image; set => settings.image = value; }
        #endregion

        #region Class variables

        #endregion

        /// <summary>
        /// Shoot the spell from the <paramref name="spawnLocation" /> towards the <paramref name="targetLocation" />.
        /// </summary>
        /// <param name="spawnLocation"><see cref="Vector3"/> object holding the position the spell will be shot from.</param>
        /// <param name="targetLocation"><see cref="Vector3"/> object holding the position the spell will be traveling towards.</param>
        /// <returns>True if the spell was instantiated, false if not.</returns>
        public override bool Shoot(Vector3 spawnLocation, Vector3 targetLocation) {
            // Instantiate the fireball at the spawn location, looking towards the target location.
            var fireball = Instantiate(gameObject, spawnLocation, Quaternion.identity) as GameObject;
            fireball.transform.LookAt(targetLocation);

            // Set the fireballs rotation on the X axis back to zero, so it always flies horizontally.
            fireball.transform.eulerAngles = new Vector3 {
                x = 0.0f,
                y = fireball.transform.eulerAngles.y,
                z = fireball.transform.eulerAngles.z
            };

            // Move the fireball in a straight line.
            var rigidbody = fireball.GetComponent<Rigidbody>();
            rigidbody.velocity = fireball.transform.forward * settings.speed;

            // Return spell successfully shot.
            return true;
        }

        #region Validation
        private void OnValidate() => Validate();

        /// <summary>Validates this instance.</summary>
        private void Validate() {
            // Components
            Assert.IsNotNull(GetComponent<Rigidbody>(), AssertErrorMessage.NotNull<Rigidbody>(gameObject));
            Assert.IsNotNull(GetComponent<SphereCollider>(), AssertErrorMessage.NotNull<SphereCollider>(gameObject));
            Assert.IsNotNull(GetComponent<ParticleSystem>(), AssertErrorMessage.NotNull<ParticleSystem>(gameObject));

            // References
            Assert.IsTrue(settings.name.NotEmpty(), AssertErrorMessage.NotEmpty(nameof(settings.name), gameObject));
            Assert.IsTrue(settings.damage.GreaterThan(default), AssertErrorMessage.GreaterThan(nameof(settings.damage), default, gameObject));
            Assert.IsTrue(settings.speed.GreaterThan(default), AssertErrorMessage.GreaterThan(nameof(settings.speed), default, gameObject));
            Assert.IsTrue(settings.range.GreaterThan(default), AssertErrorMessage.GreaterThan(nameof(settings.range), default, gameObject));
            Assert.IsNotNull(settings.image, AssertErrorMessage.NotNull<Image>(nameof(settings.image), gameObject));
        }
        #endregion
    }
}
