using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New EnemyData", menuName = "Enemy Data", order = 51)]
public class EnemyData : ScriptableObject
{
    [SerializeField]
    private int maxhealth;
    [SerializeField]
    private int damage;
    [SerializeField]
    private int coinsForDeath;
    [SerializeField]
    private int changes;

    private int currentMaxHealth;
    private int currentDamage;
    private int currentcoinsForDeath;

    public int GetMaxHealth() =>
        currentMaxHealth;
    public int GetDamage() =>
        currentDamage;
    public int GetCoinsForDeath() =>
        currentcoinsForDeath;
    
    public void Upgrade() 
    {
        currentMaxHealth += Random.Range(0, changes + 1);
        currentDamage += Random.Range(0, changes + 1);
        currentcoinsForDeath += Random.Range(0, changes + 1);
        Debug.Log(currentMaxHealth);
    }
    public void SetDefault() 
    {
        currentcoinsForDeath = coinsForDeath;
        currentDamage = damage;
        currentMaxHealth = maxhealth;
    }
}
