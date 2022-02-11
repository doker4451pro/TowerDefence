using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : MonoBehaviour
{
    public static Dispenser Instance { get; protected set; }
    [SerializeField]
    protected PlayerBase player;
    [SerializeField]
    protected UIManager uI;

    private void Awake()
    {
        Instance = this;
    }

    public PlayerBase GetPlayer() =>
        player;
    public UIManager GetUIManager() =>
        uI;

}
