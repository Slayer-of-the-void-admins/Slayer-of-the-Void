using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    public GameObject healthPickupPrefab;

    public Vector2 spawnAreaMin = new Vector2(-100, -100);

    public Vector2 spawnAreaMax = new Vector2(100, 100);

    public float spawnInterval = 10f;

    // public SpawnerScript spawnerScript;

    public int maxPickupCount = 5;

    void Start()
    {
        InvokeRepeating(nameof(SpawnHealthPickups), 10f, spawnInterval);
    }

    public void SpawnHealthPickups()
    {
        int currentPickupCount = GameObject.FindGameObjectsWithTag("HealthPickup").Length;
        // maxPickupCount = spawnerScript.spawnSet.maxHealthPickup;

        if (currentPickupCount >= maxPickupCount)
        {
            return;
        }

        Vector2 randomPosition = new Vector2(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y)
        );

        Instantiate(healthPickupPrefab, randomPosition, Quaternion.identity);
        spawnInterval = Random.Range(10, 30);
    }
}
