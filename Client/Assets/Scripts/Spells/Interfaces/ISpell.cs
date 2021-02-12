using System.Collections;
using UnityEngine;

namespace CastOuts.Spells.Interfaces
{
  /// <summary>Interface for all spells. This makes sure all spells always have the minimum required properties and methods.</summary>
  public interface ISpell
  {
    string Name { get; set; }
    float Damage { get; set; }
    float Speed { get; set; }
    float Range { get; set; }
    Sprite Image { get; set; }

    IEnumerator DestroyOnMaxDistance(float range);
    IEnumerator DestroyAfterDelay(float time);
    void Shoot(Vector3 spawnLocation, Vector3 targetLocation);
  }
}
