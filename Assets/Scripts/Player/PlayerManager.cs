using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : PlayerBase
{
    public void Start()
    {
        ChangeLiveValueEvent?.Invoke(Lives);
        ChangeMoneyEvent?.Invoke(Money);
    }
    public override bool CanSpendMoney(int coins)
    {
        if (Money>=coins) 
        {
            Money -= coins;
            return true;

        }
        Debug.Log("����� �� �������");
        return false;
    }

    //���� ����������� ������ ��������� ��������� ����� � �����(���� ����������� ������� ��������� ����� ����������� � ������������ ����� � ��)
    public override void TakeDamage(int damage) 
    {
        Lives -= damage;
    }

    public override void TakeMoney(int coins) 
    {
        Money += coins;
    }
}
