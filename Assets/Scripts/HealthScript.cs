using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public float currentHealth;
    public GameObject gameOverScreen;
    public bool isPlayer = true;
    public Slider healthBar;
    public EnemyData enemyData;
    public PlayerStats playerData;
    public TextMeshProUGUI healthLabel;

    void Start()
    {
        if (enemyData != null)
        {
            currentHealth = enemyData.maxHealth;
        }
        else if (playerData != null && healthBar != null)
        {
            currentHealth = playerData.playerHealth;
            healthBar.maxValue = playerData.playerHealth;
            healthBar.value = currentHealth;
            healthLabel.text = currentHealth.ToString("f0");
        }
    }

    public void TakeDamage(float damage)
    {
        if (gameObject.tag == "Player")
        {
            currentHealth -= damage - ( damage * playerData.resistancePercentage / 100 );
        }
        else if (gameObject.tag == "Enemy")
        {
            currentHealth -= damage;
        }
        
        // can barı ayarlamaları
        if (healthLabel != null)
        {
            healthLabel.text = currentHealth.ToString("f0");
            if (healthLabel.text == "0")
            {
                healthLabel.text = "1";
            }
        }

        if (currentHealth <= 0)
            {
                currentHealth = 0;

                if (healthLabel != null)
                { healthLabel.text = "0"; }

                Die();
            }

        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }
    }

    public void TakeDamage(float damage, WeaponData weaponData) // overload metod silahlar için
    {
        DamageFlash damageFlash = GetComponent<DamageFlash>();
        if (damageFlash != null)
        {
            damageFlash.Flash(weaponData.flashColor);
        }

        EnemyMovement enemyMovement = GetComponent<EnemyMovement>();
        if (enemyMovement != null)
        {
            enemyMovement.Stun(weaponData.stunDuration);
        }

        TakeDamage(damage);
    }

    public void TakeDamage(float damage, LingeringEffectData lingeringEffectData) // overload metod hasar alanları için
    {
        DamageFlash damageFlash = GetComponent<DamageFlash>();
        if (damageFlash != null)
        {
            damageFlash.Flash(lingeringEffectData.flashColor);
        }

        EnemyMovement enemyMovement = GetComponent<EnemyMovement>();
        if (enemyMovement != null)
        {
            enemyMovement.Stun(lingeringEffectData.stunDuration);
        }

        TakeDamage(damage);
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

    public void GainHealth(float health)
    {
        currentHealth += health;
    }
}
