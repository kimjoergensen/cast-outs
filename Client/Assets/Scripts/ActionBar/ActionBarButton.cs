namespace CastOuts.ActionBar
{
  using CastOuts.Shared;
  using CastOuts.Spells;
  using CastOuts.Spells.Interfaces;
  using System;
  using UnityEngine;
  using UnityEngine.Events;
  using UnityEngine.UI;

  /// <summary>
  /// Invokes the ActionBar class when a button has been pressed.
  /// </summary>
  [RequireComponent(typeof(Button))]
  [RequireComponent(typeof(Image))]
  [RequireComponent(typeof(Text))]
  public class ActionBarButton : MonoBehaviour
  {
    [Serializable]
    protected class Essentials
    {

    }

    [Serializable]
    protected class Settings
    {
      [Tooltip("Set which key binding is mapped to the action bar button.")]
      public KeyBinding keyBinding;
    }

    [SerializeField]
    private Essentials _essentials;
    [SerializeField]
    private Settings _settings;

    private UnityAction<ISpell> _eventHandler;
    private Button _button;
    private Image _image;
    private Text _text;
    public SpellBase _spell;

    private void Awake() {
      _button = GetComponent<Button>();
      _image = GetComponent<Image>();
      _text = GetComponentInChildren<Text>();
    }

    private void Start() {
      // Set the text on the button to the assigned hotkey.
      _text.text = Enum.GetName(typeof(KeyCode), InputManager.Instance.GetHotkey(_settings.keyBinding));

      // Set the spell's thumbnail image on the button.
      if (!(_spell is null)) {
        _image.color = Color.white;
        _image.sprite = _spell.Image;
      }

      // Add an event listener to mouse click on the button.
      _button.onClick.AddListener(HandleEvent);
    }

    private void Update() {
      if (InputManager.Instance.GetKeyDown(_settings.keyBinding))
        HandleEvent();
    }

    /// <summary>
    /// Add a spell to the action bar button.
    /// </summary>
    public void AddAction(ISpell spell) {
      _spell = (SpellBase)spell;
    }

    /// <summary>
    /// Add event handler to on button clicked.
    /// </summary>
    public void AddEventHandler(UnityAction<ISpell> eventHandler) {
      _eventHandler += eventHandler;
    }

    private void HandleEvent() {
      // Do nothing if no spell has been assigned to the action bar button.
      if (_spell is null) return;

      // Make a temporary copy of the event to avoid possibility of
      // a race condition if the last subscriber unsubscribes immediately after
      // the null check and before the event is raised.
      var handler = _eventHandler;

      // Invoke all subscribers on the delegate and pass the spell to their parameter.
      handler?.Invoke(_spell);
    }
  }
}
