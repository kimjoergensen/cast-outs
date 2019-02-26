using System;
using UnityEngine;
using WarlockBrawl.Spells.Interfaces;

namespace WarlockBrawl.Spells {
    public abstract class SpellBase : MonoBehaviour, ISpell {
        public abstract string Name { get; set; }
        public abstract float Damage { get; set; }
        public abstract float Speed { get; set; }
        public abstract float Distance { get; set; }

        #region Class variables
        private Rigidbody _rigidbody;
        #endregion

        /// <inheritdoc />
        /// <see cref="ISpell"/>
        public void DestroyOnMaxDistance() {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <see cref="ISpell"/>
        public abstract bool Shoot(Vector3 spawnLocation, Vector3 targetLocation);
    }
}
