namespace CastOuts.Spells.Interfaces
{
  using System.Collections;
  using UnityEngine;

  /// <summary>
  /// Interface for all spells. This makes sure all spells always have the minimum required methods.
  /// </summary>
  public interface ISpell
  {
    public string Name { get; }
    public Sprite Image { get; }
    public float Damage { get; set; }
    public float Force { get; set; }
    public float Speed { get; set; }
    public float Range { get; set; }

    IEnumerator DestroyOnMaxDistance(float range);
    IEnumerator DestroyAfterDelay(float time);
    void Shoot(Vector3 spawnLocation, Vector3 targetLocation);
  }
}
