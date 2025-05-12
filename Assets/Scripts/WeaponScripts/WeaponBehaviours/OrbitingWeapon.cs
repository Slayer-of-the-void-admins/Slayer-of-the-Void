using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitingWeapon : MonoBehaviour, IWeaponBehaivour
{
    private WeaponData weaponData;
    private Transform playerTransform;
    private GameObject orbitingWeapon;
    public void Initialize(WeaponData weaponData, Transform playerTransform)
    {
        this.weaponData = weaponData;
        this.playerTransform = playerTransform;
        Shoot();
    }

    public void UpdateBehaivour()
    {
        // silahı oyuncu etrafında döndür
        float angle = Time.time * weaponData.GetSpeed();
        Vector3 offset = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * weaponData.orbitDistance;
        orbitingWeapon.transform.position = playerTransform.position + offset;

        // silah sürekli oyuncunun tersi yönüne baksın
        orbitingWeapon.transform.rotation = Quaternion.LookRotation(Vector3.back, orbitingWeapon.transform.position - playerTransform.position);

        BuffDamage();
    }

    void Shoot()
    {
        orbitingWeapon = Instantiate(weaponData.weaponPrefab, playerTransform.position, Quaternion.identity);
    }

    void BuffDamage()
    {
        DamageScript damageScript = orbitingWeapon.GetComponent<DamageScript>();
        if (damageScript != null)
        {
            damageScript.damageAmount = weaponData.GetDamage();
        }
    }
}
