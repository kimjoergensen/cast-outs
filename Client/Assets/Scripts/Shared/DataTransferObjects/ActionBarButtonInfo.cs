namespace CastOuts.Shared.DataTransferObjects
{
  using CastOuts.Spells.Interfaces;

  /// <summary>
  /// Contains information about the properties mapped to an activated action bar button.
  /// </summary>
  public class ActionBarButtonInfo
  {
    public ISpell Spell { get; private set; }

    internal ActionBarButtonInfo(ISpell spell) {
      Spell = spell;
    }
  }
}
