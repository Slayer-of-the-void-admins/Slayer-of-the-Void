using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LingeringAreaSpawner : MonoBehaviour
{
    public LingeringEffectData lingeringEffectData;

    void OnDestroy()
    {
        if (!Application.isPlaying) return;

        if (lingeringEffectData != null)
        {
            Instantiate(lingeringEffectData.effectPrefab, transform.position, Quaternion.identity);
        }
    }
}
