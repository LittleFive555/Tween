using System.Collections;
using UnityEngine;
using EasyTween;

public class Test : MonoBehaviour
{
    #region DoMove

    [Tooltip("�Ƿ�ִ��DoMove")]
    public bool DoMove;

    [Tooltip("DoMove��Ŀ��λ��")]
    public Vector3 TargetPosition;

    [Min(0f)]
    [Tooltip("DoMove�ĳ���ʱ�䣬��λΪ��")]
    public float DoMoveSeconds;

    [Tooltip("DoMove����������")]
    public Ease PositionEaseType = Ease.Linear;

    [Tooltip("�Ƿ���һ��ʱ�����������DoMove")]
    public bool KillMoveOnTime;

    [Min(0f)]
    [Tooltip("��������DoMove��ʱ�䣬��λΪ��")]
    public float KillMoveDelaySeconds;

    #endregion

    #region DoScale

    [Tooltip("�Ƿ�ִ��DoScale")]
    public bool DoScale;

    [Tooltip("DoScale��Ŀ���С")]
    public Vector3 TargetScale = Vector3.one;

    [Min(0f)]
    [Tooltip("DoScale�ĳ���ʱ�䣬��λΪ��")]
    public float DoScaleSeconds;

    [Tooltip("DoScale����������")]
    public Ease ScaleEaseType = Ease.Linear;

    [Tooltip("�Ƿ���һ��ʱ�����������DoScale")]
    public bool KillScaleOnTime;

    [Min(0f)]
    [Tooltip("��������DoScale��ʱ�䣬��λΪ��")]
    public float KillScaleDelaySeconds;

    #endregion

    private Tween _moveTween;
    private Tween _scaleTween;

    void Start()
    {
        if (DoMove)
        {
            _moveTween = transform.DoMove(TargetPosition, DoMoveSeconds).SetEase(PositionEaseType);
            if (KillMoveOnTime)
                StartCoroutine(DelayKill(_moveTween, KillMoveDelaySeconds));
        }
        if (DoScale)
        {
            _scaleTween = transform.DoScale(TargetScale, DoScaleSeconds).SetEase(ScaleEaseType);
            if (KillScaleOnTime)
                StartCoroutine(DelayKill(_scaleTween, KillScaleDelaySeconds));
        }
    }

    private IEnumerator DelayKill(Tween tween, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        tween.Kill();
    }
}
