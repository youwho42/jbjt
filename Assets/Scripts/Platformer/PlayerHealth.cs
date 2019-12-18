using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable<int>
{
    public int maxHealth;
    public int currentHealth { get; private set; }
    public bool tookDamage;

    private void Start()
    {
        ResetPlayerHealth();
    }
    
    
    public void Damage(int damageTaken)
    {
        if (!tookDamage)
        {
            tookDamage = true;
            currentHealth -= damageTaken;
            if (currentHealth <= 0)
            {
                Kill();
            } else
            {
                StartCoroutine(BecomeUndamagable());
            }

        }
        
    }

    void ResetPlayerHealth()
    {
        tookDamage = false;
        currentHealth = maxHealth;
    }

    public void Kill()
    {
        RespawnPlayer.instance.StartRespawn();
        ResetPlayerHealth();
    }

    IEnumerator BecomeUndamagable()
    {
        yield return new WaitForSeconds(2f);
        tookDamage = false;
        yield return null;
    }

}
