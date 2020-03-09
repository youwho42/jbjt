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

        yield return new WaitForSeconds(timeToBlackOut);

        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0);
    }

    

    

}
