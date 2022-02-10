using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : GunBase
{
    [SerializeField]
    protected Transform movablePart;
    [SerializeField]
    protected int coefficientDamage;
    [SerializeField]
    protected int coefficientRateOfFire;

    protected override Enemy FindEnemy() 
    {
        return Physics2D.OverlapCircle(transform.position, maxDistance)?.GetComponent<Enemy>();
    }
    
    protected override int GetShotDamege()=>
        data.GetDamage() * coefficientDamage;

    protected override float RateOfFire() =>
        data.GetRateOfFire() / coefficientRateOfFire;

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, maxDistance);

        if (currrentEnemy != null) 
        {
            Gizmos.DrawLine(transform.position, currrentEnemy.transform.position);
        }
    }
#endif

    public void Upgrade(int upgrade) 
    {
        coefficientDamage *= upgrade;
        coefficientRateOfFire *= upgrade;
    }

    protected override void LookAtEnemy()
    {
        Vector3 dir = currrentEnemy.transform.position - transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
