using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable<int>
{
    public int maxHealth;
    public int currentHealth { get; private set; }
    public bool tookDamage;

    PlayerMovement player;
    Rigidbody2D rb;

    private void Start()
    {
        ResetPlayerHealth();
        player = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        
    }
    
    
    public void Damage(int damageTaken)
    {
        if (!tookDamage)
        {
            tookDamage = true;
            currentHealth -= damageTaken;
            //if (currentHealth <= 0)
            //{
            //    Kill();
            //} else
            //{
            //    KnockBackCharacter();
            //    StartCoroutine(BecomeUndamagable());
            //}
            
            StartCoroutine(BecomeUndamagable());
            StartCoroutine(KnockBackCharacter());
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
        tookDamage = false;
        ResetPlayerHealth();
    }

    IEnumerator KnockBackCharacter()
    {
        
        player.enabled = false;
        
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(500 * -transform.localScale.x, 200));
        yield return new WaitForSeconds(1f);
        
        player.enabled = true;
        yield return null;
    }

    IEnumerator BecomeUndamagable()
    {
        
        yield return new WaitForSeconds(2f);
        tookDamage = false;
        
        yield return null;
    }

}
