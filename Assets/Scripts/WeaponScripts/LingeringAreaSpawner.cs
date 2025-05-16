using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class LingeringAreaSpawner : MonoBehaviour
{
    public LingeringEffectData lingeringEffectData;
    public WeaponData weaponData;

    private bool isQuitting = false;
    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    void OnDestroy()
    {
        if (isQuitting || !gameObject.scene.isLoaded) return;

        if (lingeringEffectData != null)
        {
            lingeringEffectData.effectLevel = weaponData.weaponLevel;
            GameObject lingeringArea = Instantiate(lingeringEffectData.effectPrefab, transform.position, Quaternion.identity);
            lingeringArea.transform.localScale = lingeringEffectData.GetSize();
            // Debug.Log("linger area effect level: " + lingeringEffectData.effectLevel);
            // Debug.Log("created lingering area size: " + lingeringArea.transform.localScale.x.ToString());
        }
    }
}
