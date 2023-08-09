using System;
using UnityEngine;

namespace EasyTween
{
    public enum Ease
    {
        Linear,
        EaseInSine,
        EaseOutSine,
        EaseInOutSine,
        EaseInBack,
        EaseOutBack,
        EaseInOutBack,
    }

    public static class EaseFunctions
    {
        public static Func<float, float> GetEaseFunc(Ease ease)
        {
            switch (ease)
            {
                case Ease.Linear:
                    return Linear;
                case Ease.EaseInSine:
                    return EaseInSine;
                case Ease.EaseOutSine:
                    return EaseOutSine;
                case Ease.EaseInOutSine:
                    return EaseInOutSine;
                case Ease.EaseInBack:
                    return EaseInBack;
                case Ease.EaseOutBack:
                    return EaseOutBack;
                case Ease.EaseInOutBack:
                    return EaseInOutBack;
                default:
                    return Linear;
            }
        }

        public static float Linear(float x)
        {
            return x;
        }

        public static float EaseInSine(float x)
        {
            return 1 - Mathf.Cos((x * Mathf.PI) / 2);
        }

        public static float EaseOutSine(float x)
        {
            return Mathf.Sin((x * Mathf.PI) / 2);

        }

        public static float EaseInOutSine(float x)
        {
            return -(Mathf.Cos(Mathf.PI * x) - 1) / 2;
        }

        public static float EaseInBack(float x)
        {
            float c1 = 1.70158f;
            float c3 = c1 + 1f;

            return c3 * x * x * x - c1 * x * x;
        }

        public static float EaseOutBack(float x)
        {
            float c1 = 1.70158f;
            float c3 = c1 + 1f;

            return 1 + c3 * Mathf.Pow(x - 1, 3) + c1 * Mathf.Pow(x - 1, 2);

        }

        public static float EaseInOutBack(float x)
        {
            float c1 = 1.70158f;
            float c2 = c1 * 1.525f;

            return x < 0.5
                ? (Mathf.Pow(2 * x, 2) * ((c2 + 1) * 2 * x - c2)) / 2
                : (Mathf.Pow(2 * x - 2, 2) * ((c2 + 1) * (x * 2 - 2) + c2) + 2) / 2;
        }
    }
}
