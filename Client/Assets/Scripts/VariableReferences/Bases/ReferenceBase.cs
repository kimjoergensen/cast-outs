namespace Assets.Scripts.VariableReferences.Bases
{
  using UnityEngine;

  public abstract class ReferenceBase<TConstant, TVariable> where TConstant : struct where TVariable : IVariableReference<TConstant>
  {
    [SerializeField]
    [Tooltip("Toggle the reference between using a local or referenced variable. Referenced variables can be changed by other game object referencing the same variable.")]
    private bool _useLocal = true;

    [SerializeField]
    [Tooltip("Set the local value. The local value can only be changed by this game object.")]
    private TConstant _local;

    [SerializeField]
    [Tooltip("Reference a variable data asset. Other objects can reference the same asset to change the value.")]
    private TVariable _referenced;

    public virtual TConstant Value {
      get {
        return _useLocal
            ? _local
            : _referenced.Value;
      }
      set {
        if (_useLocal) _local = value;
        else _referenced.Value = value;
      }
    }
  }
}