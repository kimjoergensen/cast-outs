namespace CastOuts.ActionBar
{
  using CastOuts.Shared;
  using CastOuts.Shared.DataTransferObjects;
  using CastOuts.Spells.Interfaces;
  using System;
  using System.Collections.Generic;
  using UnityEngine;

  /// <summary>
  /// Container for action bar buttons.
  /// Notifies all observers of action bar buttons that a button has been pressed.
  /// </summary>
  public class ActionBar : Observable<ActionBarButtonInfo>
  {
    [Serializable]
    protected class Essentials
    {
      [Tooltip("Set the list of action bar buttons.")]
      public List<ActionBarButton> actionBarButtons;
    }

    [Serializable]
    protected class Settings
    {

    }

    [SerializeField]
    private Essentials _essentials;
    [SerializeField]
    private Settings _settings;

    private void Start() {
#if DEBUG
      //var spell = gameObject.AddComponent<Fireball>();
      //_essentials.actionBarButtons.FirstOrDefault().AddAction(spell);
#endif
      // Subscribe the OnButtonClicked method to each button.
      foreach (var button in _essentials.actionBarButtons)
        button.AddEventHandler(OnButtonClicked);
    }

    private void OnButtonClicked(ISpell spell) {
      foreach (var observer in Observers)
        observer.OnNext(new ActionBarButtonInfo(spell));
    }
  }
}
