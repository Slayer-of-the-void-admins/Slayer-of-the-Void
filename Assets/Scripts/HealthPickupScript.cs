using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupScript : MonoBehaviour
{
    public GameObject healthPickupPrefab;

    public Vector2 spawnAreaMin = new Vector2(-100, -100);

    public Vector2 spawnAreaMax = new Vector2(100, 100);

    public float spawnInterval = 10f;

    public int healAmount = 20;

    void Start()
    {
        spawnInterval = Random.Range(10, 30);
        InvokeRepeating(nameof(SpawnHealthPickups), 10f, spawnInterval);
    }

    public void SpawnHealthPickups()
    {
        int currentPickupCount = GameObject.FindGameObjectsWithTag("HealthPickup").Length;
        if (currentPickupCount >= 5)
        {
            return;
        }

        Vector2 randomPosition = new Vector2(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y)
        );

        Instantiate(healthPickupPrefab, randomPosition, Quaternion.identity);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HealthScript playerHealth = other.GetComponent<HealthScript>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount);
                Destroy(gameObject);
            }
        }
    }
}
