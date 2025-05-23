using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public EnemySpawnSet spawnSet;
    public List<EnemySpawnSet> spawnSetList;
    public Transform player;
    public float spawnDistance = 20f;
    public HealthPickupScript healthPickupScript;

    void Start()
    {
        // SpawnEnenmy metodu oyun başladıktan 1f sonra bir kere çalışır sonra her spawnRate sürsinde birdaha çalışır
        if (spawnSet != null)
        {
            InvokeRepeating(nameof(SpawnEnemy), 1f, 1f / spawnSet.globalSpawnRate);
            Debug.Log("spawn " + spawnSet.globalSpawnRate + " per second");
        }
    }

    void SpawnEnemy()
    {
        if (player == null || spawnSet == null) return;

        EnemyData chosenEnemy = ChooseEnemyType();
        if (chosenEnemy == null) return;

        Vector2 spawnPosition = (Vector2)player.position + UnityEngine.Random.insideUnitCircle.normalized * spawnDistance; // düşmanın doğacağı pozisyonu rastgele seç
        GameObject enemy = Instantiate(chosenEnemy.enemyPrefab, spawnPosition, Quaternion.identity); // düşmanı seçilen pozisyonda çağır

        if (chosenEnemy.isRangedEnemy)
        {
            enemy.GetComponent<RangedEnemyMovement>().player = player; // çağırılan düşmandaki hareket scriptine oyuncu nesnesini aktar
        }
        else 
        {
            enemy.GetComponent<EnemyMovement>().player = player; // çağırılan düşmandaki hareket scriptine oyuncu nesnesini aktar
        }
    }

    private EnemyData ChooseEnemyType()
    {
        float totalChance = 0f;
        foreach (var enemy in spawnSet.enemiesToSpawn)
        {
            totalChance += enemy.spawnChance; // totalChance 100 olacak (her spawnSet toplam spawnChance 100)
        }
        
        float roll = UnityEngine.Random.Range(0f, totalChance); // 0 ile totalChance arasında bir değer döndür
        float cumulative = 0f;
        foreach (var enemy in spawnSet.enemiesToSpawn) // döndürülen değer düşan doğma şansından küçük olduğunda çağır
        {
            cumulative += enemy.spawnChance;
            if (roll <= cumulative)
            {
                int maxOfTheEnemy = Mathf.RoundToInt(enemy.spawnChance * 300);
                if (enemy.enemyData.currentAmount >= maxOfTheEnemy)
                {
                    continue;
                }
                enemy.enemyData.currentAmount++;
                return enemy.enemyData;
            }
        }
        return null;
    }

    public void SetSpawnSet(EnemySpawnSet newSet) // spawnSet değişiminde prosedür yeniden başlar
    {
        CancelInvoke(nameof(SpawnEnemy));
        spawnSet = newSet;
        healthPickupScript.maxPickupCount = spawnSet.maxHealthPickup;
        InvokeRepeating(nameof(SpawnEnemy), 0f, 1f / spawnSet.globalSpawnRate);
    }
}
