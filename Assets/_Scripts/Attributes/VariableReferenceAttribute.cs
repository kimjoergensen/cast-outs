using System;
using UnityEngine;

namespace CastOuts.Attributes {
    /// <summary>
    /// Attribute applied to <see cref="VariableReferences.VariableReferenceBase{TConstant, TVariable}"/>
    /// to draw the properties of the class on a single line.
    /// </summary>
    /// <seealso cref="PropertyAttribute" />
    [AttributeUsage(AttributeTargets.Class)]
    public class VariableReferenceAttribute : PropertyAttribute { }
}
