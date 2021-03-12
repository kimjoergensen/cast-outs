namespace Assets.Scripts.VariableReferences
{
  using Assets.Scripts.VariableReferences.Bases;
  using Assets.Scripts.VariableReferences.Variables;
  using System;
  using UnityEngine;

  [Serializable]
  public class TransformReference : VariableReferenceBase<TransformOverride, TransformVariable> { }

  [Serializable]
  public struct TransformOverride
  {
    public Vector3 position;
    public Quaternion rotation;

    public TransformOverride(Vector3 position, Quaternion rotation) {
      this.position = position;
      this.rotation = rotation;
    }

    public override string ToString() => $"position: {position}. Rotation: {rotation}";
  }
}