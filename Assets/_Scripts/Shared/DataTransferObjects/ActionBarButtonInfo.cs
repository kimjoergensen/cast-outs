using CastOuts.Spells.Interfaces;
using UnityEngine;

namespace CastOuts.Shared.DataTransferObjects {
    public class ActionBarButtonInfo : MonoBehaviour {
        public ISpell Spell { get; private set; }

        internal ActionBarButtonInfo(ISpell spell) {
            Spell = spell;
        }
    }
}
