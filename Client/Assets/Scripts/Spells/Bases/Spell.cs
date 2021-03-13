namespace Assets.Scripts.Spells.Bases
{
  using Assets.Scripts.VariableReferences;
  using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;

  /// <summary>
  /// Base class for all spells.
  /// </summary>
  [RequireComponent(typeof(Rigidbody))]
  [RequireComponent(typeof(Collider))]
  public abstract class Spell : MonoBehaviour
  {
    [Tooltip("Set the name of the spell.")]
    public new string name;

    [Tooltip("Set the thumbnail image of the spell.")]
    public Sprite image;

    [Tooltip("Set the cooldown in seconds.")]
    public FloatReference cooldown;

    [Tooltip("Set the type of spell. Controls how the spell is activated.")]
    [SerializeField]
    private Classification type;

    [Tooltip("Add any generic behavior to the spell. Behaviors happen over time, or after a period.")]
    [SerializeField]
    private List<Behavior> behaviors;

    [Tooltip("Add any generic effects to the spell. Effects trigger on collision with other objects.")]
    [SerializeField]
    private List<Effect> effects;

    private bool _isOnCooldown = false;

    private void Start() {
      foreach (var behavior in behaviors)
        StartCoroutine(behavior.Perform(gameObject));
      StartCoroutine(StartCooldown());
    }

    private void OnTriggerEnter(Collider other) {
      foreach (var effect in effects)
        effect.Apply(gameObject, other);
    }

    /// <summary>
    /// Activate the spell.
    /// </summary>
    /// <param name="target">Target ground mouse input location.</param>
    public void Activate(Vector3 target) {
      if (_isOnCooldown) return;
      if (type.Spell == null)
        type.Spell = gameObject;
      type.Activate(target);
    }

    /// <summary>
    /// Start the spells cooldown timer.
    /// </summary>
    private IEnumerator StartCooldown() {
      if (_isOnCooldown)
        yield break;

      _isOnCooldown = true;
      yield return new WaitForSeconds(cooldown.Value);
      _isOnCooldown = false;
    }
  }
}
