using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
using UnityEngine.UI;
using WarlockBrawl.Extensions;
using WarlockBrawl.Spells;
using WarlockBrawl.Spells.Interfaces;

namespace WarlockBrawl.Controls {
    [Serializable]
    public class ActionBarButtonEssentials {

    }

    [Serializable]
    public class ActionBarButtonSettings {

    }

    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(Image))]
    public class ActionBarButton : MonoBehaviour {
        #region Inspector menues
        [Tooltip("Essential components for the ActionBarButton script.")]
        public ActionBarButtonEssentials essentials;
        [Tooltip("Settings for the ActionBarButton behavior.")]
        public ActionBarButtonSettings settings;
        #endregion

        #region Class variables
        public UnityAction<ISpell> EventHandler;

        private ISpell _spell;
        #endregion

        public SpellBase spell;

        private void Awake() {
            // Add the HandleEvent method to the buttons on click events.
            // This will call the HandleEvent method whenever the button is clicked by the mouse.
            GetComponent<Button>().onClick.AddListener(HandleEvent);
            _spell = spell;
        }

        /// <summary>
        /// Handles what happens when the button has been activated by a mouse click or the hotkey.
        /// </summary>
        private void HandleEvent() {
            Debug.Log("Action bar clicked");
            // Do nothing if no spell has been assigned to the action bar button.
            if (_spell == null) return;

            // Make a temporary copy of the event to avoid possibility of
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            var handler = EventHandler;

            // Invoke all subscribers on the delegate and pass the spell to their parameter.
            handler?.Invoke(_spell);
        }

        #region Validation
        private void OnValidate() => Validate();

        /// <summary>
        /// Validate the code in the editor at compile time.
        /// </summary>
        private void Validate() {
            // Components
            Assert.IsNotNull(GetComponent<Button>(), AssertErrorMessage.NotNull<Button>(gameObject));
            Assert.IsNotNull(GetComponent<Image>(), AssertErrorMessage.NotNull<Image>(gameObject));
            Assert.IsNotNull(GetComponentInParent<ActionBarButton>(), AssertErrorMessage.ChildOf<ActionBar>(gameObject.name));

            // References

        }
        #endregion
    }
}
