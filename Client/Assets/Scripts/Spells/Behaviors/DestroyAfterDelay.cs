namespace Assets.Scripts.Spells.Behaviors
{
  using Assets.Scripts.Spells.Bases;
  using System.Collections;
  using UnityEngine;

  [CreateAssetMenu(fileName = "DestroyAfterDelay", menuName = "Behaviors/Destroy After Delay")]
  public class DestroyAfterDelay : Behavior
  {
    [Tooltip("Set the time delayed in seconds before destroying the spell.")]
    public float seconds;

    /// <summary>
    /// Wait for seconds before destroying gameObject.
    /// </summary>
    public override IEnumerator Perform(GameObject spell) {
      yield return new WaitForSeconds(seconds);
      Destroy(spell);
    }
  }
}