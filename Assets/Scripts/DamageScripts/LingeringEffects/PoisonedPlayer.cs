using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonedPlayer : MonoBehaviour
{
    private float damageAmount;
    private float damageInterval;
    private float duration;
    private float timer = 0f;
    private HealthScript health;
    private EnemyWeaponData enemyWeaponData;

    public void Initialize(HealthScript health, EnemyWeaponData enemyWeaponData)
    {
        this.health = health;
        this.enemyWeaponData = enemyWeaponData;
        this.damageAmount = enemyWeaponData.damageAmount;
        this.duration = enemyWeaponData.duration;
        this.damageInterval = enemyWeaponData.damageInterval;
        timer = damageInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            health.TakeDamage(damageAmount);

            timer = damageInterval;
        }
        duration -= Time.deltaTime;
        if (duration <= 0f)
        {
            Destroy(this);
        }
    }
}
