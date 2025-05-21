    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class EnemyStraightProjectile : MonoBehaviour
    {
        public EnemyWeaponData enemyWeaponData;
        public Rigidbody2D rb;

        public void Initialize(EnemyWeaponData weaponData, Vector2 direction)
        {
            rb = GetComponent<Rigidbody2D>();

            rb.velocity = direction.normalized * weaponData.projectileSpeed;


            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // Çarpýlan nesnenin tag'i hedef tag ile eþleþiyor mu?
            if (collision.CompareTag(enemyWeaponData.targetTag))
            {
                // Hasar verme iþlemi (örneðin PlayerHealth varsa çaðýr)
                var health = collision.GetComponent<HealthScript>();

                if (health != null)
                {
                    if (enemyWeaponData.isPoisonedWeapon)
                    {
                        PoisonedPlayer poisonedPlayer = collision.GetComponent<PoisonedPlayer>();
                    
                        if (poisonedPlayer == null)
                        {
                            poisonedPlayer = collision.gameObject.AddComponent<PoisonedPlayer>();
                            poisonedPlayer.Initialize(health, enemyWeaponData);
                        }
                    }
                    else
                    {
                        health.TakeDamage(enemyWeaponData.damageAmount);
                    }
                }

                if (enemyWeaponData.destroySelfOnCollision)
                {
                    Destroy(gameObject);
                }
            }

        }
    }
