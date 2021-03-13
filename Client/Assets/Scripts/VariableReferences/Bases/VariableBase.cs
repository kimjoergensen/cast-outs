namespace Assets.Scripts.VariableReferences.Bases
{
  using UnityEngine;

  public abstract class VariableBase<T> : ScriptableObject, IVariableReference<T> where T : struct
  {
    [SerializeField]
    [Tooltip("Set the default value.")]
    private T _value;
    public T Value { get => _value; set => _value = value; }
  }

  public interface IVariableReference<T>
  {
    public T Value { get; set; }
  }
}