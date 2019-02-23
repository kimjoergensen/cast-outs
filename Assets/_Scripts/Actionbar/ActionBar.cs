using System.Collections.Generic;
using UnityEngine;
using WarclockBrawl;
using WarlockBrawl.Spells.Interfaces;

namespace WarlockBrawl.Actionbar {
    public class ActionBar {
        #region Class variables
        private Dictionary<KeyCode, ISpell> _actionBarMap;
        #endregion

        public void SetSpell(KeyCode keyCode, ISpell spell) {

        }

        public ISpell TryGetSpell(KeyCode keyCode) {
            return _actionBarMap.TryGetValue(keyCode, out var spell)
                ? spell
                : null;
        }
    }
}
