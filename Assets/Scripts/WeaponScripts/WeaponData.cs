using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponData", menuName = "WeaponData")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public GameObject weaponPrefab;
    public GameObject upgradeCardPrefab;
    public float fireRate = 1f;
    public float projectileSpeed = 20f;
    public float damageAmount = 10f;
    public string targetTag = "Enemy";
    public bool isProjectile = true;
    public bool destroySelfOnCollision = false;
}
