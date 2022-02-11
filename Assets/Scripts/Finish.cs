using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private PlayerBase player;
    private void Start()
    {
        player = Dispenser.Instance.GetPlayer();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy=collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.OnFinishMove();
            player.TakeDamage(enemy.GetDanageValue());
        }
    }
}
