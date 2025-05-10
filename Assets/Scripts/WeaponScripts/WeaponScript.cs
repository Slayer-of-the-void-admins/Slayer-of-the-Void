using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public WeaponData weaponData;

    void Start()
    {
        Debug.Log($"WeaponScript Start called on {gameObject.name}");
        InvokeRepeating(nameof(Shoot), 1f, weaponData.fireRate);
    }

    void Shoot()
    {
            // Debug.Log($"Shooting from {weaponData.weaponName}");

            // silahı çağır
            GameObject weapon = Instantiate(weaponData.weaponPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = weapon.GetComponent<Rigidbody2D>();

            // imleç pozisyonunu kullanarak atış yönü belirle
            Vector3 playerPos = transform.position;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Vector2 aimDirection = (mousePos - playerPos).normalized;

            rb.velocity = aimDirection * weaponData.projectileSpeed;
    }
}