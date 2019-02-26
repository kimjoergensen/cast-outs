using System;
using UnityEngine;
using WarlockBrawl.Spells.Interfaces;

namespace WarlockBrawl.Spells {
    public abstract class SpellBase : MonoBehaviour, ISpell {
        public abstract string Name { get; set; }
        public abstract float Damage { get; set; }
        public abstract float Speed { get; set; }
        public abstract float Range { get; set; }

        #region Class variables
        private Vector3 _spawnLocation;
        #endregion

        private void Start() {
            _spawnLocation = transform.position;
        }

        private void Update() {
            DestroyOnMaxDistance();
        }

        /// <inheritdoc />
        /// <see cref="ISpell"/>
        public void DestroyOnMaxDistance() {
            if (Vector3.Distance(_spawnLocation, transform.position) > Range)
                Destroy(gameObject);
        }

        /// <inheritdoc />
        /// <see cref="ISpell"/>
        public abstract bool Shoot(Vector3 spawnLocation, Vector3 targetLocation);
    }
}
