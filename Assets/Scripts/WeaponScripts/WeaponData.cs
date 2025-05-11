using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponData", menuName = "WeaponData")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public GameObject weaponPrefab;
    public GameObject upgradeCardPrefab;
    public string targetTag = "Enemy";
    public float damageAmount = 10f;

    public bool isProjectile = true;
    [ShowIf("isProjectile")]
    public float fireRate = 1f;
    [ShowIf("isProjectile")]
    public float projectileSpeed = 20f;
    [ShowIf("isProjectile")]
    public bool destroySelfOnCollision = false;

    [HideIf("isProjectile")]
    public float rotationSpeed = 3f;
    [HideIf("isProjectile")]
    public float orbitDistance = 3.5f;
    
    public int weaponLevel = 1;

    public float damageMultiplier = 1.2f;
    public float GetDamage()
    {   // damageMultiplier ın weaponLevel - 1. kuvveti ile çarp
        return damageAmount * Mathf.Pow(damageMultiplier, weaponLevel - 1);
    }

    public float speedMultiplier = 1.2f; 
    public float GetSpeed()
    {
        if (isProjectile == true)
        {
            return projectileSpeed * Mathf.Pow(speedMultiplier, weaponLevel - 1);
        }
        else // yakın silah
        {
            return rotationSpeed * Mathf.Pow(speedMultiplier, weaponLevel - 1);
        }
    }
}
