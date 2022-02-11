using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    public void StartAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void OnEnable()
    {
        text.text = "Dead enemys: " + Stats.Instance.GetStaticValueByName("DeadEnemy");
    }
}
