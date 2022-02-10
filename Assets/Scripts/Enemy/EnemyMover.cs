using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : EnemyMoverBase
{

    private Tween tween;

    public override void SetStartValue()
    {
        gameObject.transform.position = data.Start;
    }

    public override void StartMove()
    {
        tween = transform.DOPath(data.GetArrVectors(), 1/speed, PathType.Linear, PathMode.Full3D, gizmoColor: Color.green).SetEase(Ease.Linear).SetAutoKill(true);
    }

    public override void StopMove() 
    {
        tween.Kill();
    }
}
