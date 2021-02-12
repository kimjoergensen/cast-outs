using System;
using UnityEngine;

namespace CastOuts.Spells
{
  [Serializable]
  public class FireballEssentials
  {

  }

  [Serializable]
  public class FireballSettings
  {
    public string name;
    public float damage;
    public float speed;
    public float range;
    public Sprite image;
  }

  [RequireComponent(typeof(Rigidbody))]
  [RequireComponent(typeof(SphereCollider))]
  [RequireComponent(typeof(ParticleSystem))]
  public class Fireball : SpellBase
  {
    [Tooltip("Essential components for the Fireball script.")]
    public FireballEssentials essentials;
    [Tooltip("Settings for the Fireball behavior.")]
    public FireballSettings settings;

    public override string Name { get => settings.name; set => settings.name = value; }
    public override float Damage { get => settings.damage; set => settings.damage = value; }
    public override float Speed { get => settings.speed; set => settings.speed = value; }
    public override float Range { get => settings.range; set => settings.range = value; }
    public override Sprite Image { get => settings.image; set => settings.image = value; }

    private void Start()
    {
      DestroyOnMaxDistance(Range);
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.tag.Equals("Enemy"))
        Destroy(other.gameObject);
    }

    /// <summary>
    /// Shoot the spell from the <paramref name="spawnLocation" /> towards the <paramref name="targetLocation" />.
    /// </summary>
    /// <param name="spawnLocation"><see cref="Vector3"/> object holding the position the spell will be shot from.</param>
    /// <param name="targetLocation"><see cref="Vector3"/> object holding the position the spell will be traveling towards.</param>
    /// <returns>True if the spell was instantiated, false if not.</returns>
    public override void Shoot(Vector3 spawnLocation, Vector3 targetLocation)
    {
      // Instantiate the fireball at the spawn location, looking towards the target location.
      var fireball = Instantiate(gameObject, spawnLocation, Quaternion.identity) as GameObject;
      fireball.transform.LookAt(targetLocation);

      // Set the fireballs rotation on the X axis back to zero, so it always flies horizontally.
      fireball.transform.eulerAngles = new Vector3
      {
        x = 0.0f,
        y = fireball.transform.eulerAngles.y,
        z = fireball.transform.eulerAngles.z
      };

      // Move the fireball in a straight line.
      var rigidbody = fireball.GetComponent<Rigidbody>();
      rigidbody.velocity = fireball.transform.forward * settings.speed;
    }
  }
}
