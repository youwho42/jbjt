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
    public Transform startGameRespawnPoint;
    public float respawnTime;
    public bool isRespawning;

    public void StartRespawn(bool restartGame)
    {
        if (!restartGame)
        {
            StartCoroutine(Respawn(respawnPoint));
        }
        else
        {
            StartCoroutine(Respawn(startGameRespawnPoint));
        }
        
    }
    

    IEnumerator Respawn(Transform transform)
    {

        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnTime);
        player.position = transform.position;
        isRespawning = false;
        player.gameObject.SetActive(true);
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerHealth>().tookDamage = false;
        
    }
}
