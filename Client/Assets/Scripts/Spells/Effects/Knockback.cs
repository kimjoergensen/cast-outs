namespace Assets.Scripts.Spells.Effects
{
  using Assets.Scripts.Spells.Bases;
  using UnityEngine;

  [CreateAssetMenu(fileName = "Knockback", menuName = "Effects/Knockback")]
  public class Knockback : Effect
  {
    [Tooltip("Set the knockback force on the hit object.")]
    public float force;

    /// <summary>
    /// Adds a force to the targeted game objects rigidbody.
    /// </summary>
    public override void Apply(GameObject spell, Collider target) {
      // Do nothing if the hit object is not a valid target.
      if (!ShouldTriggerCollision(target)) return;

      // Check if collided object has a Rigidbody.
      var rigidbody = target.gameObject.GetComponent<Rigidbody>();
      if (rigidbody is null) return;

      var direction = spell.transform.forward - (spell.transform.position - target.transform.position);
      var _force = direction.normalized * force;
      rigidbody.AddForce(_force);
    }
  }
}