using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "NewEnemyWeaponData", menuName = "EnemyWeaponData")]
public class EnemyWeaponData : ScriptableObject
{
    [Header("Main Settings")]
    public float projectileSpeed = 1f;
    public string weaponName;
    public Color flashColor = Color.white;
    public GameObject weaponPrefab;
    public string targetTag = "Player";
    public float damageAmount = 10f;
    public bool destroySelfOnCollision = false;

    public bool isPoisonedWeapon = false;
    [ShowIf("isPoisonedWeapon")]
    public float duration = 5f;
    [ShowIf("isPoisonedWeapon")]
    public float damageInterval = 1f;
}
