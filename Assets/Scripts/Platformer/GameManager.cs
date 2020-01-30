using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }


    public int coinsFound;
    public TextMeshProUGUI coinText;

    private void Start()
    {
        SetGameCanvasGUI();
    }

    public void AddCoin()
    {
        coinsFound++;
        SetGameCanvasGUI();
    }

    void SetGameCanvasGUI()
    {
        coinText.text = coinsFound.ToString();
    }

}
