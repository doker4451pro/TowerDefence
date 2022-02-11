using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    protected Dictionary<string, int> statsDisc;
    protected int countDeadEnemy;
    #region Singleton
    public static Stats Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        statsDisc = new Dictionary<string, int>();
    }
    #endregion

    public void SetStaticByName(string name, int count) 
    {
        if (!CheakName(name))
        {
            statsDisc.Add(name, count);
        }
        statsDisc[name] += count;
    }
    public int? GetStaticValueByName(string name) 
    {
        if (!CheakName(name))
            return null;
        return statsDisc[name];
    }

    protected bool CheakName(string name) 
    {
        if (!statsDisc.ContainsKey(name))
        {
            Debug.Log("Не такого имени в статистике");
            return false;
        }
        return true;
    }
}
