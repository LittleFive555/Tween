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

        public void SetEase(Ease ease)
        {
            _easeType = ease;
            _easeFunction = EaseFunctions.GetEaseFunc(ease);
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
