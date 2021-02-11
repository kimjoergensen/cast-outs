using CastOuts.Spells.Interfaces;
using UnityEngine;

namespace CastOuts.Spells
{
  /// <summary>Base class for all spells.</summary>
  public abstract class SpellBase : MonoBehaviour, ISpell
  {
    /// <summary>Gets or sets the name.</summary>
    /// <value>The name.</value>
    public abstract string Name { get; set; }
    /// <summary>Gets or sets the damage.</summary>
    /// <value>The damage.</value>
    public abstract float Damage { get; set; }
    /// <summary>Gets or sets the speed.</summary>
    /// <value>The speed.</value>
    public abstract float Speed { get; set; }
    /// <summary>Gets or sets the range.</summary>
    /// <value>The range.</value>
    public abstract float Range { get; set; }
    /// <summary>Gets or sets the image.</summary>
    /// <value>The image.</value>
    public abstract Sprite Image { get; set; }

    #region Class variables
    private Vector3 _spawnLocation;
    #endregion

    private void Start()
    {
      _spawnLocation = transform.position;
    }

    private void Update()
    {
      DestroyOnMaxDistance();
    }

    /// <summary>Destroy the spell when it has reached <see cref="ISpell.Range"/> distance.</summary>
    public void DestroyOnMaxDistance()
    {
      if (Vector3.Distance(_spawnLocation, transform.position) > Range)
        Destroy(gameObject);
    }

    /// <summary>Shoot the spell from the <paramref name="spawnLocation" /> towards the <paramref name="targetLocation" />.</summary>
    /// <param name="spawnLocation"><see cref="Vector3"/> object holding the position the spell will be shot from.</param>
    /// <param name="targetLocation"><see cref="Vector3"/> object holding the position the spell will be traveling towards.</param>
    /// <returns>True if the spell was instantiated, false if not.</returns>
    public abstract bool Shoot(Vector3 spawnLocation, Vector3 targetLocation);
  }
}
