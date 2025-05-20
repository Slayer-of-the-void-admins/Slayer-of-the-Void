using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSpawner : MonoBehaviour
{
    public WeaponData weaponData;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // silah patlamalıysa ve çarpılan obje düşmman ise patlamayı çağır
        if (weaponData.hasExplosion && other.CompareTag("Enemy"))
        {
            SpawnExplosion();
        }
    }

    void SpawnExplosion()
    {
        Instantiate(weaponData.explosionObject, transform.position, Quaternion.identity);
    }
}
