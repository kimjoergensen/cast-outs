namespace Assets.Scripts.VariableReferences
{
  using System;
  using UnityEngine;

  [Serializable]
  public class Vector3Reference
  {
    public bool UseConstant = true;
    public Vector3 ConstantValue;
    public Vector3Variable Variable;

    public Vector3 Value {
      get {
        return UseConstant
            ? ConstantValue
            : Variable.Value;
      }
      set {
        if (UseConstant)
          ConstantValue = value;
        else
          Variable.Value = value;
      }
    }
  }

  [CreateAssetMenu(fileName = "Vector3Variable", menuName = "Variables/Vector3")]
  public class Vector3Variable : ScriptableObject
  {
    public Vector3 Value;
  }
}
