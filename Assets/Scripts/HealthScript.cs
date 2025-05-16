using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public GameObject gameOverScreen;
    public bool isPlayer = true;
    public Slider healthBar;
    public EnemyData enemyData;

    void Start()
    {
        if (enemyData != null)
        {
            maxHealth = enemyData.maxHealth;
        }
        currentHealth = maxHealth;

        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
    }

    public void TakeDamage(float damage)
    {
        // EnemyMovement enemyMovement = GetComponent<EnemyMovement>();
        // if (enemyMovement != null)
        // {
        //     enemyMovement.Stun(weaponData.stunDuration)
        // }

        // düşmana flaş uygular
        DamageFlash damageFlash = GetComponent<DamageFlash>();
        if (damageFlash != null)
        {
            damageFlash.Flash();
        }

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }
    }

    public void Die()
    {
        if (isPlayer)
        {
            gameObject.SetActive(false);
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else // isEnenmy
        {
            Destroy(gameObject);
            GameObject.FindWithTag("Player").GetComponent<PlayerExp>().GainXP(enemyData.xpAmount);
        }
    }
}
