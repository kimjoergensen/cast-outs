using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace CastOuts.Shared.Utility {
    /// <summary>
    /// Prints error messages for the Assert library.
    /// </summary>
	public static class AssertUtility {
        /// <summary>
        /// Used with <see cref="Assert.IsTrue(bool)"/> to assert that <paramref name="asserted"/> is not null or empty.
        /// </summary>
        /// <example>
        /// <code>Assert.IsTrue(settings.name.NotEmpty(), AssertErrorMessage.NotEmpty(nameof(settings.name), gameObject))</code>
        /// </example>
        /// <param name="asserted"><see cref="string"/> to assert.</param>
        /// <returns>If <paramref name="asserted"/> is not null or empty.</returns>
        public static bool NotEmpty(this string asserted) {
            return !string.IsNullOrEmpty(asserted);
        }

        /// <summary>
        /// Used with <see cref="Assert.IsTrue(bool)"/> to assert that <paramref name="asserted"/> is not null or empty.
        /// </summary>
        /// <example>
        /// <code>Assert.IsTrue(settings.name.NotEmpty(), AssertErrorMessage.NotEmpty(nameof(settings.name), gameObject))</code>
        /// </example>
        /// <param name="asserted"><see cref="string"/> to assert.</param>
        /// <returns>If <paramref name="asserted"/> is not null or empty.</returns>
        public static bool NotEmpty<T>(this IEnumerable<T> asserted) {
            return asserted != null && asserted.Any();
        }

        /// <summary>
        /// Used with <see cref="Assert.IsTrue(bool)"/> to assert that <paramref name="asserted"/> is greater than <paramref name="expected"/>.
        /// </summary>
        /// <example>
        /// <code>Assert.IsTrue(settings.damage.GreaterThan(0.0f), AssertErrorMessage.GreaterThan(nameof(settings.damage), 0.0f, gameObject))</code>
        /// </example>
        /// <param name="asserted"><see cref="float"/> to assert.</param>
        /// <param name="expected"><see cref="float"/> value that <paramref name="asserted"/> should be greater than.</param>
        /// <returns>If <paramref name="asserted"/> is greater than <paramref name="expected"/>.</returns>
        public static bool GreaterThan(this float asserted, float expected) {
            return asserted > expected;
        }

        /// <summary>
        /// Used with <see cref="Assert.IsTrue(bool)"/> to assert that <paramref name="asserted"/> is greater than or equal to <paramref name="expected"/>.
        /// </summary>
        /// <example>
        /// <code>Assert.IsTrue(settings.damage.GreaterThanOrEqualTo(0.0f), AssertErrorMessage.GreaterThanOrEqualTo(nameof(settings.damage), 0.0f, gameObject))</code>
        /// </example>
        /// <param name="asserted"><see cref="float"/> to assert.</param>
        /// <param name="expected"><see cref="float"/> value that <paramref name="asserted"/> should be greater than or equal to.</param>
        /// <returns>If <paramref name="asserted"/> is greater than or equal to <paramref name="expected"/>.</returns>
        public static bool GreaterThanOrEqualTo(this float asserted, float expected) {
            return asserted >= expected;
        }

        /// <summary>
        /// Used with <see cref="Assert.IsTrue(bool)"/> to assert that <paramref name="asserted"/> is less than <paramref name="expected"/>.
        /// </summary>
        /// <example>
        /// <code>Assert.IsTrue(settings.damage.LessThan(100.0f), AssertErrorMessage.LessThan(nameof(settings.damage), 100.0f, gameObject))</code>
        /// </example>
        /// <param name="asserted"><see cref="float"/> to assert.</param>
        /// <param name="expected"><see cref="float"/> value that <paramref name="asserted"/> should be less than.</param>
        /// <returns>If <paramref name="asserted"/> is less than <paramref name="expected"/>.</returns>
        public static bool LessThan(this float asserted, float expected) {
            return asserted <= expected;
        }

        /// <summary>
        /// Used with <see cref="Assert.IsTrue(bool)"/> to assert that <paramref name="asserted"/> is less than or equal to <paramref name="expected"/>.
        /// </summary>
        /// <example>
        /// <code>Assert.IsTrue(settings.damage.LessThanOrEqual(100.0f), AssertErrorMessage.LessThanOrEqual(nameof(settings.damage), 100.0f, gameObject))</code>
        /// </example>
        /// <param name="asserted"><see cref="float"/> to assert.</param>
        /// <param name="expected"><see cref="float"/> value that <paramref name="asserted"/> should be less than or equal to.</param>
        /// <returns>If <paramref name="asserted"/> is less than or equal to <paramref name="expected"/>.</returns>
        public static bool LessThanOrEqualTo(this float asserted, float expected) {
            return asserted <= expected;
        }

        /// <summary>
        /// Used with <see cref="Assert.IsTrue(bool)"/> to assert that <paramref name="asserted"/> has a value between <paramref name="min"/> and <paramref name="max"/>.
        /// </summary>
        /// <example>
        /// <code>Assert.IsTrue(settings.damage.Between(0.0f, 100.0f), AssertErrorMessage.GreaterThan(nameof(settings.damage), 0.0f, 100.0f, gameObject))</code>
        /// </example>
        /// <param name="asserted"><see cref="float"/> to assert.</param>
        /// <param name="min">The minimum <see cref="float"/> value that <paramref name="asserted"/> should have.</param>
        /// <param name="max">The maximum <see cref="float"/> value that <paramref name="asserted"/> should have.</param>
        /// <returns>If <paramref name="asserted"/> has a value between <paramref name="min"/> and <paramref name="max"/>.</returns>
        public static bool Between(this float asserted, float min, float max) {
            return asserted >= min && asserted <= max;
        }
    }

    public static class AssertErrorMessage {
        public static string NotEmpty(string asserted, GameObject gameObject) {
            return $"{asserted} should not be empty on {gameObject.name}.";
        }

        public static string GreaterThan(string asserted, float expected, GameObject gameObject) {
            return $"{asserted} should have a value greater than {expected} on {gameObject.name}.";
        }

        public static string GreaterThanOrEqualTo(string asserted, float expected, GameObject gameObject) {
            return $"{asserted} should have a value greater than or equal to {expected} on {gameObject.name}.";
        }

        public static string LessThan(string asserted, float expected, GameObject gameObject) {
            return $"{asserted} should have a value less than {expected} on {gameObject.name}.";
        }

        public static string LessThanOrEqualTo(string asserted, float expected, GameObject gameObject) {
            return $"{asserted} should have a value less than or equal to {expected} on {gameObject.name}.";
        }

        public static string Between(string asserted, float min, float max, GameObject gameObject) {
            return $"{asserted} should have a value between {min} and {max} on {gameObject.name}.";
        }

        public static string ChildOf<T>(string asserted) {
            return $"{asserted} needs to be nested under a game object with the {typeof(T)} script attached.";
        }

        public static string ParentOf<T>(string asserted) {
            return $"{asserted} needs to have at least one nested game object with the {typeof(T)} script attached.";
        }

        public static string NotNull<T>(GameObject gameObject) {
            return $"{gameObject.name} is missing a component of type {typeof(T)}";
        }

        public static string NotNull<T>(string asserted, GameObject gameObject) {
            return $"A {typeof(T)} needs to be assigned to {asserted} on {gameObject.name}.";
        }
    }
}
