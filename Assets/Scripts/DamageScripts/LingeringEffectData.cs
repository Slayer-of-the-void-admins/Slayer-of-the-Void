using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLingeringEffectData", menuName = "LingeringEffectData")]
public class LingeringEffectData : ScriptableObject
{
    public string effectName = "poison";
    public WeaponData weaponData;
    public GameObject effectPrefab;
    public float damageAmount = 5f;
    public float damageInterval = 1f;
    public float duration = 5f;
}
