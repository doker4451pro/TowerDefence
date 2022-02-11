using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    protected TextMeshProUGUI livesText;
    [SerializeField]
    protected TextMeshProUGUI coinsText;
    [SerializeField]
    protected EndMenu endMenu;

    public void SetCoinsValue(int coins) 
    {
        coinsText.text = "Coints: " + coins;
    }

    public void SetLives(int values) 
    {
        livesText.text = "Lives: "+values;
    }

    public void DeathPlayerMenu() 
    {
        livesText.text = "Lives: " + 0;
        endMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
