using System.Collections.Generic;
using UnityEngine;
using WarlockBrawl.Spells.Interfaces;
using WarlockBrawl.Utility;

namespace WarlockBrawl.Controls {
    public class ActionBar : Singleton<ActionBar> {
        #region Class variables
        private static Dictionary<KeyCode, ISpell> _actionBarDictionary = new Dictionary<KeyCode, ISpell>();
        #endregion

        /// <summary>
        /// Set an <see cref="ISpell"/> on the action bar slot mapped to <paramref name="keyCode"/>.
        /// </summary>
        /// <param name="keyCode"><see cref="KeyCode"/> of the action bar slot.</param>
        /// <param name="spell"><see cref="ISpell"/> to map to the action bar slot.</param>
        public void SetSpell(KeyCode keyCode, ISpell spell) {
            // Check if the key code is already mapped in the dictionary.
            if (_actionBarDictionary.ContainsKey(keyCode))
                // Remove the current spell from the dictionary to make room for the new.
                _actionBarDictionary.Remove(keyCode);

            // Add the new spell to the dictionary with the key code as it's key.
            _actionBarDictionary.Add(keyCode, spell);
        }

        /// <summary>
        /// Get the <see cref="ISpell"/> mapped to <paramref name="keyCode"/>.
        /// </summary>
        /// <param name="keyCode">Action bar <see cref="KeyCode"/> pressed.</param>
        /// <param name="spell"><see cref="ISpell"/> mapped to the action bar with the pressed <see cref="KeyCode"/></param>
        /// <returns>True if an <see cref="ISpell"/> was found. False if no <see cref="ISpell"/> was found.</returns>
        public bool TryGetSpell(KeyCode keyCode, out ISpell spell) {
            // Set default out value to null.
            spell = null;

            // Try to set the out value to the spell mapped on the passed key code.
            // Returns false if no spell could be found.
            if (!_actionBarDictionary.TryGetValue(keyCode, out spell)) return false;

            // Return true if a spell is successfully return to the out value.
            return true;
        }
    }
}
