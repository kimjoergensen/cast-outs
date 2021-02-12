using System.Collections;
using CastOuts.Shared.Utility;
using CastOuts.Spells.Interfaces;
using UnityEngine;
using UnityEngine.Assertions;

namespace CastOuts.Spells
{
  /// <summary>Base class for all spells.</summary>
  public abstract class SpellBase : MonoBehaviour, ISpell
  {
    public abstract string Name { get; set; }
    public abstract float Damage { get; set; }
    public abstract float Speed { get; set; }
    public abstract float Range { get; set; }
    public abstract Sprite Image { get; set; }

    #region Class variables
    private Vector3 _spawnLocation;
    #endregion

    private void Start()
    {
      _spawnLocation = transform.position;
    }

    /// <summary>
    /// Destroy the spell after it has reached a maximum range from its initial spawn location.
    /// </summary>
    /// <param name="range">Range in units.</param>
    public IEnumerator DestroyOnMaxDistance(float range)
    {
      yield return new WaitUntil(() => Vector3.Distance(_spawnLocation, transform.position) > Range);
      Destroy(gameObject);
    }

    /// <summary>
    /// Destroy the spell after a delay.
    /// </summary>
    /// <param name="time">Delay in seconds.</param>
    public IEnumerator DestroyAfterDelay(float time)
    {
      yield return new WaitForSeconds(time);
      Destroy(gameObject);
    }

    public abstract void Shoot(Vector3 spawnLocation, Vector3 targetLocation);

    private void OnValidate() => Validate();
    private void Validate()
    {
      Assert.IsTrue(Name.NotEmpty(), AssertErrorMessage.NotEmpty(nameof(Name), gameObject));
      Assert.IsTrue(Damage.GreaterThan(default), AssertErrorMessage.GreaterThan(nameof(Damage), default, gameObject));
      Assert.IsTrue(Speed.GreaterThan(default), AssertErrorMessage.GreaterThan(nameof(Speed), default, gameObject));
      Assert.IsTrue(Range.GreaterThan(default), AssertErrorMessage.GreaterThan(nameof(Range), default, gameObject));
      Assert.IsNotNull(Image, AssertErrorMessage.NotNull<Sprite>(nameof(Image), gameObject));
    }
  }
}
