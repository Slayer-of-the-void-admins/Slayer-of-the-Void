using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LingeringAreaSpawner : MonoBehaviour
{
    public LingeringEffectData lingeringEffectData;
    public WeaponData weaponData;

    void OnDestroy()
    {
        if (lingeringEffectData != null)
        {
            lingeringEffectData.effectLevel = weaponData.weaponLevel;
            // Debug.Log("linger area effect level: " + lingeringEffectData.effectLevel);
            Instantiate(lingeringEffectData.effectPrefab, transform.position, Quaternion.identity);
        }
    }
}
