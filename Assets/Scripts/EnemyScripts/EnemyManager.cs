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
        if (Input.GetKeyDown(KeyCode.Alpha1)) // klavyede 1 e bastığında enemy1 çağırılır
        {
            spawnerScript.SetEnemyType(enemy1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) // klavyede 2 ye bastığında enemy2 çağırılır
        {
            spawnerScript.SetEnemyType(enemy2);
        }
    }
}