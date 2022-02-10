using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IPoolObject
{
    [SerializeField]
    private EnemyData data;
    [SerializeField]
    private EnemyMoverBase enemyMover;

    private int health;

    private void Awake()
    {
        SetStartValue();
    }
    protected virtual void SetStartValue()
    {
        enemyMover.SetStartValue();
        health = data.GetMaxHealth();
        gameObject.SetActive(true);
    }
    public virtual void GetFromPool()
    {
        SetStartValue();
        StartMove();
    }
    public virtual void ReturnToPool()
    {
        enemyMover.StopMove();
        gameObject.SetActive(false);
    }
    public void TakeDamage(int damage) 
    {
        health-=damage;
        if (health <= 0) 
        {
            Death();
        }
        Debug.Log(health);
    }
    public void StartMove() 
    {
        enemyMover.StartMove();
    }
    protected virtual void Death() 
    {
        enemyMover.StopMove();
        ReturnToPool();
    }
    public virtual void OnFinishMove() 
    {
        ReturnToPool();
    }
    public int GetDanageValue() =>
        data.GetDamage();
    public int GetCoints() =>
        data.GetCoinsForDeath();
}
