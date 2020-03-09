using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemStartDelay : MonoBehaviour
{
    public List<GameObject> particleSystems;
    public float interval;

    private void Start()
    {
        StartCoroutine(StartParticlesCo());
    }

    IEnumerator StartParticlesCo()
    {
        for (int i = 0; i < particleSystems.Count; i++)
        {
            particleSystems[i].GetComponentInChildren<ParticleSystem>().Play();
            yield return new WaitForSeconds(interval);
        }

        yield return null;

    }
}
