namespace Assets.Scripts.ActionBar
{
  using Assets.Scripts.Shared;
  using Assets.Scripts.Spells.Bases;
  using System.Collections.Generic;
  using UnityEngine;

  /// <summary>
  /// Container for action bar buttons.
  /// Notifies all observers of action bar buttons that a button has been pressed.
  /// </summary>
  public class ActionBar : Observable<ActionBarButtonInfo>
  {
    [Tooltip("Set the list of action bar buttons.")]
    public List<ActionBarButton> actionBarButtons;

    private void Start() {
#if DEBUG
      //var spell = gameObject.AddComponent<Fireball>();
      //_essentials.actionBarButtons.FirstOrDefault().AddAction(spell);
#endif
      // Subscribe the OnButtonClicked method to each button.
      foreach (var button in actionBarButtons)
        button.AddEventHandler(OnButtonClicked);
    }

    private void OnButtonClicked(Spell spell) {
      foreach (var observer in Observers)
        observer.OnNext(new ActionBarButtonInfo(spell));
    }
  }
}
