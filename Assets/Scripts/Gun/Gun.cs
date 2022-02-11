using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Gun : GunBase
{
    [SerializeField]
    protected Transform movablePart;
    [SerializeField]
    protected int coefficientDamage;
    [SerializeField]
    protected int coefficientRateOfFire;
    [SerializeField]
    protected TextMeshProUGUI text;
    [SerializeField]
    protected int priceUpgrade=2;

    protected override void Start()
    {
        base.Start();
        text.text = "Upgrade Price: " + priceUpgrade;
    }
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
        if (player.CanSpendMoney(priceUpgrade))
        {
            coefficientDamage *= upgrade;
            coefficientRateOfFire *= upgrade;
            priceUpgrade *= 2;
            text.text = "Upgrade Price: " + priceUpgrade;
        }
    }

    protected override void LookAtEnemy()
    {
        Vector3 dir = currrentEnemy.transform.position - movablePart.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        movablePart.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    protected override void Upgrade()
    {
        Upgrade(2);
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        text.gameObject.SetActive(true);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        text.gameObject.SetActive(false);
    }
}
