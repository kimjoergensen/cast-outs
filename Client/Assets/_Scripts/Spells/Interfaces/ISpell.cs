using UnityEngine;

namespace CastOuts.Spells.Interfaces {

    /// <summary>Interface for all spells. This makes sure all spells always have the minimum required properties and methods.</summary>
    public interface ISpell {
        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        string Name { get; set; }
        /// <summary>Gets or sets the damage.</summary>
        /// <value>The damage.</value>
        float Damage { get; set; }
        /// <summary>Gets or sets the speed.</summary>
        /// <value>The speed.</value>
        float Speed { get; set; }
        /// <summary>Gets or sets the range.</summary>
        /// <value>The range.</value>
        float Range { get; set; }
        /// <summary>Gets or sets the image.</summary>
        /// <value>The image.</value>
        Sprite Image { get; set; }

        /// <summary>Shoot the spell from the <paramref name="spawnLocation" /> towards the <paramref name="targetLocation" />.</summary>
        /// <param name="spawnLocation"><see cref="Vector3"/> object holding the position the spell will be shot from.</param>
        /// <param name="targetLocation"><see cref="Vector3"/> object holding the position the spell will be traveling towards.</param>
        /// <returns>True if the spell was instantiated, false if not.</returns>
        bool Shoot(Vector3 spawnLocation, Vector3 targetLocation);

        /// <summary>Destroy the spell when it has reached <see cref="ISpell.Range"/> distance.</summary>
        void DestroyOnMaxDistance();
    }
}
