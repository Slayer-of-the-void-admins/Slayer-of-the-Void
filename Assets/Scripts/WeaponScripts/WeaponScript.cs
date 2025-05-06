using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public GameObject weapon1;
    public float projectileSpeed = 20f;
    public float fireRate = 1f;

    void Start()
    {
        InvokeRepeating(nameof(Shoot), 1f, fireRate);
    }

    void Update()
    {
    }

    void Shoot()
    {
        GameObject weapon = Instantiate(weapon1, transform.position, Quaternion.identity);
        Rigidbody2D rb = weapon.GetComponent<Rigidbody2D>();

        Vector3 playerPos = transform.position;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector2 aimDirection = (mousePos - playerPos).normalized;

        rb.velocity = aimDirection * projectileSpeed;
    }
}
