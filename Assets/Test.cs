using UnityEngine;
using Tween;

public class Test : MonoBehaviour
{
    public bool DoMove;
    public Vector3 TargetPosition;
    public float DoMoveSeconds;
    public Ease PositionEaseType = Ease.Linear;

    public bool DoScale;
    public Vector3 TargetScale = Vector3.one;
    public float DoScaleSeconds;
    public Ease ScaleEaseType = Ease.Linear;

    void Start()
    {
        if (DoMove)
            transform.DoMove(TargetPosition, DoMoveSeconds).SetEase(PositionEaseType);
        if (DoScale)
            transform.DoScale(TargetScale, DoScaleSeconds).SetEase(ScaleEaseType);
    }
}
