using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    public List<WeaponData> weaponDataList;

    void Start()
    {
        ResetWeaponLevels();
    }

    void ResetWeaponLevels()
    {
        foreach (WeaponData weaponData in weaponDataList)
        {
            weaponData.weaponLevel = 1;
        }
    }
}
