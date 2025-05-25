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
    private Queue<int> levelUpQueue = new Queue<int>();
    private bool isProcessingLevelUp = false;

    void Start()
    {
        StartCoroutine(ProcessLevelUpQueue());
    }

    public void GainXP(int xpAmount)
    {
        currentXP += xpAmount;
        ExpBar.value = currentXP;
        while (currentXP >= xpToNextLevel)
        {
            levelUpQueue.Enqueue(1); // Add a level-up to the queue
            currentXP -= xpToNextLevel;
            ExpBar.value = currentXP;
            xpToNextLevel = Mathf.RoundToInt(xpToNextLevel * 1.25f);
            ExpBar.maxValue = xpToNextLevel;
        }
    }

    private void LevelUp()
    {
        level++;
        expLabel.text = level.ToString();

        try
        {
            spawnerScript.SetSpawnSet(spawnerScript.spawnSetList[level - 1]); // oyuncu level atladığı zaman spawnSet değiştir
        }
        catch (Exception e)
        {
            Debug.Log("spawnSet for the reached level doesn't exist | Exception: " + e.Message);
        }
    }

    private IEnumerator ProcessLevelUpQueue()
    {
        while (true)
        {
            if (levelUpQueue.Count > 0 && !isProcessingLevelUp)
            {
                isProcessingLevelUp = true;
                LevelUp();

                // Wait for the upgrade panel to close
                while (upgradePanelScript.upgradePanel.activeSelf || upgradePanelScript.isUpgradePanelActive)
                {
                    yield return null;
                }

                upgradePanelScript.ShowUpgradePanel();
                levelUpQueue.Dequeue(); // Remove the processed level-up from the queue
                isProcessingLevelUp = false;
            }
            else
            {
                yield return null; // Wait for the next frame
            }
        }
    }
}
