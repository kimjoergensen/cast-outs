namespace CastOuts.Spells
{
  using CastOuts.Spells.Interfaces;
  using System;
  using System.Collections;
  using UnityEngine;

  /// <summary>Base class for all spells.</summary>
  public abstract class SpellBase : MonoBehaviour, ISpell
  {
    [Serializable]
    protected class Essentials
    {
      [SerializeField]
      [Tooltip("Set the name of the spell.")]
      public string name;

      [SerializeField]
      [Tooltip("Set the thumbnail image of the spell.")]
      public Sprite image;

      [SerializeField]
      [Tooltip("Set the damage when the spell collides with a player or object.")]
      [Range(0, 100)]
      public float damage;

      [SerializeField]
      [Tooltip("Set the knockback force when the spell collides with a player or object.")]
      [Range(0, 1000)]
      public float force;

      [SerializeField]
      [Tooltip("Set the traveling speed of the spell.")]
      [Range(0, 2000)]
      public float speed;

      [SerializeField]
      [Tooltip("Set the maximum range of the spell. " +
               "If the spell is a projectile, it will limit the range of the spell before it is destroyed. " +
               "If the spell is a ground targeted spell it will set the maximum distance the spell can be cast.")]
      [Range(0, 50)]
      public float range;
    }

    [SerializeField]
    protected Essentials _essentials;

    private Vector3 _spawnLocation;

    public string Name => _essentials.name;
    public Sprite Image => _essentials.image;
    public float Damage { get => _essentials.damage; set => _essentials.damage = value; }
    public float Force { get => _essentials.force; set => _essentials.force = value; }
    public float Speed { get => _essentials.speed; set => _essentials.speed = value; }
    public float Range { get => _essentials.range; set => _essentials.range = value; }

    private void Start() {
      _spawnLocation = transform.position;
    }

    /// <summary>
    /// Destroy the spell after it has reached a maximum range from its initial spawn location.
    /// </summary>
    /// <param name="range">Range in units.</param>
    public IEnumerator DestroyOnMaxDistance(float range) {
      yield return new WaitUntil(() => Vector3.Distance(_spawnLocation, transform.position) > Range);
      Destroy(gameObject);
    }

    /// <summary>
    /// Destroy the spell after a delay.
    /// </summary>
    /// <param name="time">Delay in seconds.</param>
    public IEnumerator DestroyAfterDelay(float time) {
      yield return new WaitForSeconds(time);
      Destroy(gameObject);
    }

    public abstract void Shoot(Vector3 spawnLocation, Vector3 targetLocation);
  }
}
