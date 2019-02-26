using UnityEngine;

namespace WarlockBrawl.Spells.Interfaces {
    public interface ISpell {
        bool Shoot(GameObject player);
        Vector3 GetMousePosition();
    }
}
