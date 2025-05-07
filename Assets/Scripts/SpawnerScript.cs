using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public EnemyData enemyData;
    public Transform player;
    public float spawnRate = 2f;
    public float spawnDistance = 10f;

    void Start()
    {
        // SpawnEnenmy metodu oyun başladıktan 1f sonra bir kere çalışır sonra her spawnRate sürsinde birdaha çalışır
        InvokeRepeating(nameof(SpawnEnemy), 1f, enemyData.spawnRate);
    }

    void SpawnEnemy()
    {
        if (player == null) return;

        Vector2 spawnPosition = (Vector2)player.position + Random.insideUnitCircle.normalized * spawnDistance; // düşmanın doğacağı pozisyonu rastgele seç

        GameObject enemy = Instantiate(enemyData.enemyPrefab, spawnPosition, Quaternion.identity); // düşmanı seçilen pozisyonda çağır

        enemy.GetComponent<EnemyMovement>().player = player; // çağırılan düşmandaki hareket scriptine oyuncu nesnesini aktar
    }

    public void SetEnemyType(EnemyData newEnemyData) // düşman tipini değiştirmek için kullanılan metod
    {
        enemyData = newEnemyData;
        RestartSpawn();
    }

    private void RestartSpawn()
    {
        CancelInvoke(nameof(SpawnEnemy));
        if (enemyData != null)
        {
            InvokeRepeating(nameof(SpawnEnemy), 0f, enemyData.spawnRate);
        }
    }
}