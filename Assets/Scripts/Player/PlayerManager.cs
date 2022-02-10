using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : PlayerBase
{
    //���� ����������� ������ ��������� ��������� ����� � �����(���� ����������� ������� ��������� ����� ����������� � ������������ ����� � ��)
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
