using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "EnemyData")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public GameObject enemyPrefab;
    public float moveSpeed = 2f;
    public float maxHealth = 100f;
    public int xpAmount = 10;
    public float damageAmount = 10f;
    public string targetTag = "Player";
    public float lootDropChance = 0f;

    public bool isRangedEnemy = false;
    [ShowIf("isRangedEnemy")]
    public float attackRange = 10f;
    [ShowIf("isRangedEnemy")]
    public float retreatRange = 0f;
    [ShowIf("isRangedEnemy")]
    public float fireCooldown = 0f;
}