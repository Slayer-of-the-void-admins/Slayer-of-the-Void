using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour, IWeaponBehaivour
{
    private WeaponData weaponData;
    private Transform playerTransform;

    public void Initialize(WeaponData weaponData, Transform playerTransform)
    {
        this.weaponData = weaponData;
        this.playerTransform = playerTransform;
    }

    public void UpdateBehaivour()
    {

    }

    // public bool 
    public void ChargeShield()
    {

    }

    public void UpdateAmountOfCollisionBeforeDestroy()
    {
        weaponData.amountOfCollisionBeforeDestroy = weaponData.GetAmountOfCollisionBeforeDestroy();
    }
}
