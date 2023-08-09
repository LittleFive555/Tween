using UnityEngine;

namespace EasyTween
{
    public class TweenComponent : MonoBehaviour
    {
        private static TweenComponent _instance;
        public static TweenComponent Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject go = new GameObject();
                    _instance = go.AddComponent<TweenComponent>();
                    DontDestroyOnLoad(go);
                }
                return _instance;
            }
        }

        private void Update()
        {
            var tweens = DoTween.GetActiveTweens();
            foreach (var tween in tweens)
            {
                if (!tween.IsPlaying)
                    tween.Play();
                tween.Update();
            }
        }
    }
}
