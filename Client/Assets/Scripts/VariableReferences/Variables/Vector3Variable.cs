namespace Assets.Scripts.VariableReferences.Variables
{
  using Assets.Scripts.VariableReferences.Bases;
  using UnityEngine;

  [CreateAssetMenu(fileName = "Vector3Variable", menuName = "Variables/Vector3")]
  public class Vector3Variable : ScriptableObject, IVariableReference<Vector3>
  {
    public Vector3 Value { get; set; }
  }
}
