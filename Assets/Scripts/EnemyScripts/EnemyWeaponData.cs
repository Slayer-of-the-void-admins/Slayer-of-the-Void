using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
