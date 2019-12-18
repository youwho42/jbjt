using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int level;

    public Stat damage;
    public Stat defense;
    public Stat luck;

    public int maxHP;
    public int currentHP;

    public Sprite unitSprite;

    private void Start()
    {
        currentHP = maxHP;
    }

    public bool TakeDamage(int damageAmount, out bool missed, out int finalDamage)
    {
        float missChance = Mathf.InverseLerp(0, 100, luck.GetValue());
        int randomMiss = Random.Range(0, 100);
        float missPercent = Mathf.InverseLerp(0, 100, randomMiss);
        if(missPercent <= missChance)
        {
            missed = true;
            finalDamage = 0;
            return false;
        }
        missed = false;
        damageAmount -= defense.GetValue();
        damageAmount = Mathf.Clamp(damageAmount, 0, damageAmount);
        finalDamage = damageAmount;
        currentHP -= finalDamage;

        if(currentHP <= 0)
        {
            return true;
        }
        return false;
    }

    public void HealDamage(int healAmount)
    {
        currentHP += healAmount;

        if (currentHP >= maxHP)
        {
            currentHP = maxHP;
        }
        
    }
}
