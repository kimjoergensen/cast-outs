using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using WarlockBrawl.Extensions;
using WarlockBrawl.Spells.Interfaces;

namespace WarlockBrawl.Controls {
    [Serializable]
    public class ActionBarButtonEssentials {

    }

    [Serializable]
    public class ActionBarButtonSettings {

    }

    [RequireComponent(typeof(Button))]
    public class ActionBarButton : MonoBehaviour {
        #region Inspector menues
        [Tooltip("Essential components for the ActionBarButton script.")]
        public ActionBarButtonEssentials essentials;
        [Tooltip("Settings for the ActionBarButton behavior.")]
        public ActionBarButtonSettings settings;
        #endregion

        #region Class variables
        public event Action<ISpell> OnButtonClicked;

        private ISpell _spell;
        #endregion

        private void Awake() {
            GetComponent<Button>().onClick.AddListener(HandleClick);
        }

        private void HandleClick() {
            // Do nothing if no spell has been assigned to the action bar button.
            if (_spell == null) return;

            // Invoke all subscribers on the delegate and pass the spell to their parameter.
            OnButtonClicked?.Invoke(_spell);
        }

        #region Validation
        private void OnValidate() => Validate();

        /// <summary>
        /// Validate the code in the editor at compile time.
        /// </summary>
        private void Validate() {
            Assert.IsNotNull(GetComponentInParent<ActionBarButton>(), AssertErrorMessage.ChildOf<ActionBar>(gameObject.name));
        }
        #endregion
    }
}
