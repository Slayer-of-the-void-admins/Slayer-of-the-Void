using System;
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
    public SpawnerScript spawnerScript;
    public UpgradePanelScript upgradePanelScript;

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
        xpToNextLevel = Mathf.RoundToInt(xpToNextLevel * 1.25f);

        ExpBar.value = currentXP;
        ExpBar.maxValue = xpToNextLevel;
        
        expLabel.text = level.ToString();

        try
        {
        spawnerScript.SetSpawnSet(spawnerScript.spawnSetList[level-1]); // oyuncu level atladığı zaman spawnSet değiştir
        }
        catch (Exception e)
        {
            Debug.Log("spawnSet for the reached level doesn't exist | Exception: " + e.Message);
        }

        upgradePanelScript.ShowUpgradePanel();
    }
}
