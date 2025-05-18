using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponData", menuName = "WeaponData")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public Color flashColor = Color.white;
    public GameObject weaponPrefab;
    public GameObject upgradeCardPrefab;
    public string targetTag = "Enemy";
    public float damageAmount = 10f;
    public float stunDuration = 0.2f;


    public bool isProjectile = true;
    [ShowIf("isProjectile")]
    public float fireRate = 1f; // saniyede ... kadar atış sıklığı
    [ShowIf("isProjectile")]
    public float projectileSpeed = 20f;
    [ShowIf("isProjectile")]
    public bool destroySelfOnCollision = false;


    [ShowIf("isProjectile")]
    public bool isRandomAimingProjectile = false;

    [ShowIf("isRandomAimingProjectile")]
    public float minAimRange = 3f;
    [ShowIf("isRandomAimingProjectile")]
    public float maxAimRange = 12f;
    

    [HideIf("isProjectile")]
    public float rotationSpeed = 3f;
    [HideIf("isProjectile")]
    public float orbitDistance = 3.5f;
    

    public int weaponLevel = 1;

    // multiplier ları 1f e koymak seviye atladıkça birşeyin değişmemesini sağlar
    public float damageMultiplier = 1.2f;
    public float GetDamage()
    {   // damageMultiplier ın weaponLevel - 1. kuvveti ile çarp
        return damageAmount * Mathf.Pow(damageMultiplier, weaponLevel - 1);
    }


    [ShowIf("isProjectile")]
    public float fireRateMultiplier = 1.2f;
    [HideInInspector] public float fireRateModifier = 1f;
    public float GetFireRate()
    {
        return fireRate * Mathf.Pow(fireRateMultiplier, weaponLevel - 1) * fireRateModifier;
    }

    public float speedMultiplier = 1.2f;
    [HideInInspector] public float weaponSpeedModifier = 1f;
    public float GetSpeed()
    {
        if (isProjectile == true)
        {
            return projectileSpeed * Mathf.Pow(speedMultiplier, weaponLevel - 1) * weaponSpeedModifier;
        }
        else // yakın silah
        {
            return rotationSpeed * Mathf.Pow(speedMultiplier, weaponLevel - 1) * weaponSpeedModifier;
        }
    }
}
