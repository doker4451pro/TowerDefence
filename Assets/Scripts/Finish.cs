using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    //чтобы было больше одной базы
    [SerializeField]
    private PlayerBase player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        var enemy=collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.OnFinishMove();
            player.TakeDamage(enemy.GetDanageValue());
        }
    }
}
