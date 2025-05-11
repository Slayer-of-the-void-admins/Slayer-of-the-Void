using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemySpawnSet", menuName = "EnemySpawnSet")]
public class EnemySpawnSet : ScriptableObject // spawnSet ler çağırılacak düşman bilgilerini ve şanslarını tutuyor
{
    public float globalSpawnRate = 1f;
    public SpawnEntry[] enemiesToSpawn;

    [Serializable]
    public class SpawnEntry
    {
        public EnemyData enemyData;

        [Range(0f, 1f)]
        public float spawnChance;
    }
}
