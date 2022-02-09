using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        var enemy=collision.gameObject.GetComponent<Enemy>();
        enemy.OnFinishMove();
    }
}
