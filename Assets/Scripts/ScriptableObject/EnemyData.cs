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

    public int GetMaxHealth() =>
        maxhealth;
    public int GetDamage() =>
        damage;
    public int GetCoinsForDeath() =>
        coinsForDeath;

    public void Upgrade() 
    {
        maxhealth += Random.Range(0, changes + 1);
        damage += Random.Range(0, changes + 1);
        coinsForDeath += Random.Range(0, changes + 1);
    }
}
