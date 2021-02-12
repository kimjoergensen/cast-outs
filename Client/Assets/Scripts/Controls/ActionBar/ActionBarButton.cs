using System;
using CastOuts.Shared.Utility;
using CastOuts.Spells;
using CastOuts.Spells.Interfaces;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CastOuts.Controls
{
  [Serializable]
  public class ActionBarButtonEssentials
  {

  }

  [Serializable]
  public class ActionBarButtonSettings
  {
    [Tooltip("Set which key binding is mapped to the action bar button.")]
    public Keybinding KeyBinding;
  }

  /// <summary>
  /// Invokes the <see cref="ActionBar"/> class when an action bar button has been pressed.
  /// </summary>
  [RequireComponent(typeof(Button))]
  [RequireComponent(typeof(Image))]
  public class ActionBarButton : MonoBehaviour
  {
    #region Inspector menues
    [Tooltip("Essential components for the ActionBarButton script.")]
    public ActionBarButtonEssentials essentials;
    [Tooltip("Settings for the ActionBarButton behavior.")]
    public ActionBarButtonSettings settings;
    #endregion

    #region Class variables
    /// <summary>
    /// The event handler.
    /// </summary>
    public UnityAction<ISpell> EventHandler;

    private Button _button;
    private Image _image;
    private Text _text;
    private ISpell _spell;
    #endregion

    // TODO: Let spell be selected by in-game spell shop.
    public SpellBase spell;

    private void Awake()
    {
      _button = GetComponent<Button>();
      _image = GetComponent<Image>();
      _text = GetComponentInChildren<Text>();
      _spell = spell;
    }

    private void Start()
    {
      // Set the text on the button to the assigned hotkey.
      _text.text = Enum.GetName(typeof(KeyCode), InputManager.Instance.GetHotkey(settings.KeyBinding));

      // Set the spells thumbnail image on the button.
      if (_spell != null)
      {
        _image.color = Color.white;
        _image.sprite = _spell.Image;
      }

      // Add an event listener to mouse click on the button.
      _button.onClick.AddListener(HandleEvent);
    }

    private void Update()
    {
      if (InputManager.Instance.GetKeyDown(settings.KeyBinding))
        HandleEvent();
    }

    /// <summary>
    /// Handles what happens when the button has been activated by a mouse click or the hotkey.
    /// </summary>
    private void HandleEvent()
    {
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
    /// Validates this instance.
    /// </summary>
    private void Validate()
    {
      // Components
      Assert.IsNotNull(GetComponent<Button>(), AssertErrorMessage.NotNull<Button>(gameObject));
      Assert.IsNotNull(GetComponent<Image>(), AssertErrorMessage.NotNull<Image>(gameObject));
      Assert.IsNotNull(GetComponentInParent<ActionBarButton>(), AssertErrorMessage.ChildOf<ActionBar>(gameObject.name));
      Assert.IsNotNull(GetComponentInChildren<Text>(), AssertErrorMessage.ParentOf<Text>(gameObject.name));

      // References
    }
    #endregion
  }
}
