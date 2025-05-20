using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    bool isQuitting = false;
    public GameObject essenceChestPrefab;
    public EnemyData enemyData;

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    void OnDestroy()
    {
        if (isQuitting || !gameObject.scene.isLoaded) return;

        float roll = Random.Range(0f, 1f);
        if (roll <= enemyData.lootDropChance)
        {
            Instantiate(essenceChestPrefab, transform.position, Quaternion.identity);
        }
    }
}
