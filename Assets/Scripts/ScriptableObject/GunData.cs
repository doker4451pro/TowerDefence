using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GunData", menuName = "Gun Data", order = 51)]
public class GunData : ScriptableObject
{
    [SerializeField]
    private int damage;
    [SerializeField]
    private float rateOfFire;

    public int GetDamage() =>
        damage;
    public float GetRateOfFire() =>
        rateOfFire;
}
