using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovaWeapon : MonoBehaviour, IWeaponBehaivour
{
    private WeaponData weaponData;
    private Transform playerTransform;
    private GameObject novaWeapon;
    private float novaDuration;
    public void Initialize(WeaponData weaponData, Transform playerTransform)
    {
        this.weaponData = weaponData;
        this.playerTransform = playerTransform;
        InvokeRepeating(nameof(Shoot), 1f, weaponData.GetSpawnInterval());
    }

    void Shoot()
    {
        novaWeapon = Instantiate(weaponData.weaponPrefab, playerTransform.position, Quaternion.identity);
        novaWeapon.transform.localScale = weaponData.GetSize();
    }

    public void UpdateBehaivour() {}

    public void ResetInvoke()
    {
        CancelInvoke(nameof(Shoot));
        InvokeRepeating(nameof(Shoot), weaponData.GetSpawnInterval(), weaponData.GetSpawnInterval());
        Debug.Log("nova interval: " + weaponData.GetSpawnInterval());
    }
}
