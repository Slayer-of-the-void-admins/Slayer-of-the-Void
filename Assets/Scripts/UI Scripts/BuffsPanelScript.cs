using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuffsPanelScript : MonoBehaviour
{
    public CurrencyManager currencyManager;
    public PlayerStats playerStats;
    public TextMeshProUGUI currencyAmountText;

    public TextMeshProUGUI healthLevelText;
    public TextMeshProUGUI healthUpgradePrice;

    public TextMeshProUGUI resistanceLevelText;
    public TextMeshProUGUI resistanceUpgradePrice;

    public TextMeshProUGUI damageLevelText;
    public TextMeshProUGUI damageUpgradePrice;

    public TextMeshProUGUI moveSpeedLevelText;
    public TextMeshProUGUI moveSpeedUpgradePrice;

    public TextMeshProUGUI weaponSpeedLevelText;
    public TextMeshProUGUI weaponSpeedUpgradePrice;

    public TextMeshProUGUI fireRateLevelText;
    public TextMeshProUGUI fireRateUpgradePrice;

    void OnEnable()
    {
        // LoadUpgradeLevels();
        UpdateCurrencyAmountText();
        UpdateUpgradeTexts();
    }

    public void UpdateCurrencyAmountText()
    {
        playerStats.LoadVoidEssenceAmount();
        
        currencyAmountText.text = playerStats.voidEssenceAmount.ToString();
    }


    public void UpdateUpgradeTexts()
    {
        currencyManager.LoadUpgradeLevels();

        UpgradeData healthUpgradeData = currencyManager.healthUpgradeData;
        healthLevelText.text = "LVL: " + healthUpgradeData.level + "/" + healthUpgradeData.maxLevel;
        healthUpgradePrice.text = healthUpgradeData.GetCurrentCost().ToString();
        if (healthUpgradeData.isMaxLevel)
        {
            healthUpgradePrice.text = "MAX";
        }

        UpgradeData resistanceUpgradeData = currencyManager.resistanceUpgradeData;
        resistanceLevelText.text = "LVL: " + resistanceUpgradeData.level + "/" + resistanceUpgradeData.maxLevel;
        resistanceUpgradePrice.text = resistanceUpgradeData.GetCurrentCost().ToString();
        if (resistanceUpgradeData.isMaxLevel)
        {
            resistanceUpgradePrice.text = "MAX";
        }

        UpgradeData damageUpgradeData = currencyManager.damageUpgradeData;
        damageLevelText.text = "LVL: " + damageUpgradeData.level + "/" + damageUpgradeData.maxLevel;
        damageUpgradePrice.text = damageUpgradeData.GetCurrentCost().ToString();
        if (damageUpgradeData.isMaxLevel)
        {
            damageUpgradePrice.text = "MAX";
        }

        UpgradeData moveSpeedUpgradeData = currencyManager.moveSpeedUpgradeData;
        moveSpeedLevelText.text = "LVL: " + moveSpeedUpgradeData.level + "/" + moveSpeedUpgradeData.maxLevel;
        moveSpeedUpgradePrice.text = moveSpeedUpgradeData.GetCurrentCost().ToString();
        if (moveSpeedUpgradeData.isMaxLevel)
        {
            moveSpeedUpgradePrice.text = "MAX";
        }

        UpgradeData weaponSpeedUpgradeData = currencyManager.weaponSpeedUpgradeData;
        weaponSpeedLevelText.text = "LVL: " + weaponSpeedUpgradeData.level + "/" + weaponSpeedUpgradeData.maxLevel;
        weaponSpeedUpgradePrice.text = weaponSpeedUpgradeData.GetCurrentCost().ToString();
        if (weaponSpeedUpgradeData.isMaxLevel)
        {
            weaponSpeedUpgradePrice.text = "MAX";
        }

        UpgradeData fireRateUpgradeData = currencyManager.fireRateUpgradeData;
        fireRateLevelText.text = "LVL: " + fireRateUpgradeData.level + "/" + fireRateUpgradeData.maxLevel;
        fireRateUpgradePrice.text = fireRateUpgradeData.GetCurrentCost().ToString();
        if (fireRateUpgradeData.isMaxLevel)
        {
            fireRateUpgradePrice.text = "MAX";
        }
    }
}
