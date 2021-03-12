namespace Assets.Scripts.Spells.Bases
{
  using UnityEngine;

  public abstract class Effect : ScriptableObject
  {
    protected bool ShouldTriggerCollision(Collider target) => target.gameObject.CompareTag("Enemy");

    /// <summary>
    /// Apply the effect to the game object of the target collision.
    /// </summary>
    /// <param name="spell">The spell's game object.</param>
    /// <param name="target">The target hit by the spell.</param>
    public abstract void Apply(GameObject spell, Collider target);
  }
}