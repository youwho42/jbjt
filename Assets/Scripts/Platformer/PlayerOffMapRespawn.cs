using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOffMapRespawn : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !RespawnPlayer.instance.isRespawning)
        {
            RespawnPlayer.instance.isRespawning = true;
            RespawnPlayer.instance.StartRespawn();
        }
    }

}
