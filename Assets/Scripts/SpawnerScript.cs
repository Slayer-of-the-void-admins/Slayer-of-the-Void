using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public Enemy1 enemy1;

    public Enemy2 enemy2;

    public GameObject enemyPrefab;

    public Transform player;

    public float spawnRate = 2f;

    public float spawnDistance = 10f;

    void Start()
    {
        // SpawnEnenmy metodu oyun başladıktan 1f sonra bir kere çalışır sonra her spawnRate sürsinde birdaha çalışır
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnRate);
    }

    void SpawnEnemy()
    {
        if (player == null) return;

        Vector2 spawnPosition = (Vector2)player.position + Random.insideUnitCircle.normalized * spawnDistance; // düşmanın doğacağı pozisyonu rastgele seç

        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity); // düşmanı seçilen pozisyonda çağır

        enemy.GetComponent<EnemyMovement>().player = player; // çağırılan düşmandaki hareket scriptine oyuncu nesnesini aktar
    }

    public void SetEnemyType(MonoBehaviour enemyScript) // düşman tipini değiştirmek için kullanılan metod
    {
        switch(enemyScript)
        {
            case Enemy1 enemy1:
                enemyPrefab = enemy1.newEnemyPrefab;
                spawnRate = enemy1.newSpawnRate;
                RestartSpawn();
                break;
            case Enemy2 enemy2:
                enemyPrefab = enemy2.newEnemyPrefab;
                spawnRate = enemy2.newSpawnRate;
                RestartSpawn();
                break;
            default:
                Debug.LogWarning("düşman tipi yok");
                break;
        }
    }

    private void RestartSpawn()
    {
        CancelInvoke(nameof(SpawnEnemy));
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnRate);
    }
}