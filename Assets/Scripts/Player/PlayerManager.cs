using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : PlayerBase
{
    //даем возможность разных вариантов получения денег и урона(есть возможность сделать получения урона невозможным в определенное время и тд)
    public override void TakeDamage(int damage) 
    {
        Lives -= damage;
    }

    public override void TakeMoney(int coins, bool forDeathEnemy) 
    {
        if (forDeathEnemy)
            deathCounter++;
        Money += coins;
    }
}
