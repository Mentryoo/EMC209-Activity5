using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBlock : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerInfo>())
        {
            collision.GetComponent<PlayerInfo>().DamagePlayer(10);
        }
    }
}
