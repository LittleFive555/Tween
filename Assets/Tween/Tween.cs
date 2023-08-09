using UnityEngine;

namespace EasyTween
{
    public abstract class Tween
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        protected float _startTime;
        /// <summary>
        /// 总时间
        /// </summary>
        protected float _duration;
        public bool IsPlaying { get; protected set; }
        public bool IsKilled { get; protected set; }
        public object Target { get; protected set; }

        public Tween(Transform target, float duration)
        {
            Target = target;
            _duration = duration;
        }

        public abstract void Play();

        public abstract void Update();

        public abstract void Kill();
    }
}
