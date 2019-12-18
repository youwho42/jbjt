using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{

    public static RespawnPlayer instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public Transform player;
    public Transform respawnPoint;
    public float respawnTime;
    public bool isRespawning;

    public void StartRespawn()
    {
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {

        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnTime);
        player.position = respawnPoint.position;
        isRespawning = false;
        player.gameObject.SetActive(true);
        
    }
}
