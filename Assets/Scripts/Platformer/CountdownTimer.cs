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
    public TextMeshProUGUI startText;

    private void Start()
    {
        currentTime = maxTime;
        countdownStarted = false;
        countdownTimerText.text = Mathf.RoundToInt(currentTime).ToString();
        startText.enabled = false;
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

    IEnumerator StartCountdownCo()
    {
        startText.enabled = true;
        startText.text = "3";
        yield return new WaitForSeconds(1);
        startText.text = "2";
        yield return new WaitForSeconds(1);
        startText.text = "1";
        yield return new WaitForSeconds(1);
        startText.text = "0";
        yield return new WaitForSeconds(1);
        startText.text = "GO!";
        countdownStarted = true;
        yield return new WaitForSeconds(1);
        startText.enabled = false;
    }

    public void StartCountdown()
    {
        StartCoroutine(StartCountdownCo());
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
                RespawnPlayer.instance.StartRespawn(true);
                currentTime = maxTime;
                countdownStarted = false;
            }
        }
        
    }

    

}
