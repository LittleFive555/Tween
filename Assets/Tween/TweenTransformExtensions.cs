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
            // ����Ѿ�����ִ�е�DoMove������ɱ������ִ���µ�
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
