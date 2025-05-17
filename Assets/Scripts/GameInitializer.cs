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
    public SpawnerScript spawner;
    public PlayerStats playerStats;

    void Start()
    {
        ResetWeaponLevels();
        InitializeSpawner();
        ResetLingeringEffectLevels();
        playerStats.LoadStats();
    }

    void ResetWeaponLevels()
    {
        foreach (WeaponData weaponData in weaponDataList)
        {
            weaponData.weaponLevel = 1;
        }
    }

    void ResetLingeringEffectLevels()
    {
        foreach (LingeringEffectData lingeringEffect in lingeringEffectList)
        {
            lingeringEffect.effectLevel = 1;
        }
    }

    void InitializeSpawner()
    {
        if (spawner != null)
        {
            spawner.spawnSetList = spawnSetList;
        }
        spawner.SetSpawnSet(spawnSetList[0]);
    }
}
