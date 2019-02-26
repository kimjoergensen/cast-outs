using UnityEngine;

namespace WarlockBrawl.Spells.Interfaces {
    public interface ISpell {
        /// <summary>
        /// Shoot the spell from the <paramref name="spawnLocation"/> towards the <paramref name="targetLocation"/>.
        /// </summary>
        /// <param name="spawnLocation"><see cref="Vector3"/> object holding the position the spell will be shot from.</param>
        /// <param name="targetLocation"><see cref="Vector3"/> object holding the position the spell will be traveling towards.</param>
        /// <returns>True if the spell was instantiated, false if not.</returns>
        bool Shoot(Vector3 spawnLocation, Vector3 targetLocation);

        /// <summary>
        /// Destroy the spell when it has reached it's max distance.
        /// </summary>
        void DestroyOnMaxDistance();
    }
}
