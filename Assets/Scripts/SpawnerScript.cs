using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject enemyPrefab;

    public Transform player;

    public float spawnRate = 2f;

    public float spawnDistance = 10f;

    // Start is called before the first frame update
    void Start()
    {
        // SpawnEnenmy metodu oyun başladıktan 1f sonra bir kere çalışır sonra her spawnRate sürsinde birdaha çalışır
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnRate); 
    }

    // Update is called once per frame
    void SpawnEnemy()
    {
        if (player == null) return;

        Vector2 spawnPosition = (Vector2)player.position + Random.insideUnitCircle.normalized * spawnDistance; // düşmanın doğacağı pozisyonu rastgele seç

        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity); // düşmanı seçilen pozisyonda çağır

        enemy.GetComponent<EnemyMovement>().player = player; // çağırılan düşmandaki hareket scriptine oyuncu nesnesini aktar
    }

    void SetEnemyPrefab(GameObject newEnemyPrefab)
    {
        enemyPrefab = newEnemyPrefab;
    }

    void SetSpawnRate(float newSpawnRate)
    {
        spawnRate = newSpawnRate;
    }
}
