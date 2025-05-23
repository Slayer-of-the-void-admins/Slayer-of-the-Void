using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "NewLingeringEffectData", menuName = "LingeringEffectData")]
public class LingeringEffectData : ScriptableObject
{
    public string effectName;
    public Color flashColor = Color.white;
    public float flashDuration = 0.125f;
    public WeaponData weaponData;
    public GameObject effectPrefab;
    public float damageAmount = 5f;
    public float damageInterval = 1f;
    public float duration = 5f;
    public float stunDuration = 0.125f;
    public int effectLevel = 1;


    public float damageMultiplier = 1.2f;
    public float GetDamage()
    {
        return damageAmount * Mathf.Pow(damageMultiplier, effectLevel - 1);
    }


    private float buffedDuration;
    private float buffAmountForDuration;
    public float GetDuration() // duration interval kadar artırılarak efektin çalışma miktarı 1 artar
    {
        buffedDuration = duration;
        if (effectLevel > 1)
        {
            buffAmountForDuration = damageInterval * effectLevel - 1;
        }
        else
        {
            buffAmountForDuration = 0;
        }
        buffedDuration += buffAmountForDuration;
        return buffedDuration;
    }


    public float sizeMultiplier = 1.2f;
    private Vector3 scale;
    public Vector3 GetSize()
    {
        scale = effectPrefab.transform.localScale;
        return scale * Mathf.Pow(sizeMultiplier, effectLevel - 1);
    }
}
