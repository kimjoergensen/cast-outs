namespace Assets.Scripts.Spells.Bases
{
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

    [Tooltip("Set the type of the spell.")]
    [SerializeField]
    private Classification type;

    [Tooltip("Add any generic behavior to the spell. Behaviors happen over type, or after a period.")]
    [SerializeField]
    private List<Behavior> behaviors;

    [Tooltip("Add any generic effects to the spell. Effects trigger on collision with other objects.")]
    [SerializeField]
    private List<Effect> effects;

    private void Start() {
      foreach (var behavior in behaviors)
        StartCoroutine(behavior.Perform(gameObject));
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
      type.Spell = gameObject;
      type.Activate(target);
    }
  }
}
