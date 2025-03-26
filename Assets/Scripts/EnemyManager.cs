using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public SpawnerScript spawnerScript;

    public Enemy1 enemy1;

    public Enemy2 enemy2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            spawnerScript.SetEnemyType(enemy1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            spawnerScript.SetEnemyType(enemy2);
        }
    }
}
