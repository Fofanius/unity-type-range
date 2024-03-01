using System;
using UnityEngine;

namespace Fofanius.Types
{
    [Serializable]
    public struct Range
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

        public float Lenght => Mathf.Max(B - A, 0f);

        public Range(float a, float b)
        {
            _a = a;
            _b = b;
        }
    }
}
