using CastOuts.Spells.Interfaces;

namespace CastOuts.Shared.DataTransferObjects {
    /// <summary>
    /// Contains information about the properties mapped to an activated action bar button.
    /// </summary>
    /// <seealso cref="Utility.Observable{TInfo}" />
    /// <seealso cref="Utility.Observable{TProvider, TInfo}"/>
    public class ActionBarButtonInfo {
        /// <summary>
        /// Gets the spell.
        /// </summary>
        public ISpell Spell { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionBarButtonInfo"/> class.
        /// </summary>
        /// <param name="spell">The spell.</param>
        internal ActionBarButtonInfo(ISpell spell) {
            Spell = spell;
        }
    }
}
