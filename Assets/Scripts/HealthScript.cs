using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
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
    private AudioSource hurtSound;
    private float hurtSoundCooldown = 0.125f;
    private float lastHurtSoundTime = -999f;
    void Start()
    {
        if (enemyData != null && isPlayer == false)
        {
            currentHealth = enemyData.maxHealth;
        }
        else if (playerData != null && healthBar != null && isPlayer == true)
        {
            currentHealth = playerData.playerHealth;
            healthBar.maxValue = playerData.playerHealth;
            healthBar.value = currentHealth;
            healthLabel.text = currentHealth.ToString("f0");

            hurtSound = GetComponent<AudioSource>();
        }
    }


    public void TakeDamage(float damage)
    {
        if (gameObject.tag == "Player" && gameObject.activeSelf == true)
        {
            currentHealth -= damage - (damage * playerData.resistancePercentage / 100);

            // geçici oyuncuyu damage flash
            DamageFlash damageFlash = GetComponent<DamageFlash>();
            if (damageFlash != null)
            {
                damageFlash.Flash(Color.red, .125f);
            }

            // can acıma sesi
            if (Time.time - lastHurtSoundTime >= hurtSoundCooldown)
            {
                hurtSound.Play();
                lastHurtSoundTime = Time.time;
            }                

        }
        else if (gameObject.tag == "Enemy")
        {
            currentHealth -= damage + (damage * playerData.damagePercentage / 100);
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
            damageFlash.Flash(weaponData.flashColor, weaponData.flashDuration);
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
            damageFlash.Flash(lingeringEffectData.flashColor, lingeringEffectData.flashDuration);
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
            // düşman currentAmount azalt
            enemyData.currentAmount--;

            // düşmanı yok et
            Destroy(gameObject);

            // seviye kazandır
            PlayerExp playerExp = GameObject.FindWithTag("Player")?.GetComponent<PlayerExp>();
            if (playerExp != null && enemyData != null)
            {
                playerExp.GainXP(enemyData.xpAmount);
            }
        }
    }

    public void GainHealth(float health)
    {
        currentHealth += health;
    }
    
    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, playerData.playerHealth);  
        
        if (healthLabel != null)
        {
            healthLabel.text = currentHealth.ToString("f0");
        }
        
        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }
    }
}
