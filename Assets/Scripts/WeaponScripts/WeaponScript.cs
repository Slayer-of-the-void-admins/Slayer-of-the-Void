using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public WeaponData weaponData;
    private GameObject weapon;

    void Start()
    {
        if (weaponData.isProjectile == true)
        {
            InvokeRepeating(nameof(Shoot), 1f, 1 / weaponData.GetFireRate());
        }
        else 
        {
            Shoot();
        }
    }

    void Update()
    {
        if (weaponData.isProjectile == false && weapon != null)
        {
            // silahı oyuncu etrafında döndür
            float angle = Time.time * weaponData.GetSpeed();
            Vector3 offset = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * weaponData.orbitDistance;
            weapon.transform.position = transform.position + offset;

            // silah sürekli oyuncunun tersi yönüne baksın
            weapon.transform.rotation = Quaternion.LookRotation(Vector3.back, weapon.transform.position - transform.position);
        }
    }

    void Shoot()
    {
        if (weaponData.isProjectile == true)
        {
            // silahı çağır
            weapon = Instantiate(weaponData.weaponPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = weapon.GetComponent<Rigidbody2D>();

            // imleç pozisyonunu kullanarak atış yönü belirle
            Vector3 playerPos = transform.position;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Vector2 aimDirection = (mousePos - playerPos).normalized;

            rb.velocity = aimDirection * weaponData.GetSpeed();
        }
        else // atılabilir olmayan silah
        {
            weapon = Instantiate(weaponData.weaponPrefab, transform.position, Quaternion.identity);
        }

        BuffDamage();
    }

    void BuffDamage()
    {
        DamageScript damageScript = weapon.GetComponent<DamageScript>();
        if (damageScript != null)
        {
            damageScript.damageAmount = weaponData.GetDamage();
        }
    }
}
