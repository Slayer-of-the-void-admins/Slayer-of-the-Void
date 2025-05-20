using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    private float damageAmount;
    private float duration;
    public WeaponData weaponData;

    void Awake()
    {
        // gerekli verileri doldur
        this.damageAmount = weaponData.GetExplosionDamage();
        this.duration = weaponData.GetExplosionDuration();
    }

    void Start()
    {
        // patlamanın colliderına dokunan hedefleri diziye al
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, GetComponent<CircleCollider2D>().radius);

        // dizideki düşmanların canını azalt
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damageAmount, weaponData);
                }
            }
        }

        // patlama efektini süre bittikten sonra yok et
        Destroy(gameObject, duration);
    }
}
