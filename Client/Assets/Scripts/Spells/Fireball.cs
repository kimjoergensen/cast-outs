namespace CastOuts.Spells
{
  using System;
  using UnityEngine;

  [RequireComponent(typeof(Rigidbody))]
  [RequireComponent(typeof(SphereCollider))]
  [RequireComponent(typeof(ParticleSystem))]
  public class Fireball : SpellBase
  {
    [Serializable]
    protected class Settings
    {

    }

    [SerializeField]
    private Settings settings;

    private void Start() {
      StartCoroutine(DestroyOnMaxDistance(Range));
    }

    private void OnTriggerEnter(Collider other) {
      // Do nothing if Fireball collides with anything other than an "Enemy".
      if (!other.gameObject.CompareTag("Enemy")) return;

      // Check if collided object has a Rigidbody.
      var rigidbody = other.GetComponent<Rigidbody>();
      if (rigidbody is null) return;

      // Apply the Fireball's force to the collided object.
      var force = transform.forward * Force;
      rigidbody.AddRelativeForce(force);

      // Destroy the fireball.
      Destroy(gameObject);
    }

    /// <summary>
    /// Shoot the spell from spawnLocation towards targetLocation.
    /// </summary>
    /// <param name="spawnLocation">Vector3 of the position the spell will be shot from.</param>
    /// <param name="targetLocation">Vector3 of the position the spell will be traveling towards.</param>
    public override void Shoot(Vector3 spawnLocation, Vector3 targetLocation) {
      // Instantiate the fireball at the spawn location, looking towards the target location.
      var fireball = Instantiate(gameObject, spawnLocation, Quaternion.identity);
      fireball.transform.LookAt(targetLocation);

      // Move the fireball in a straight line.
      var rigidbody = fireball.GetComponent<Rigidbody>();
      var speed = fireball.transform.forward * Speed;
      rigidbody.AddForce(speed);
    }
  }
}
