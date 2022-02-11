using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float timeBetweenEnemies = 0.1f;
    //чтобы можно было выбирать кого делать лучше, а кого нет
    [SerializeField]
    private List<EnemyData> enemyDatas;


    private string path = Application.streamingAssetsPath;
    private int xValue;
    private int timeValue;
    private void Awake()
    {
        SetValuesFromText();
    }

    void Start()
    {
        StartCoroutine(MoveEnemy());
        foreach (var item in enemyDatas)
        {
            item.SetDefault();
        }
    }

    IEnumerator MoveEnemy() 
    {
        int k = 0;
        while (true)
        {
            k++;
            int numberOfOpponents = Random.Range(k, k + xValue+1);
            for (int i = 0; i < numberOfOpponents; i++)
            {
                ObjectPooler.Instance.GetPoolObjectByName("Enemy");
                //чтобы красиво шли
                yield return new WaitForSeconds(timeBetweenEnemies);
            }
            foreach (var item in enemyDatas)
            {
                item.Upgrade();
            }
            yield return new WaitForSeconds(timeValue);
        }
    }

    private void SetValuesFromText() 
    {
        var json = File.ReadAllText(path + "/textData.json");
        var data = JsonUtility.FromJson<TextData>(json);
        xValue = data.X;
        timeValue = data.Time;
    }
    private class TextData 
    {
        public int X;
        public int Time;
    }
}

