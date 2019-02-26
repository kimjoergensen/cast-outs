using System.Collections.Generic;
using UnityEngine;
using WarlockBrawl.Spells.Interfaces;

namespace WarlockBrawl.Actionbar {
    public static class ActionBar {
        #region Class variables
        private static Dictionary<KeyCode, ISpell> _actionBarDictionary;
        #endregion

        /// <summary>
        /// Set an <see cref="ISpell"/> on the actionbar slot mapped to <paramref name="keyCode"/>.
        /// </summary>
        /// <param name="keyCode"><see cref="KeyCode"/> of the actionbar slot.</param>
        /// <param name="spell"><see cref="ISpell"/> to map to the actionbar slot.</param>
        public static void SetSpell(KeyCode keyCode, ISpell spell) {
            // Check if the key code is already mapped in the dictionary.
            if (_actionBarDictionary.ContainsKey(keyCode))
                // Remove the current spell from the actionbar to make room for the new.
                _actionBarDictionary.Remove(keyCode);

            // Add the new spell to the key code.
            _actionBarDictionary.Add(keyCode, spell);
        }

        /// <summary>
        /// Get the <see cref="ISpell"/> mapped to <paramref name="keyCode"/>.
        /// </summary>
        /// <param name="keyCode">Actionbar <see cref="KeyCode"/> pressed.</param>
        /// <param name="spell">Spell mapped to the action bar with the pressed <see cref="KeyCode"/></param>
        /// <returns>True if a spell was found. False if no spell was found.</returns>
        public static bool TryGetSpell(KeyCode keyCode, out ISpell spell) {
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
