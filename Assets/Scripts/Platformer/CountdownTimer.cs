using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;

public class CountdownTimer : MonoBehaviour
{

    public static CountdownTimer instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public TextMeshProUGUI countdownTimerText;


    public float maxTime;
    float currentTime;
    public bool countdownStarted;
    public bool countdownPaused;

    private void Start()
    {
        currentTime = maxTime;
        countdownStarted = false;
        countdownTimerText.text = Mathf.RoundToInt(currentTime).ToString();
    }

    public void PauseCountdown(float pauseTime)
    {
        StartCoroutine(PauseCountdownCo(pauseTime));
    }

    IEnumerator PauseCountdownCo(float pauseTime)
    {
        countdownPaused = true;
        yield return new WaitForSeconds(pauseTime);
        countdownPaused = false;
    }
    
    private void Update()
    {
        
        if (countdownStarted)
        {
            if (!countdownPaused)
            {
                currentTime -= Time.deltaTime;
                countdownTimerText.text = Mathf.RoundToInt(currentTime).ToString();
            }
            

            if (currentTime <= 0)
            {
                RespawnPlayer.instance.StartRespawn();
                currentTime = maxTime;
                countdownStarted = false;
            }
        }
        
    }

    

}
