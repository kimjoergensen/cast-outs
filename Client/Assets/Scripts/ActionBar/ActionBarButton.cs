namespace Assets.Scripts.ActionBar
{
  using Assets.Scripts.Shared.KeyBinding;
  using Assets.Scripts.Spells.Bases;
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
    [Tooltip("Set which key binding is mapped to the action bar button.")]
    public KeyBinding keyBinding;

    private UnityAction<Spell> _eventHandler;
    private Button _button;
    private Image _image;
    private Text _text;
    public Spell _spell;

    private void Awake() {
      _button = GetComponent<Button>();
      _image = GetComponent<Image>();
      _text = GetComponentInChildren<Text>();
    }

    private void Start() {
      // Set the text on the button to the assigned hotkey.
      _text.text = Enum.GetName(typeof(KeyCode), InputManager.Instance.GetHotkey(keyBinding));

      // Set the spell's thumbnail image on the button.
      if (!(_spell is null)) {
        _image.color = Color.white;
        _image.sprite = _spell.image;
      }

      // Add an event listener to mouse click on the button.
      _button.onClick.AddListener(HandleEvent);
    }

    private void Update() {
      if (InputManager.Instance.GetKeyDown(keyBinding))
        HandleEvent();
    }

    /// <summary>
    /// Add a spell to the action bar button.
    /// </summary>
    public void AddAction(Spell spell) {
      _spell = spell;
    }

    /// <summary>
    /// Add event handler to on button clicked.
    /// </summary>
    public void AddEventHandler(UnityAction<Spell> eventHandler) {
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
