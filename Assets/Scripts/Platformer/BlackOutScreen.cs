using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackOutScreen : MonoBehaviour
{
    public static BlackOutScreen instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Image fadeImage;
    public float timeToBlackOut;
    public GameObject player;

    private void Start()
    {
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0);
    }

    public void BlackOut()
    {
        StartCoroutine(BlackOutCo());
        CountdownTimer.instance.PauseCountdown(timeToBlackOut);
    }

    IEnumerator BlackOutCo()
    {
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1);
        player.SetActive(false);

        yield return new WaitForSeconds(timeToBlackOut);

        player.SetActive(true);
        player.GetComponent<PlayerHealth>().BecomeUndamagable();
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0);
    }

    

    

}
