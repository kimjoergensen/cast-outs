namespace CastOuts.VariableReferences {
    /// <summary>
    /// Base class for all VariableReference.
    /// </summary>
    /// <example>
    /// <code>
    /// [Serializable]
    /// public class Vector3Reference : VariableReferenceBase {
    ///    private Vector3 _constantValue;
    ///    public override object ConstantValue => _constantValue;
    ///
    ///    private Vector3Variable _variable;
    ///    public override object Variable => _variable;
    ///
    ///    public override object Value => UseConstant ? _constantValue : _variable.Value;
    /// }
    /// </code>
    /// </example>
    public abstract class VariableReferenceBase {
        public bool UseConstant = true;

        public abstract object ConstantValue { get; }
        public abstract object Variable { get; }
        public abstract object Value { get; }
    }
}
