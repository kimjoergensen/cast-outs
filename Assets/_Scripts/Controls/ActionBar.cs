using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Assertions;
using WarclockBrawl;
using WarlockBrawl.Extensions;
using WarlockBrawl.Spells.Interfaces;
using WarlockBrawl.Utility;

namespace WarlockBrawl.Controls {
    [Serializable]
    public class ActionBarEssentials {
        [Tooltip("Set the list of action bar buttons.")]
        public List<ActionBarButton> actionBarButtons;
    }

    [Serializable]
    public class ActionBarSettings {

    }

    /// <summary>
    /// Information sent through the <see cref="Observable{T}"/> pattern.
    /// </summary>
    public class ActionBarButtonInfo {
        public ISpell Spell { get; private set; }

        internal ActionBarButtonInfo(ISpell spell) {
            Spell = spell;
        }
    }

    public class ActionBar : Observable<ActionBar, ActionBarButtonInfo> {
        #region Inspector menues
        [Tooltip("Essential components for the ActionBar script.")]
        public ActionBarEssentials essentials;
        [Tooltip("Settings for the ActionBar behavior.")]
        public ActionBarSettings settings;
        #endregion

        #region Class variables
        private PropertyInfo[] _hotkeyProperties;
        #endregion

        private void Awake() {
            // Get a list of all hotkeys and action bar buttons.
            _hotkeyProperties = typeof(InputManager.ActionBarHotkeys).GetProperties();

            // Assign a hotkey to the buttons
            // and subscribe the OnButtonClicked method.
            foreach (var button in essentials.actionBarButtons) {

                button.OnButtonClicked += OnButtonClicked;
            }
        }

        /// <summary>
        /// Is invoked when a button has been clicked or the hotkey for the button has been pressed.
        /// </summary>
        /// <param name="spell"></param>
        private void OnButtonClicked(ISpell spell) {

        }

        #region Validation
        private void OnValidate() => Validate();

        /// <summary>
        /// Validate the code in the editor at compile time.
        /// </summary>
        private void Validate() {
            // References
            Assert.IsNotNull(essentials?.actionBarButtons, AssertUtility.ReferenceNullErrorMessage(typeof(List<ActionBarButton>), gameObject));
            Assert.IsTrue(essentials?.actionBarButtons.Count > 0, AssertUtility.ListEmptyErrorMessage(nameof(essentials.actionBarButtons), gameObject));
        }
        #endregion
    }
}
