using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour, IWeaponBehaivour
{
    private WeaponData weaponData;
    private Transform playerTransform;
    public GameObject shield;
    private float timer;
    private DestroySelf destroySelf;

    public void Initialize(WeaponData weaponData, Transform playerTransform)
    {
        this.weaponData = weaponData;
        this.playerTransform = playerTransform;
        timer = weaponData.chargeInterval;

        SummonShield();
    }

    public void UpdateBehaivour()
    {
        if (shield != null)
        {
            // kalkan oyuncuyu takip etsin
            shield.transform.position = playerTransform.position;

            // kalkan recharge logic
            if (destroySelf.amountOfCollisionBeforeDestroy < weaponData.GetAmountOfCollisionBeforeDestroy())
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    ChargeShield();
                    timer = weaponData.chargeInterval;
                }
            }
        }
        else
        {
            // kalkan yoksa çağır
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SummonShield();
                timer = weaponData.chargeInterval;
            }
        }
    }

    public void SummonShield()
    {
        shield = Instantiate(weaponData.weaponPrefab, playerTransform.position, Quaternion.identity);
        destroySelf = shield.GetComponent<DestroySelf>();
        destroySelf.amountOfCollisionBeforeDestroy = weaponData.defaultAmountOfCollisionPerDestroy;
    }

    public void ChargeShield()
    {
        if (destroySelf.amountOfCollisionBeforeDestroy < weaponData.GetAmountOfCollisionBeforeDestroy())
        {
            destroySelf.amountOfCollisionBeforeDestroy++;
        }
    }

    public void UpdateAmountOfCollisionBeforeDestroy()
    {
        weaponData.amountOfCollisionBeforeDestroy = weaponData.GetAmountOfCollisionBeforeDestroy();
    }
}
