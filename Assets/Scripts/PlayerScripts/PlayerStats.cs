using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "PlayerData")]
public class PlayerStats : ScriptableObject
{
    public int voidEssenceAmount;
    public void SaveVoidEssenceAmount()
    {
        PlayerPrefs.SetInt("VoidEssence", voidEssenceAmount);
        PlayerPrefs.Save();
    }

    public void LoadVoidEssenceAmount()
    {
        voidEssenceAmount = PlayerPrefs.GetInt("VoidEssence", 0);
    }

    public bool TrySpendVoidEssence(int price)
    {
        LoadVoidEssenceAmount();
        if (voidEssenceAmount >= price)
        {
            voidEssenceAmount -= price;
            SaveVoidEssenceAmount();
            return true;
        }
        return false;
    }


    public float playerHealth = 100f;
    public void UpgradeHealth(float amount)
    {
        playerHealth += amount;
        SaveStats();
    }


    public float resistancePercentage = 0f;
    public void UpgradeResistance(float amount)
    {
        resistancePercentage += amount;
        SaveStats();
    }


    public float damagePercentage = 0f;
    public void UpgradeDamage(float amount)
    {
        damagePercentage += amount;
        SaveStats();
    }


    public float moveSpeedPercentage = 0f;
    public void UpgradeMoveSpeed(float amount)
    {
        moveSpeedPercentage += amount;
        SaveStats();
    }


    public float weaponSpeedPercentage = 0f;
    public void UpgradeWeaponSpeed(float amount)
    {
        weaponSpeedPercentage += amount;
        SaveStats();
    }


    public float fireRatePercentage = 0f;
    public void UpgradeFireRate(float amount)
    {
        fireRatePercentage += amount;
        SaveStats();
    }


    public void SaveStats()
    {
        PlayerPrefs.SetFloat("PlayerHealth", playerHealth);
        PlayerPrefs.SetFloat("ResistancePercentage", resistancePercentage);
        PlayerPrefs.SetFloat("DamageMultiplierPercentage", damagePercentage);
        PlayerPrefs.SetFloat("MoveSpeedPercentage", moveSpeedPercentage);
        PlayerPrefs.SetFloat("WeaponSpeedPercentage", weaponSpeedPercentage);
        PlayerPrefs.SetFloat("FireRatePercentage", fireRatePercentage);
        PlayerPrefs.Save();
    }

    public void LoadStats()
    {
        playerHealth = PlayerPrefs.GetFloat("PlayerHealth", 100f);
        resistancePercentage = PlayerPrefs.GetFloat("ResistancePercentage", 0f);
        damagePercentage = PlayerPrefs.GetFloat("DamageMultiplierPercentage", 0f);
        moveSpeedPercentage = PlayerPrefs.GetFloat("MoveSpeedPercentage", 0f);
        weaponSpeedPercentage = PlayerPrefs.GetFloat("WeaponSpeedPercentage", 0f);
        fireRatePercentage = PlayerPrefs.GetFloat("FireRatePercentage", 0f);
    }

    public void ResetAllStatsAndVoidEssence()
    {
        PlayerPrefs.SetInt("VoidEssence", 0);

        PlayerPrefs.SetFloat("PlayerHealth", 100f);
        PlayerPrefs.SetFloat("ResistancePercentage", 0f);
        PlayerPrefs.SetFloat("DamageMultiplierPercentage", 0f);
        PlayerPrefs.SetFloat("MoveSpeedPercentage", 0f);
        PlayerPrefs.SetFloat("WeaponSpeedPercentage", 0f);
        PlayerPrefs.SetFloat("FireRatePercentage", 0f);
        PlayerPrefs.Save();
    }

    public void GetEssence(int essenceAmount)
    {
        voidEssenceAmount += essenceAmount;
        SaveVoidEssenceAmount();
    }
}
