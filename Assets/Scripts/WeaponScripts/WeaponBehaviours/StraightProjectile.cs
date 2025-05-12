using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightProjectile : MonoBehaviour, IWeaponBehaivour
{
    private WeaponData weaponData;
    private Transform playerTransform;
    private GameObject straightProjectile;
    private Rigidbody2D rb;

    public void Initialize(WeaponData weaponData, Transform playerTransform)
    {
        this.weaponData = weaponData;
        this.playerTransform = playerTransform;
        InvokeRepeating(nameof(Shoot), 1f, 1f / weaponData.GetFireRate());
    }

    public void UpdateBehaivour()
    {

    }

    void Shoot()
    {
        // silahı çağır
        straightProjectile = Instantiate(weaponData.weaponPrefab, playerTransform.position, Quaternion.identity);
        Rigidbody2D rb = straightProjectile.GetComponent<Rigidbody2D>();

        // imleç pozisyonunu kullanarak yön belirle
        Vector3 playerPos = transform.position;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector2 aimDirection = (mousePos - playerPos).normalized;

        rb.velocity = aimDirection * weaponData.GetSpeed();
    }
}
