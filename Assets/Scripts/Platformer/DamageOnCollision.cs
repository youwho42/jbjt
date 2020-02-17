using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    public int damageToDeal;



    public void OnCollisionEnter2D(Collision2D collision)
    {
        IDamagable<int> damagableObject = collision.gameObject.GetComponent<IDamagable<int>>();
        if (damagableObject != null)
        {
            damagableObject.Damage(damageToDeal);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            IDamagable<int> damagableObject = other.GetComponent<IDamagable<int>>();
            if (damagableObject != null)
            {
                damagableObject.Damage(damageToDeal);
            }
        }
    }

}
