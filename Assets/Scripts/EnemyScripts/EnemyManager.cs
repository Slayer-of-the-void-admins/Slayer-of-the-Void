using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public SpawnerScript spawnerScript;
    public EnemyData enemy1Data;
    public EnemyData enemy2Data;

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Alpha1)) // klavyede 1 e bastığında enemy1 çağırılır
        // {
        //     spawnerScript.SetSpawnSet(enemy1Data);
        // }

        // if (Input.GetKeyDown(KeyCode.Alpha2)) // klavyede 2 ye bastığında enemy2 çağırılır
        // {
        //     spawnerScript.SetSpawnSet(enemy2Data);
        // }
    }
}