namespace Assets.Scripts.Spells.Bases
{
  using UnityEngine;

  public abstract class Classification : ScriptableObject
  {
    public GameObject Spell { get; set; }

    /// <summary>
    /// Activates the spell.
    /// </summary>
    /// <param name="target">Target ground mouse input location.</param>
    public abstract void Activate(Vector3 target);
  }
}
