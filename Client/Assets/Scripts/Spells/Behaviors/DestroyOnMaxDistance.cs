namespace Assets.Scripts.Spells.Behaviors
{
  using Assets.Scripts.Spells.Bases;
  using System.Collections;
  using UnityEngine;

  [CreateAssetMenu(fileName = "DestroyOnMaxDistance", menuName = "Behaviors/Destroy On Max Distance")]
  public class DestroyOnMaxDistance : Behavior
  {
    [Tooltip("Set the maximum range the spell can travel from it's spawn location before being destroyed.")]
    public float range;

    private Vector3 _spawnLocation;

    /// <summary>
    /// Destroy gameObject once it has reached a distance greater than range from the initial spawn location of the object.
    /// </summary>
    public override IEnumerator Perform(GameObject spell) {
      _spawnLocation = spell.transform.position;
      yield return new WaitUntil(() => Vector3.Distance(_spawnLocation, spell.transform.position) > range);
      Destroy(spell);
    }
  }
}