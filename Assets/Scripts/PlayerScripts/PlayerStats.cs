using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "PlayerData")]
public class PlayerStats : ScriptableObject
{
    public float playerHealth = 100f;
    public float resistancePercentage = 0f;
    public float damagePercentage = 0f;
    public float moveSpeedPercentage = 0f;
    public float weaponSpeedPercentage = 0f;
    public float fireRatePercentage = 0f;

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

    public void ResetAllStats()
    {
        PlayerPrefs.SetFloat("PlayerHealth", 100f);
        PlayerPrefs.SetFloat("ResistancePercentage", 0f);
        PlayerPrefs.SetFloat("DamageMultiplierPercentage", 0f);
        PlayerPrefs.SetFloat("MoveSpeedPercentage", 0f);
        PlayerPrefs.SetFloat("WeaponSpeedPercentage", 0f);
        PlayerPrefs.SetFloat("FireRatePercentage", 0f);
        PlayerPrefs.Save();
    }

    public void UpgradeHealthBy5()
    {
        playerHealth += 5f;
        SaveStats();
    }

    public void UpgradeResistanceBy1()
    {
        resistancePercentage += 1f;
        SaveStats();
    }
}
