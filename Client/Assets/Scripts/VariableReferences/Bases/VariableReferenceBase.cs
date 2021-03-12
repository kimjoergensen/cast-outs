namespace Assets.Scripts.VariableReferences.Bases
{
  using UnityEngine;

  public abstract class VariableReferenceBase<TConstant, TVariable> where TConstant : struct where TVariable : IVariableReference<TConstant>
  {
    [SerializeField]
    [Tooltip("Toggle the reference between using the constant or variable value.")]
    private bool _useConstant = true;

    [SerializeField]
    [Tooltip("Set the constant value.")]
    private TConstant _constant;

    [SerializeField]
    [Tooltip("Reference a variable data asset. Other objects can reference the same asset to change the value.")]
    private TVariable _variable;

    public virtual TConstant Value {
      get {
        return _useConstant
            ? _constant
            : _variable.Value;
      }
      set {
        if (!_useConstant)
          _variable.Value = value;
      }
    }
  }

  public interface IVariableReference<T>
  {
    public T Value { get; set; }
  }
}