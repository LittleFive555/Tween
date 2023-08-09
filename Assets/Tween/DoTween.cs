using System.Collections.Generic;
using UnityEngine;

namespace EasyTween
{
    public class DoTween
    {
        private static bool _isInit = false;

        private static List<Tween> _tweens = new List<Tween>();

        public static Vector3Tweener DoVector3(Transform target, Vector3 endValue, float duration, DoGetter<Vector3> getter, DOSetter<Vector3> setter)
        {
            InitCheck();
            var tween = new Vector3Tweener(target, endValue, duration, getter, setter); // TODO 对象池
            _tweens.Add(tween);
            return tween;
        }

        public static void Kill(Transform target)
        {
            for (int i = 0; i < _tweens.Count; i++)
            {
                if (_tweens[i].Target == target)
                    _tweens[i].Kill();
            }
        }

        public static List<Tween> GetActiveTweens()
        {
            List<Tween> activeTweens = new List<Tween>();
            for (int i = 0; i < _tweens.Count; i++)
            {
                var tween = _tweens[i];
                if (!tween.IsKilled)
                    activeTweens.Add(tween);
                else
                {
                    _tweens.Remove(tween); // TODO 对象池
                    i--;
                }
            }
            return activeTweens;
        }

        private static void InitCheck()
        {
            if (!_isInit)
            {
                GameObject go = new GameObject();
                go.AddComponent<TweenComponent>();
                Object.DontDestroyOnLoad(go);
            }
        }
    }
}
