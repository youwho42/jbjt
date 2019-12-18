using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum BattleState
{
    Start,
    PlayerTurn,
    EnemyTurn,
    Win,
    Lose
}

public class BattleSystem : MonoBehaviour
{
    public Unit player;
    int enemyAmountThisRound;

    public List<BattleSequence> battleSequences = new List<BattleSequence>();
    int battleNumber;

    

    public GameObject battleUI;
    public BattleHUD playerHUD;
    public BattleHUD[] enemyHUD;

    public TMP_Text dialogText;

    public BattleState state;

    private void Start()
    {
        state = BattleState.Start;
        
    }

    public void StartBattle()
    {
        StartCoroutine(SetUpBattle(battleNumber));
    }

    IEnumerator SetUpBattle(int battleNum)
    {
        playerHUD.SetHUD(player);
        playerHUD.SetHP(player.currentHP);
        
        int enemyAmount = battleSequences[battleNum].enemyUnits.Length;
        enemyAmountThisRound = enemyAmount;
        for (int i = 0; i < enemyAmount; i++)
        {
            GameObject go = Instantiate(battleSequences[battleNum].enemyUnits[i], transform);
            enemyHUD[i].gameObject.SetActive(true);
            enemyHUD[i].SetHUD(go.GetComponent<Unit>());
            enemyHUD[i].SetHP(enemyHUD[i].enemyUnit.maxHP);
        }
        
        

        dialogText.text = battleSequences[battleNum].battleDescription;

        yield return new WaitForSeconds(3f);

        state = BattleState.PlayerTurn;
        PlayerTurn();
    }

    

    private void PlayerTurn()
    {
        dialogText.text = "Choose an action...";
    }

    public void OnAttackCardA()
    {
        if(state != BattleState.PlayerTurn)
        {
            return;
        }
        StartCoroutine(PlayerAttack(enemyHUD[0]));
    }
    public void OnAttackCardB()
    {
        if (state != BattleState.PlayerTurn)
        {
            return;
        }
        StartCoroutine(PlayerAttack(enemyHUD[1]));
    }
    public void OnAttackCardC()
    {
        if (state != BattleState.PlayerTurn)
        {
            return;
        }
        StartCoroutine(PlayerAttack(enemyHUD[2]));
    }

    public void OnHeal()
    {
        if (state != BattleState.PlayerTurn)
        {
            return;
        }
        StartCoroutine(PlayerHeal());
    }

    IEnumerator PlayerHeal()
    {
        player.HealDamage(25);
        playerHUD.SetHP(player.currentHP);
        dialogText.text = "You healed! That feels good!";
        yield return new WaitForSeconds(3f);

        state = BattleState.EnemyTurn;
        StartCoroutine(EnemyAttack());
    }

    IEnumerator PlayerAttack(BattleHUD battleHUD)
    {
        bool missed;
        int finalDamage;
        bool isDead = battleHUD.enemyUnit.TakeDamage(player.damage.GetValue(), out missed, out finalDamage);
        battleHUD.SetHP(battleHUD.enemyUnit.currentHP);
        if (missed == true)
        {
            dialogText.text = "You missed!";
        }
        else
        {
            dialogText.text = "Attack successful! You struck for " + finalDamage + " damage!";
        }
        

        yield return new WaitForSeconds(3f);

        if (isDead)
        {
            enemyAmountThisRound--;
            if (enemyAmountThisRound <= 0)
            {
                state = BattleState.Win;
                StartCoroutine(EndBattle());
            }
            else
            {
                state = BattleState.EnemyTurn;
                StartCoroutine(EnemyAttack());
            }
            

        }
        else
        {
            state = BattleState.EnemyTurn;
            StartCoroutine(EnemyAttack());
        }
    }

    

    IEnumerator EnemyAttack()
    {
        int enemyAmount = battleSequences[battleNumber].enemyUnits.Length;
        for (int i = 0; i < enemyAmount; i++)
        {
            if (enemyHUD[i].enemyUnit.currentHP <= 0)
                continue;

            dialogText.text = enemyHUD[i].enemyUnit.unitName + " attacks!";
            yield return new WaitForSeconds(2f);
            bool missed;
            int finalDamage;
            bool isDead = player.TakeDamage(enemyHUD[i].enemyUnit.damage.GetValue(), out missed, out finalDamage);
            
            playerHUD.SetHP(player.currentHP);
            if(missed == true)
            {
                dialogText.text = enemyHUD[i].enemyUnit.unitName + " missed!";
            }
            else
            {
                dialogText.text = enemyHUD[i].enemyUnit.unitName + " hit you right in the smacker dealing " + finalDamage + " damage!";
            }
            yield return new WaitForSeconds(2f);
            if (isDead)
            {
                state = BattleState.Lose;
                StartCoroutine(EndBattle());
                yield break;
            }
            
        }

        
        state = BattleState.PlayerTurn;
        PlayerTurn();
    
    }

    IEnumerator EndBattle()
    {
        if(state == BattleState.Win)
        {
            dialogText.text = "Way to go!";
            battleNumber++;
            if (battleNumber < battleSequences.Count)
            {
                StartBattle();
            }
            else
            {
                dialogText.text = "You defeated all the enemies!";
            }
            
        } else if (state == BattleState.Lose)
        {
            dialogText.text = "You were defeated!";
        }

        yield return new WaitForSeconds(3f);

        if (battleNumber >= battleSequences.Count)
        {
            dialogText.text = "Please wait for transfer...";
            // Change to next mini game
        }



    }

    
}
