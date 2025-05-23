using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UpgradeData
{
    public int level = 0;
    public int maxLevel = 5;
    public bool isMaxLevel => level >= maxLevel;
    
    public float upgradeAmount = 5f;
    public int baseCost = 100;
    public float costMultiplier = 1.5f;

    public int GetCurrentCost()
    {
        return Mathf.RoundToInt(baseCost * Mathf.Pow(costMultiplier, level));
    }

    public bool CanUpgrade()
    {
        return level < maxLevel;
    }

    public void LevelUp()
    {
        level++;
    }
}

public class CurrencyManager : MonoBehaviour
{
    public PlayerStats playerStats;
    public BuffsPanelScript buffsPanelScript;
    public AudioSource purchaseSound;
    public AudioSource purchaseDeniedSound;
    public UpgradeData healthUpgradeData;
    public void HealthUpgradeButtonClicked()
    {
        if (!healthUpgradeData.CanUpgrade()) return;

        if (playerStats.TrySpendVoidEssence(healthUpgradeData.GetCurrentCost()) == true)
        {
            playerStats.UpgradeHealth(healthUpgradeData.upgradeAmount);
            healthUpgradeData.LevelUp();
            PlayerPrefs.SetInt("MaxHealthUpgradeLevel", healthUpgradeData.level);
            PlayerPrefs.Save();

            buffsPanelScript.UpdateUpgradeTexts();
            buffsPanelScript.UpdateCurrencyAmountText();

            purchaseSound.Play();
        }
        else
        {
            purchaseDeniedSound.Play();
        }
    }

    public UpgradeData resistanceUpgradeData;
    public void ResistanceUpgradeButtonClicked()
    {
        if (!resistanceUpgradeData.CanUpgrade()) return;

        if (playerStats.TrySpendVoidEssence(resistanceUpgradeData.GetCurrentCost()) == true)
        {
            playerStats.UpgradeResistance(resistanceUpgradeData.upgradeAmount);
            resistanceUpgradeData.LevelUp();
            PlayerPrefs.SetInt("ResistanceUpgradeLevel", resistanceUpgradeData.level);
            PlayerPrefs.Save();

            buffsPanelScript.UpdateUpgradeTexts();
            buffsPanelScript.UpdateCurrencyAmountText();

            purchaseSound.Play();
        }
        else
        {
            purchaseDeniedSound.Play();
        }
    }

    public UpgradeData damageUpgradeData;
    public void DamageUpgradeButtonClicked()
    {
        if (!damageUpgradeData.CanUpgrade()) return;

        if (playerStats.TrySpendVoidEssence(damageUpgradeData.GetCurrentCost()) == true)
        {
            playerStats.UpgradeDamage(damageUpgradeData.upgradeAmount);
            damageUpgradeData.LevelUp();
            PlayerPrefs.SetInt("DamageUpgradeLevel", damageUpgradeData.level);
            PlayerPrefs.Save();

            buffsPanelScript.UpdateUpgradeTexts();
            buffsPanelScript.UpdateCurrencyAmountText();

            purchaseSound.Play();
        }
        else
        {
            purchaseDeniedSound.Play();
        }
    }

    public UpgradeData moveSpeedUpgradeData;
    public void MoveSpeedUpgradeButtonClicked()
    {
        if (!moveSpeedUpgradeData.CanUpgrade()) return;

        if (playerStats.TrySpendVoidEssence(moveSpeedUpgradeData.GetCurrentCost()) == true)
        {
            playerStats.UpgradeMoveSpeed(moveSpeedUpgradeData.upgradeAmount);
            moveSpeedUpgradeData.LevelUp();
            PlayerPrefs.SetInt("MoveSpeedUpgradeLevel", moveSpeedUpgradeData.level);
            PlayerPrefs.Save();

            buffsPanelScript.UpdateUpgradeTexts();
            buffsPanelScript.UpdateCurrencyAmountText();

            purchaseSound.Play();
        }
        else
        {
            purchaseDeniedSound.Play();
        }
    }

    public UpgradeData weaponSpeedUpgradeData;
    public void WeaponSpeedUpgradeButtonClicked()
    {
        if (!weaponSpeedUpgradeData.CanUpgrade()) return;

        if (playerStats.TrySpendVoidEssence(weaponSpeedUpgradeData.GetCurrentCost()) == true)
        {
            playerStats.UpgradeWeaponSpeed(weaponSpeedUpgradeData.upgradeAmount);
            weaponSpeedUpgradeData.LevelUp();
            PlayerPrefs.SetInt("WeaponSpeedUpgradeLevel", weaponSpeedUpgradeData.level);
            PlayerPrefs.Save();

            buffsPanelScript.UpdateUpgradeTexts();
            buffsPanelScript.UpdateCurrencyAmountText();

            purchaseSound.Play();
        }
        else
        {
            purchaseDeniedSound.Play();
        }
    }

    public UpgradeData fireRateUpgradeData;
    public void FireRateUpgradeButtonClicked()
    {
        if (!fireRateUpgradeData.CanUpgrade()) return;

        if (playerStats.TrySpendVoidEssence(fireRateUpgradeData.GetCurrentCost()) == true)
        {
            playerStats.UpgradeFireRate(fireRateUpgradeData.upgradeAmount);
            fireRateUpgradeData.LevelUp();
            PlayerPrefs.SetInt("FireRateUpgradeLevel", fireRateUpgradeData.level);
            PlayerPrefs.Save();

            buffsPanelScript.UpdateUpgradeTexts();
            buffsPanelScript.UpdateCurrencyAmountText();

            purchaseSound.Play();
        }
        else
        {
            purchaseDeniedSound.Play();
        }
    }

    public void LoadUpgradeLevels()
    {
        healthUpgradeData.level = PlayerPrefs.GetInt("MaxHealthUpgradeLevel", 0);
        resistanceUpgradeData.level = PlayerPrefs.GetInt("ResistanceUpgradeLevel", 0);
        damageUpgradeData.level = PlayerPrefs.GetInt("DamageUpgradeLevel", 0);
        moveSpeedUpgradeData.level = PlayerPrefs.GetInt("MoveSpeedUpgradeLevel", 0);
        weaponSpeedUpgradeData.level = PlayerPrefs.GetInt("WeaponSpeedUpgradeLevel", 0);
        fireRateUpgradeData.level = PlayerPrefs.GetInt("FireRateUpgradeLevel", 0);
    }

    public void ResetAllUpgradeLevels()
    {
        PlayerPrefs.SetInt("MaxHealthUpgradeLevel", 0);
        PlayerPrefs.SetInt("ResistanceUpgradeLevel", 0);
        PlayerPrefs.SetInt("DamageUpgradeLevel", 0);
        PlayerPrefs.SetInt("MoveSpeedUpgradeLevel", 0);
        PlayerPrefs.SetInt("WeaponSpeedUpgradeLevel", 0);
        PlayerPrefs.SetInt("FireRateUpgradeLevel", 0);
        PlayerPrefs.Save();
    }
}
