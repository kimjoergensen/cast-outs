namespace Assets.Scripts.VariableReferences.Variables
{
  using Assets.Scripts.VariableReferences.Bases;
  using UnityEngine;

  [CreateAssetMenu(fileName = "TransformVariable", menuName = "Variables/Transform")]
  public class TransformVariable : ScriptableObject, IVariableReference<TransformOverride>
  {
    [SerializeField]
    [Tooltip("Set the default values.")]
    private TransformOverride _value;
    public TransformOverride Value { get => _value; set => _value = value; }
  }
}
