using System;
using UnityEngine;

namespace Fofanius.Types
{
    [Serializable]
    public struct Range : IEquatable<Range>
    {
        [SerializeField] private float _a;
        [SerializeField] private float _b;

        public float A
        {
            get => _a;
            set => _a = Mathf.Min(value, _b);
        }

        public float B
        {
            get => _b;
            set => _b = Mathf.Max(value, _a);
        }

        /// <summary>
        /// Length of the range.
        /// </summary>
        public float Lenght => Mathf.Max(B - A, 0f);

        public Range(float a, float b)
        {
            if (b < a) throw new ArgumentException($"Invalid arguments! B ({b}) cannot be less then A({a})!");

            _a = a;
            _b = b;
        }

        /// <summary>
        /// Generates random number in range [<see cref="Range.A"/>..<see cref="Range.B"/>] using <see cref="UnityEngine.Random.Range(float, float)"/>
        /// </summary>
        /// <returns>Generated random nubmer.</returns>
        public float GetRandom() => UnityEngine.Random.Range(A, B);

        /// <summary>
        /// Clamps <paramref name="value"/> between <see cref="Range.A"/> and <see cref="Range.B"/> using <see cref="UnityEngine.Mathf.Clamp(float, float, float)"/>.
        /// </summary>
        /// <param name="value">Value to clamp</param>
        /// <returns>Clamped value.</returns>
        public float Clamp(float value) => Mathf.Clamp(value, A, B);

        /// <summary>
        /// Returns limearly interpolated value between <see cref="Range.A"/> and <see cref="Range.B"/> by <paramref name="t"/> using <see cref="UnityEngine.Mathf.Lerp(float, float, float)"/>.
        /// </summary>
        /// <param name="t">Interpolation value [0f..1f].</param>
        /// <returns>Interpolation result.</returns>
        public float Lerp(float t) => Mathf.Lerp(A, B, t);

        #region IEquatable

        public bool Equals(Range other)
        {
            return _a.Equals(other._a) && _b.Equals(other._b);
        }

        public override bool Equals(object obj)
        {
            return obj is Range other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_a, _b);
        }

        #endregion
    }
}
