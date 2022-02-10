using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunBase : MonoBehaviour
{
    [SerializeField]
    protected GunData data;
    [SerializeField]
    protected float maxDistance;
    protected Enemy currrentEnemy;
    protected bool findEnemy;

    protected virtual void Start()
    {
        StartCoroutine(Shot());
    }

    protected virtual void FixedUpdate()
    {
        if (currrentEnemy != null)
        {

            if (Vector2.Distance(transform.position, currrentEnemy.transform.position) > maxDistance)
                currrentEnemy = null;
            else
            {
                LookAtEnemy();
            }
        }
        else
            currrentEnemy = FindEnemy();
    }


    IEnumerator Shot() 
    {
        while (true)
        {
            currrentEnemy = FindEnemy();
            if (currrentEnemy != null) 
            {
                currrentEnemy.TakeDamage(GetShotDamege());
                yield return new WaitForSeconds(RateOfFire());
            }
            else
                yield return null;
        }
    }

    protected abstract Enemy FindEnemy();

    protected abstract int GetShotDamege();

    protected abstract float RateOfFire();

    protected abstract void LookAtEnemy();

}
