namespace Assets.Scripts.VariableReferences.Variables
{
  using Assets.Scripts.VariableReferences.Bases;
  using UnityEngine;

  [CreateAssetMenu(fileName = "FloatVariable", menuName = "Variables/Float")]
  public class FloatVariable : ScriptableObject, IVariableReference<float>
  {
    [SerializeField]
    [Tooltip("Set the default value.")]
    private float _value;
    public float Value { get => _value; set => _value = value; }
  }
}
