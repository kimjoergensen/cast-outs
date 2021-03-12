namespace Assets.Scripts.Spells.Effects
{
  using Assets.Scripts.Spells.Bases;
  using UnityEngine;

  [CreateAssetMenu(fileName = "DestroyOnHit", menuName = "Effects/Destroy On Hit")]
  public class DestroyOnHit : Effect
  {
    public override void Apply(GameObject spell, Collider target) {
      // Do nothing if the hit object is not a valid target.
      if (!ShouldTriggerCollision(target)) return;
      Destroy(spell.gameObject);
    }
  }
}
