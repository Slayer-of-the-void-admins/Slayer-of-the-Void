using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LingeringAreaSpawner : MonoBehaviour
{
    public LingeringEffectData lingeringEffectData;
    private LingeringEffectData lingeringEffectDataCopy;
    public WeaponData weaponData;

    void OnDestroy()
    {
        if (lingeringEffectData != null)
        {
            lingeringEffectData.effectLevel = weaponData.weaponLevel;
            GameObject lingeringArea = Instantiate(lingeringEffectData.effectPrefab, transform.position, Quaternion.identity);
            lingeringArea.transform.localScale = lingeringEffectData.GetSize();
            Debug.Log("linger area effect level: " + lingeringEffectData.effectLevel);
            Debug.Log("created lingering area size: " + lingeringArea.transform.localScale.x.ToString());
        }
    }
}
