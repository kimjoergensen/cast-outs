namespace Assets.Scripts.Spells.Types
{
  using Assets.Scripts.Player;
  using Assets.Scripts.Spells.Bases;
  using UnityEngine;

  [RequireComponent(typeof(Rigidbody))]
  [CreateAssetMenu(fileName = "Projectile", menuName = "Types/Projectile")]
  public class Projectile : Classification
  {
    [Tooltip("Set the speed of the projectile.")]
    public float speed;

    private Transform _spawnLocation;

    /// <summary>
    /// Shoot the spell from the player's spawn location towards the target location.
    /// </summary>
    public override void Activate(Vector3 target) {
      // Get spawn location.
      var player = GameObject.FindWithTag("Player");
      if (player is null) return;

      var controller = player.GetComponent<PlayerController>();
      if (controller is null) return;
      _spawnLocation = controller.spellSpawnLocation;

      // Instantiate the fireball at the spawn location, looking towards the target location.
      var fireball = Instantiate(Spell, _spawnLocation.position, _spawnLocation.rotation);
      fireball.transform.LookAt(target);

      // Move the fireball in a straight line.
      var rigidbody = fireball.GetComponent<Rigidbody>();
      var force = fireball.transform.forward * speed;
      rigidbody.AddForce(force);
    }
  }
}