namespace Assets.Scripts.Spells.Types
{
  using Assets.Scripts.Spells.Bases;
  using Assets.Scripts.VariableReferences;
  using UnityEngine;

  [RequireComponent(typeof(Rigidbody))]
  [CreateAssetMenu(fileName = "Projectile", menuName = "Spells/Types/Projectile")]
  public class Projectile : Classification
  {
    [Tooltip("Set the speed of the projectile.")]
    public float speed;

    [Tooltip("Set the spell spawn location variable.")]
    public Vector3Reference spawnLocation;

    [Tooltip("Set the spell spawn rotation variable.")]
    public QuaternionReference spawnRotation;

    /// <summary>
    /// Shoot the spell from the player's spawn location towards the target location.
    /// </summary>
    public override void Activate(Vector3 target) {
      // Instantiate the fireball at the spawn location, looking towards the target location.
      var fireball = Instantiate(Spell, spawnLocation.Value, spawnRotation.Value);
      fireball.transform.LookAt(target);

      // Move the fireball in a straight line.
      var rigidbody = fireball.GetComponent<Rigidbody>();
      var force = fireball.transform.forward * speed;
      rigidbody.AddForce(force);
    }
  }
}