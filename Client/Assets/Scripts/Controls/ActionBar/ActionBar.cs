using System;
using System.Collections.Generic;
using System.Reflection;
using CastOuts.Shared.DataTransferObjects;
using CastOuts.Shared.Utility;
using CastOuts.Spells.Interfaces;
using UnityEngine;
using UnityEngine.Assertions;

namespace CastOuts.Controls
{
  [Serializable]
  public class ActionBarEssentials
  {
    [Tooltip("Set the list of action bar buttons.")]
    public List<ActionBarButton> actionBarButtons;
  }

  [Serializable]
  public class ActionBarSettings
  {

  }

  /// <summary>
  /// Container for <see cref="ActionBarButton"/>.
  /// <para></para>
  /// </summary>
  /// <seealso cref="Shared.Utility.Observable{ActionBar, ActionBarButtonInfo}" />
  public class ActionBar : Observable<ActionBar, ActionBarButtonInfo>
  {
    #region Inspector menues
    [Tooltip("Essential components for the ActionBar script.")]
    public ActionBarEssentials essentials;
    [Tooltip("Settings for the ActionBar behavior.")]
    public ActionBarSettings settings;
    #endregion

    #region Class variables

    #endregion

    private void Start()
    {
      // Subscribe the OnButtonClicked method to each button.
      foreach (var button in essentials.actionBarButtons)
      {
        button.EventHandler += OnButtonClicked;
      }
    }

    /// <summary>
    /// Is invoked when a button has been clicked or the hotkey for the button has been pressed.
    /// </summary>
    /// <param name="spell"></param>
    private void OnButtonClicked(ISpell spell)
    {
      foreach (var observer in Observers)
        observer.OnNext(new ActionBarButtonInfo(spell));
    }

    #region Validation
    private void OnValidate() => Validate();

    /// <summary>
    /// Validate the code in the editor at compile time.
    /// </summary>
    private void Validate()
    {
      // Components

      // References
      Assert.IsTrue(essentials.actionBarButtons.NotEmpty(), AssertErrorMessage.NotEmpty(nameof(essentials.actionBarButtons), gameObject));
      Assert.IsTrue(essentials.actionBarButtons.TrueForAll(button => button != null), AssertErrorMessage.NotNull<ActionBarButton>(nameof(essentials.actionBarButtons), gameObject));
    }
    #endregion
  }
}
