using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    bool isQuitting = false;
    public GameObject essenceChestPrefab;
    public EnemyData enemyData;
    public int maxChestCount = 20;

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    void OnDestroy()
    {
        int currentChestCount = GameObject.FindGameObjectsWithTag("ChestPickup").Length;
        if (isQuitting || !gameObject.scene.isLoaded || currentChestCount >= maxChestCount) return;

        float roll = Random.Range(0f, 1f);
        if (roll <= enemyData.lootDropChance)
        {
            Instantiate(essenceChestPrefab, transform.position, Quaternion.identity);
        }
    }
}
