using CastOuts.VariableReferences;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Vector3Reference))]
public class Vector3ReferenceDrawer : PropertyDrawer
{
  private const int _dropdownButtonSize = 16;

  private bool _useConstant;
  private Vector3 _constantValue;
  private Vector3Reference _Variable;

  /// <summary>
  /// Override this method to make your own GUI for the property.
  /// </summary>
  /// <param name="position">Rectangle on the screen to use for the property GUI.</param>
  /// <param name="property">The SerializedProperty to make the custom GUI for.</param>
  /// <param name="label">The label of this property.</param>
  public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
  {

    _useConstant = property.FindPropertyRelative(nameof(Vector3Reference.UseConstant)).boolValue;
    _constantValue = property.FindPropertyRelative(nameof(Vector3Reference.ConstantValue)).vector3Value;

    EditorGUI.BeginProperty(position, label, property);

    // Draw label and get the position to draw the properties.
    position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

    // Draw dropdown button.
    DrawDropdownButton(position, property);

    // Draw property fields.
    if (_useConstant)
    {
      var newValue = EditorGUI.Vector3Field(position, GUIContent.none, _constantValue);
      property.FindPropertyRelative(nameof(Vector3Reference.ConstantValue)).vector3Value = newValue;
    }
    else
    {
      EditorGUI.ObjectField(position, property.FindPropertyRelative(nameof(Vector3Reference.Variable)), GUIContent.none);
    }

    EditorGUI.EndProperty();
  }

  #region Dropdown button
  private void DrawDropdownButton(Rect position, SerializedProperty property)
  {
    var rect = new Rect(position.position, Vector2.one * _dropdownButtonSize);
    var content = new GUIContent
    {
      image = Resources.Load<Texture2D>("icons/baseline_menu_black_48dp")
    };

    var style = new GUIStyle
    {
      fixedHeight = _dropdownButtonSize,
      fixedWidth = _dropdownButtonSize,
      stretchHeight = true,
      stretchWidth = true
    };

    if (EditorGUI.DropdownButton(rect, content, FocusType.Keyboard, style))
    {
      var menu = new GenericMenu();

      menu.AddItem(new GUIContent("Constant"), _useConstant,
          () => SetUseConstantProperty(property, true));

      menu.AddItem(new GUIContent("Variable"), !_useConstant,
          () => SetUseConstantProperty(property, false));

      menu.ShowAsContext();
    }
  }

  private void SetUseConstantProperty(SerializedProperty property, bool value)
  {
    property.FindPropertyRelative(nameof(Vector3Reference.UseConstant)).boolValue = value;
    property.serializedObject.ApplyModifiedProperties();
  }
  #endregion
}
