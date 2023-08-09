using System.Collections;
using UnityEngine;
using EasyTween;

public class Test : MonoBehaviour
{
    #region DoMove

    [Tooltip("是否执行DoMove")]
    public bool DoMove;

    [Tooltip("DoMove的目标位置")]
    public Vector3 TargetPosition;

    [Min(0f)]
    [Tooltip("DoMove的持续时间，单位为秒")]
    public float DoMoveSeconds;

    [Tooltip("DoMove的曲线类型")]
    public Ease PositionEaseType = Ease.Linear;

    [Tooltip("是否在一定时间后主动结束DoMove")]
    public bool KillMoveOnTime;

    [Min(0f)]
    [Tooltip("主动结束DoMove的时间，单位为秒")]
    public float KillMoveDelaySeconds;

    #endregion

    #region DoScale

    [Tooltip("是否执行DoScale")]
    public bool DoScale;

    [Tooltip("DoScale的目标大小")]
    public Vector3 TargetScale = Vector3.one;

    [Min(0f)]
    [Tooltip("DoScale的持续时间，单位为秒")]
    public float DoScaleSeconds;

    [Tooltip("DoScale的曲线类型")]
    public Ease ScaleEaseType = Ease.Linear;

    [Tooltip("是否在一定时间后主动结束DoScale")]
    public bool KillScaleOnTime;

    [Min(0f)]
    [Tooltip("主动结束DoScale的时间，单位为秒")]
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
