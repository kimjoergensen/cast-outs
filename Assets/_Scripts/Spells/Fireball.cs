using System;
using UnityEngine;
using WarlockBrawl.Utility;

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
        private Vector3 _direction;
        private bool _isInstantiated;
        #endregion

        private void Start() {

        }

        private void FixedUpdate() {
            if (_isInstantiated && _direction != null)
                AddForce(settings.speed);
        }

        public override bool Shoot(GameObject player) {
            // Get the current player and mouse position.
            var playerPosition = player.transform.position;

            // Get the mouse position in world space. Escape method in no position could be found.
            if (!MousePosition.TryGetPosition(out var mousePosition)) return false;

            // Set Y coordinate to always be 2.
            playerPosition.y = 2;
            mousePosition.y = 2;

            // Instantiate the spell.
            var spell = Instantiate(gameObject, playerPosition, Quaternion.identity) as GameObject;
            spell.transform.LookAt(mousePosition);
            _isInstantiated = true;

            // Return spell successfully shot.
            return true;
        }

        public override Vector3 GetMousePosition() {
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

        }
        #endregion
    }
}
