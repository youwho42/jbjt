using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;

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



    [SerializeField]
    private GameObject loadScreen;


    

    [SerializeField]
    private Slider slider;

    [SerializeField]
    private TextMeshProUGUI text;

    //UIScreenManager uiScreenManager;

    bool isPaused;

    private void Start()
    {
        //uiScreenManager = UIScreenManager.instance;
        //if (GetCurrentLevel() != "MainMenu")
        //{
        //    uiScreenManager.DisplayScreen(UIScreenType.PlayerUI);
        //}

    }

    

    public string GetCurrentLevel()
    {
        return SceneManager.GetActiveScene().name;
    }


    public void ChangeLevel(string levelName)
    {
        StartCoroutine(ChangeLevelCo(levelName));
    }

    //public void Pause()
    //{
    //    if(GetCurrentLevel() != "MainMenu")
    //    {
    //        if (uiScreenManager.CurrentUIScreen() != UIScreenType.PauseScreen)
    //        {
    //            uiScreenManager.DisplayScreen(UIScreenType.PauseScreen);

    //        }
    //        else
    //        {
    //            uiScreenManager.HideScreens(UIScreenType.PauseScreen);
    //            uiScreenManager.DisplayScreen(UIScreenType.PlayerUI);

    //        }
    //    }

            
    //}

    IEnumerator ChangeLevelCo (string levelName)
    {
        AsyncOperation currentLevelLoading =  SceneManager.LoadSceneAsync(levelName);

        loadScreen.SetActive(true);
        while (!currentLevelLoading.isDone)
        {
            float progress = Mathf.Clamp(currentLevelLoading.progress / 0.9f, 0, 1);

            slider.value = progress;
            text.text = $"Loading: {Mathf.RoundToInt(progress * 100)}%";

            yield return null;
        }

        //if (GetCurrentLevel() != "MainMenu")
        //{

        //    uiScreenManager.DisplayScreen(UIScreenType.PlayerUI);

        //    PlayerManager.instance.SetPlayerActive(true);
        //} else
        //{
        //    uiScreenManager.HideAllScreens();
        //}
            
       

        loadScreen.SetActive(false);


    }

   
}
