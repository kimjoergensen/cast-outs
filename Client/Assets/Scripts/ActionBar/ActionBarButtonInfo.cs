using Assets.Scripts.Spells.Bases;

namespace Assets.Scripts.ActionBar
{
  /// <summary>
  /// Contains information about the properties mapped to an activated action bar button.
  /// </summary>
  public class ActionBarButtonInfo
  {
    public Spell Spell { get; private set; }

    internal ActionBarButtonInfo(Spell spell) {
      Spell = spell;
    }
  }
}
