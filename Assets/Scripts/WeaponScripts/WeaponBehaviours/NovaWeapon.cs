using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovaWeapon : MonoBehaviour, IWeaponBehaivour
{
    private WeaponData weaponData;
    private Transform playerTransform;
    private GameObject novaWeapon;
    public void Initialize(WeaponData weaponData, Transform playerTransform)
    {
        this.weaponData = weaponData;
        this.playerTransform = playerTransform;
        InvokeRepeating(nameof(Shoot), 1f, weaponData.GetSpawnInterval());
    }

    void Shoot()
    {
        novaWeapon = Instantiate(weaponData.weaponPrefab, playerTransform.position, Quaternion.identity);
    }

    public void UpdateBehaivour()
    {

    }

    public void ResetInvoke()
    {
        CancelInvoke(nameof(Shoot));
        InvokeRepeating(nameof(Shoot), weaponData.GetSpawnInterval(), weaponData.GetSpawnInterval());
    }
}
