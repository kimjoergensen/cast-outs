namespace Assets.Scripts.Spells.Bases
{
  using System.Collections;
  using UnityEngine;

  public abstract class Behavior : ScriptableObject
  {
    /// <summary>
    /// Perform the action on the derived behavior.
    /// </summary>
    /// <param name="spell">The spell's game object.</param>
    public abstract IEnumerator Perform(GameObject spell);
  }
}