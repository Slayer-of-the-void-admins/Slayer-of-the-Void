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

        UpgradeData resistanceUpgradeData = currencyManager.resistanceUpgradeData;
        resistanceLevelText.text = "LVL: " + resistanceUpgradeData.level + "/" + resistanceUpgradeData.maxLevel;
        resistanceUpgradePrice.text = resistanceUpgradeData.GetCurrentCost().ToString();

        UpgradeData damageUpgradeData = currencyManager.damageUpgradeData;
        damageLevelText.text = "LVL: " + damageUpgradeData.level + "/" + damageUpgradeData.maxLevel;
        damageUpgradePrice.text = damageUpgradeData.GetCurrentCost().ToString();

        UpgradeData moveSpeedUpgradeData = currencyManager.moveSpeedUpgradeData;
        moveSpeedLevelText.text = "LVL: " + moveSpeedUpgradeData.level + "/" + moveSpeedUpgradeData.maxLevel;
        moveSpeedUpgradePrice.text = moveSpeedUpgradeData.GetCurrentCost().ToString();

        UpgradeData weaponSpeedUpgradeData = currencyManager.weaponSpeedUpgradeData;
        weaponSpeedLevelText.text = "LVL: " + weaponSpeedUpgradeData.level + "/" + weaponSpeedUpgradeData.maxLevel;
        weaponSpeedUpgradePrice.text = weaponSpeedUpgradeData.GetCurrentCost().ToString();

        UpgradeData fireRateUpgradeData = currencyManager.fireRateUpgradeData;
        fireRateLevelText.text = "LVL: " + fireRateUpgradeData.level + "/" + fireRateUpgradeData.maxLevel;
        fireRateUpgradePrice.text = fireRateUpgradeData.GetCurrentCost().ToString();
    }

    // public void LoadUpgradeLevels()
    // {
    //     currencyManager.healthUpgradeData.level = PlayerPrefs.GetInt("MaxHealthUpgradeLevel", 0);
    //     currencyManager.resistanceUpgradeData.level = PlayerPrefs.GetInt("ResistanceUpgradeLevel", 0);
    //     currencyManager.damageUpgradeData.level = PlayerPrefs.GetInt("DamageUpgradeLevel", 0);
    //     currencyManager.moveSpeedUpgradeData.level = PlayerPrefs.GetInt("MoveSpeedUpgradeLevel", 0);
    //     currencyManager.weaponSpeedUpgradeData.level = PlayerPrefs.GetInt("WeaponSpeedUpgradeLevel", 0);
    //     currencyManager.fireRateUpgradeData.level = PlayerPrefs.GetInt("FireRateUpgradeLevel", 0);
    // }
}
