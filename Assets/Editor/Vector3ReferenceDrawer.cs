using CastOuts.VariableReferences;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Vector3Reference))]
public class Vector3ReferenceDrawer : PropertyDrawer {
    private const int _dropdownButtonSize = 16;
    private Texture2D _dropdownButtonTexture;

    private bool _useConstant;
    private Vector3 _constantValue;
    private Vector3Reference _Variable;

    /// <summary>
    /// Override this method to make your own GUI for the property.
    /// </summary>
    /// <param name="position">Rectangle on the screen to use for the property GUI.</param>
    /// <param name="property">The SerializedProperty to make the custom GUI for.</param>
    /// <param name="label">The label of this property.</param>
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        if (_dropdownButtonTexture == null)
            InitializeDropdownButtonTexture();

        _useConstant = property.FindPropertyRelative(nameof(Vector3Reference.UseConstant)).boolValue;
        _constantValue = property.FindPropertyRelative(nameof(Vector3Reference.ConstantValue)).vector3Value;

        EditorGUI.BeginProperty(position, label, property);

        // Draw label and get the position to draw the properties.
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Draw dropdown button.
        position = DrawDropdownButton(position, property);

        // Draw property fields.
        if (_useConstant) {
            var newValue = EditorGUI.Vector3Field(position, nameof(Vector3Reference.ConstantValue), _constantValue);
            property.FindPropertyRelative(nameof(Vector3Reference.ConstantValue)).vector3Value = newValue;
        }
        else {
            EditorGUI.ObjectField(position, property.FindPropertyRelative(nameof(Vector3Reference.Variable)), GUIContent.none);
        }

        EditorGUI.EndProperty();
    }

    #region Dropdown button
    private Rect DrawDropdownButton(Rect position, SerializedProperty property) {
        var rect = new Rect(position.position, Vector2.one * _dropdownButtonSize);
        var content = new GUIContent(_dropdownButtonTexture);

        var style = new GUIStyle {
            fixedHeight = _dropdownButtonSize,
            fixedWidth = _dropdownButtonSize,
            border = new RectOffset(1, 1, 1, 1)
        };

        if (EditorGUI.DropdownButton(rect, content, FocusType.Keyboard, style)) {
            var menu = new GenericMenu();

            menu.AddItem(new GUIContent("Constant"), _useConstant,
                () => SetUseConstantProperty(property, true));

            menu.AddItem(new GUIContent("Variable"), !_useConstant,
                () => SetUseConstantProperty(property, false));

            menu.ShowAsContext();
        }

        position.position += Vector2.right * 5;
        return position;
    }

    //private Rect DrawDropdownButton(Rect position, SerializedProperty property) {
    //    var rect = new Rect(position.position, Vector2.one * _dropdownButtonSize);
    //    var content = new GUIContent(_dropdownButtonTexture);

    //    var style = new GUIStyle {
    //        fixedHeight = _dropdownButtonSize,
    //        fixedWidth = _dropdownButtonSize,
    //        border = new RectOffset(1, 1, 1, 1)
    //    };

    //    if (EditorGUI.DropdownButton(rect, content, FocusType.Keyboard, style)) {
    //        var menu = new GenericMenu();

    //        menu.AddItem(new GUIContent("Constant"), _useConstant,
    //            () => SetUseConstantProperty(property, true));

    //        menu.AddItem(new GUIContent("Variable"), !_useConstant,
    //            () => SetUseConstantProperty(property, false));

    //        menu.ShowAsContext();
    //    }

    //    position.position += Vector2.right * 5;
    //    return position;
    //}

    private void SetUseConstantProperty(SerializedProperty property, bool value) {
        property.FindPropertyRelative(nameof(Vector3Reference.UseConstant)).boolValue = value;
        property.serializedObject.ApplyModifiedProperties();
    }

    private void InitializeDropdownButtonTexture() {
        _dropdownButtonTexture = new Texture2D(_dropdownButtonSize, _dropdownButtonSize, TextureFormat.RGB24, false);
        Color32[] color32s = new Color32[_dropdownButtonSize * _dropdownButtonSize];

        for (var i = 0; i < color32s.Length; i++)
            color32s[i] = Color.black;

        _dropdownButtonTexture.SetPixels32(color32s);
        _dropdownButtonTexture.Apply();
    }
    #endregion
}
