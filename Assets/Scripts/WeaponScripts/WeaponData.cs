using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.Universal;

[CreateAssetMenu(fileName = "NewWeaponData", menuName = "WeaponData")]
public class WeaponData : ScriptableObject
{
    [Header("Main Settings")]
    public string weaponName;
    public Color flashColor = Color.white;
    public float flashDuration = 0.125f;
    public GameObject weaponPrefab;
    public GameObject upgradeCardPrefab;
    public GameObject weaponIconPrefab;
    public string targetTag = "Enemy";
    public float damageAmount = 10f;
    public float stunDuration = 0.2f;


    [Header("Self Destroy Settings")]
    public bool hasLifeDuration = false;
    [ShowIf("hasLifeDuration")] public float lifeDuration = 2f;
    public bool destroySelfOnCollision = false;
    [ShowIf("destroySelfOnCollision")] public int defaultAmountOfCollisionPerDestroy = 1;
    [ShowIf("destroySelfOnCollision")] public int amountOfCollisionBeforeDestroy = 1;
    [ShowIf("destroySelfOnCollision")] public int addAmountOfCollisionBeforeDestroyPerLevel = 0;
    public int GetAmountOfCollisionBeforeDestroy()
    {
        // amountOfCollisionBeforeDestroy = defaultAmountOfCollisionPerDestroy;

        // for (int i = 1; i < weaponLevel; i++)
        // {
        //     amountOfCollisionBeforeDestroy += addAmountOfCollisionBeforeDestroyPerLevel;
        // }
        return amountOfCollisionBeforeDestroy = defaultAmountOfCollisionPerDestroy + addAmountOfCollisionBeforeDestroyPerLevel * (weaponLevel - 1);
    }

    public bool amountOfCollisionMaxed => amountOfCollisionBeforeDestroy >= defaultAmountOfCollisionPerDestroy + addAmountOfCollisionBeforeDestroyPerLevel * (weaponLevel - 1);


    [Header("Audio Settings")]
    public AudioMixerGroup audioMixerGroup;
    public bool playAudioOnShoot = false;
    [ShowIf("playAudioOnShoot")] public AudioClip weaponShootSound;
    public bool playAudioOnCollision = false;
    [ShowIf("playAudioOnCollision")] public AudioClip weaponCollisionSound;
    public bool playAudioOnDestroy = false;
    [ShowIf("playAudioOnDestroy")] public AudioClip weaponDestroySound;



    [Header("Floating Weapon Settings")]
    public bool isFloatingWeapon = true;
    [ShowIf("isFloatingWeapon")] public float cooldownTimer = 10f;
    [ShowIf("isFloatingWeapon")] public float floatingWeaponTimer = 0f;


    [Header("Orbitting Weapon Settings")]
    public bool isOrbittingWeapon = false;
    [ShowIf("isOrbittingWeapon")] public float rotationSpeed = 3f;
    [ShowIf("isOrbittingWeapon")] public float orbitDistance = 3.5f;


    [Header("Projectile Weapon Settings")]
    public bool isProjectile = true;
    [ShowIf("isProjectile")] public float fireRate = 1f; // saniyede ... kadar atış sıklığı
    [ShowIf("isProjectile")] public float projectileSpeed = 20f;


    [ShowIf("isProjectile")] public bool isRandomAimingProjectile = false;
    [ShowIf("isRandomAimingProjectile")] public float minAimRange = 3f;
    [ShowIf("isRandomAimingProjectile")] public float maxAimRange = 12f;


    [Header("Nova Weapon Settings")]
    public bool isNovaWeapon = false;
    [ShowIf("isNovaWeapon")] public float spawnInterval = 5f;
    [ShowIf("isNovaWeapon")] public float spawnIntervalDivisor = 1.2f;
    public float GetSpawnInterval()
    {
        return spawnInterval / Mathf.Pow(spawnIntervalDivisor, weaponLevel - 1);
    }


    [Header("Shield Settings")]
    public bool isShield = false;
    [ShowIf("isShield")] public float chargeInterval = 10f;
    // [ShowIf("isShield")] public int chargeCount = 1;
    // [ShowIf("isShield")] public float addChargeCountPerLevel = 1;


    [Header("Explosion Settings")]
    public bool hasExplosion = false;
    [ShowIf("hasExplosion")] public GameObject explosionObject;
    [ShowIf("hasExplosion")] public float explosionDuration = 0.3f;
    [ShowIf("hasExplosion")] public float explosionDurationMultiplier = 1.1f;
    public float GetExplosionDuration()
    {
        return explosionDuration * Mathf.Pow(explosionDurationMultiplier, weaponLevel - 1);
    }
    [ShowIf("hasExplosion")] public float explosionDamage = 10f;
    [ShowIf("hasExplosion")] public float explosionDamageMultiplier = 1.2f;
    public float GetExplosionDamage()
    {
        return explosionDamage * Mathf.Pow(explosionDamageMultiplier, weaponLevel - 1);
    }


    [Header("Lingering Effect Settings")]
    public bool hasLingeringEffect = false;


    [Header("Level Settings")]
    public int weaponMaxLevel = 5;
    public int weaponLevel = 1;
    public bool isMaxLevel => weaponLevel >= weaponMaxLevel;

    // multiplier ları 1f e koymak seviye atladıkça birşeyin değişmemesini sağlar
    public float damageMultiplier = 1.2f;
    public float GetDamage()
    {   // damageMultiplier ın weaponLevel - 1. kuvveti ile çarp
        return damageAmount * Mathf.Pow(damageMultiplier, weaponLevel - 1);
    }

    public float sizeMultiplier = 1f;
    private Vector3 scale;
    public Vector3 GetSize()
    {
        scale = weaponPrefab.transform.localScale;
        return scale * MathF.Pow(sizeMultiplier, weaponLevel - 1);
    }



    [ShowIf("isProjectile")] public float fireRateMultiplier = 1.2f;
    [HideInInspector] public float fireRateModifier = 1f;
    public float GetFireRate()
    {
        return fireRate * Mathf.Pow(fireRateMultiplier, weaponLevel - 1) * fireRateModifier;
    }


    public bool isProjectileOrOrbittingProjectile()
    {
        return isProjectile || isOrbittingWeapon;
    }
    [ShowIf("isProjectileOrOrbittingProjectile")] public float speedMultiplier = 1.2f;
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

    [ShowIf("isFloatingWeapon")] public float cooldownMultiplier = 1.2f;
    public float GetCooldownTimer()
    {
        return cooldownTimer / Mathf.Pow(cooldownMultiplier, weaponLevel - 1);
    }
}
