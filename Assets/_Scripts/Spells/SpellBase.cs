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

        private void Start() {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public abstract bool Shoot(GameObject player);

        public abstract Vector3 GetMousePosition();

        public void AddForce(float speed) {
            _rigidbody.AddForce(transform.forward * speed);
        }
    }
}
