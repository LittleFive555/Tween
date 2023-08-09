using System;
using UnityEngine;

namespace EasyTween
{
    public class Vector3Tweener : Tween
    {
        protected Vector3 _startValue;
        protected Vector3 _endValue;
        private DoGetter<Vector3> _getter;
        private DOSetter<Vector3> _setter;
        private Ease _easeType;
        private Func<float, float> _easeFunction;

        public Vector3Tweener(Transform target, Vector3 endValue, float duration, DoGetter<Vector3> getter, DOSetter<Vector3> setter) : base(target, duration)
        {
            _endValue = endValue;
            _getter = getter;
            _setter = setter;
            _easeType = Ease.Linear;
            _easeFunction = EaseFunctions.GetEaseFunc(_easeType);
        }

        /// <summary>
        /// 设置动画曲线，只有在开始播放前设置才生效
        /// </summary>
        /// <param name="ease"></param>
        /// <returns></returns>
        public Vector3Tweener SetEase(Ease ease)
        {
            if (IsPlaying)
                return this;
            _easeType = ease;
            _easeFunction = EaseFunctions.GetEaseFunc(ease);
            return this;
        }

        public override void Play()
        {
            _startValue = _getter.Invoke();
            _startTime = Time.realtimeSinceStartup;
            IsPlaying = true;
        }

        public override void Update()
        {
            if (!IsPlaying || IsKilled)
                return;

            var currentTime = Time.realtimeSinceStartup;
            var deltaTime = currentTime - _startTime;
            if (deltaTime < _duration)
            {
                Vector3 value = _startValue + _easeFunction.Invoke(deltaTime / _duration) * (_endValue - _startValue);
                _setter.Invoke(value);
            }
            else
            {
                Kill();
            }
        }

        public override void Kill()
        {
            IsKilled = true;
        }
    }
}
