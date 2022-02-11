using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class GunBase : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField]
    protected GunData data;
    [SerializeField]
    protected float maxDistance;
    protected Enemy currrentEnemy;
    protected bool findEnemy;
    protected PlayerBase player;

    protected virtual void Start()
    {
        player = Dispenser.Instance.GetPlayer();
        StartCoroutine(Shot());
    }

    protected virtual void Update()
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

    protected abstract void Upgrade();
    public abstract void OnPointerEnter(PointerEventData eventData);
    public abstract void OnPointerExit(PointerEventData eventData);

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        Upgrade();
    }


}
