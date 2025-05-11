// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    public List<WeaponData> weaponDataList;
    public List<EnemySpawnSet> spawnSetList;
    public SpawnerScript spawner;

    void Start()
    {
        ResetWeaponLevels();
        InitializeSpawner();
    }

    void ResetWeaponLevels()
    {
        foreach (WeaponData weaponData in weaponDataList)
        {
            weaponData.weaponLevel = 1;
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
