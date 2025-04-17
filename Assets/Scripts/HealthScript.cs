using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public GameObject gameOverScreen;
    public bool isPlayer = true;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
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
        else
        {
            Destroy(gameObject);
        }
    }
}
