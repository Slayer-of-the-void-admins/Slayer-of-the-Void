using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    public List<WeaponData> weaponDataList;
    public List<LingeringEffectData> lingeringEffectList;
    public List<EnemySpawnSet> spawnSetList;
    public List<EnemyData> enemyDataList;
    public SpawnerScript spawner;

    public PlayerStats playerStats;
    public CurrencyManager currencyManager;

    public SoundSettings soundSettings;

    void Start()
    {
        ResetWeaponLevels();
        ResetLingeringEffectLevels();
        InitializeSpawner();
        InitializePlayerUpgrades();
        ResetEnemyCurrentAmounts();
        ResetAmountOfCollisionBeforeDestroy();

        playerStats.LoadStats();
        playerStats.LoadVoidEssenceAmount();
        if (currencyManager != null)
            currencyManager.LoadUpgradeLevels();

        if (soundSettings != null)
            soundSettings.LoadSoundPrefs();
    }

    public PlayerMovement playerMovement;
    void InitializePlayerUpgrades()
    {
        // health - healthscript start() da düzenleniyor

        // resistance - healthscript takedamage() da düzenleniyor

        // damage - healthscript takedamage() da düzenleniyor

        // moveSpeed
        if (playerMovement != null)
            playerMovement.moveSpeedUpgradeModifier = 1f + (playerStats.moveSpeedPercentage / 100);


        foreach (WeaponData weaponData in weaponDataList)
        {
            if (weaponData != null)
            {
                // weaponSpeed
                weaponData.weaponSpeedModifier = 1f + (playerStats.weaponSpeedPercentage / 100);

                // fire rate
                weaponData.fireRateModifier = 1f + (playerStats.fireRatePercentage / 100);
            }
        }
    }

    void ResetWeaponLevels()
    {
        foreach (WeaponData weaponData in weaponDataList)
        {
            if (weaponData != null)
            {
                weaponData.weaponLevel = 1;
            }
        }
    }

    void ResetLingeringEffectLevels()
    {
        foreach (LingeringEffectData lingeringEffect in lingeringEffectList)
        {
            if (lingeringEffect != null)
            {
                lingeringEffect.effectLevel = 1;
            }
        }
    }

    void InitializeSpawner()
    {
        if (spawner != null)
        {
            spawner.spawnSetList = spawnSetList;
            spawner.SetSpawnSet(spawnSetList[0]);
        }
    }

    void ResetEnemyCurrentAmounts()
    {
        foreach (EnemyData enemyData in enemyDataList)
        {
            if (enemyData != null)
            {
                enemyData.currentAmount = 0;
            }
        }
    }

    void ResetAmountOfCollisionBeforeDestroy()
    {
        foreach (WeaponData weaponData in weaponDataList)
        {
            if (weaponData != null)
            {
                weaponData.amountOfCollisionBeforeDestroy = weaponData.defaultAmountOfCollisionPerDestroy;
            }
        }
    }
}
