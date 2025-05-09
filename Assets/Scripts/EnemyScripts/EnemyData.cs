using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}