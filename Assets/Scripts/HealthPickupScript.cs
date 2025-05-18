using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupScript : MonoBehaviour
{
    public GameObject healtPickupPrefab;

    public Vector2 spawnAreaMin = new Vector2(-100, -100);

    public Vector2 spawnAreaMax = new Vector2(100, 100);

    public float spawnInterval = 100f; 

    public int healAmount = 20;

    void Start()
    {
        InvokeRepeating(nameof(SpawnHealthPickups), 10f, spawnInterval);
    }

    public void SpawnHealthPickups()
    {
        Vector2 randomPosition = new Vector2(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y)
        );

        Instantiate(healtPickupPrefab, randomPosition, Quaternion.identity);
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
