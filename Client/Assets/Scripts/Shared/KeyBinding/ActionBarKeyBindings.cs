namespace Assets.Scripts.Shared.KeyBinding
{
  using UnityEngine;

  [CreateAssetMenu(fileName = "ActionBarKeyBindings", menuName = "Key Bindings/Action Bar Key Bindingss", order = 2)]
  public class ActionBarKeyBindings : ScriptableObject
  {
    [Tooltip("Set the hotkey for action bar button 1.")]
    public KeyCode ActionBarButton1 = KeyCode.Q;
    [Tooltip("Set the hotkey for action bar button 2.")]
    public KeyCode ActionBarButton2 = KeyCode.W;
    [Tooltip("Set the hotkey for action bar button 3.")]
    public KeyCode ActionBarButton3 = KeyCode.E;
    [Tooltip("Set the hotkey for action bar button 4.")]
    public KeyCode ActionBarButton4 = KeyCode.R;
    [Tooltip("Set the hotkey for action bar button 5.")]
    public KeyCode ActionBarButton5 = KeyCode.D;
    [Tooltip("Set the hotkey for action bar button 6.")]
    public KeyCode ActionBarButton6 = KeyCode.F;
  }
}