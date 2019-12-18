using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public TMP_Text nameText;

    public Slider sliderHP;

    public Image unitCardImage;

    public Unit enemyUnit;

    public Button attackButton;


    public void SetHUD(Unit unit)
    {
        enemyUnit = unit;
        nameText.text = unit.unitName;
        sliderHP.maxValue = unit.maxHP;
        sliderHP.value = unit.currentHP;
        unitCardImage.sprite = unit.unitSprite;
        if(attackButton != null)
        {
            attackButton.interactable = true;
        }
        
    }

    public void SetHP(int hp)
    {
        sliderHP.value = hp;
        if(sliderHP.value <= 0)
        {
            attackButton.interactable = false;
        }
    }
}
