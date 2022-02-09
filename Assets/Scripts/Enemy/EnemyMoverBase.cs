using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMoverBase : MonoBehaviour
{
    [SerializeField]
    protected RouteData data;
    [SerializeField]
    protected float speed;

    public abstract void StartMove();
    public abstract void StopMove();
    public abstract void SetStartValue();
}
