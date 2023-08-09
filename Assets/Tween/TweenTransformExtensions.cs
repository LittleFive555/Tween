using System.Collections;
using UnityEngine;

namespace EasyTween
{
    public delegate T DoGetter<out T>();
    public delegate void DOSetter<in T>(T newValue);

    public static class TweenTransformExtensions
    {
        public static Vector3Tweener DoMove(this Transform target, Vector3 endValue, float duration)
        {
            // 如果已经有在执行的DoMove，则先杀掉，再执行新的
            return DoTween.DoVector3(target, endValue, duration, () => target.position, (newValue) => target.position = newValue);
        }

        public static Vector3Tweener DoScale(this Transform target, Vector3 endValue, float duration)
        {
            return DoTween.DoVector3(target, endValue, duration, () => target.localScale, (newValue) => target.localScale = newValue);
        }

        public static void DoKill(this Transform target)
        {
            DoTween.Kill(target);
        }
    }
}
