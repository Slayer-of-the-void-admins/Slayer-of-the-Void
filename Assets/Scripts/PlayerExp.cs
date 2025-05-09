using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExp : MonoBehaviour
{
    public int level = 1;
    public int currentXP = 0;
    public int xpToNextLevel = 100;
    public TextMeshProUGUI expLabel;
    public Slider ExpBar;

    public void GainXP(int xpAmount)
    {
        currentXP += xpAmount;
        ExpBar.value = currentXP;
        if (currentXP >= xpToNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        level++;
        currentXP = currentXP - xpToNextLevel;
        xpToNextLevel = Mathf.RoundToInt(xpToNextLevel * 1.5f);

        ExpBar.value = currentXP;
        ExpBar.maxValue = xpToNextLevel;
        
        expLabel.text = level.ToString();
    }
}
