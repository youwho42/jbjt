using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiateBattle : MonoBehaviour
{

    public BattleSystem battleSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Unit enemy = collision.gameObject.GetComponent<Unit>();
            //battleSystem.StartBattle(enemy);
        }
    }
}
