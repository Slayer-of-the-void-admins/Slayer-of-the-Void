using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParticle : MonoBehaviour
{
    public GameObject deathParticle;
    private bool isQuitting = false;
    void OnApplicationQuit()
    {
        isQuitting = true;
    }

    void OnDestroy()
    {
        if (isQuitting || !gameObject.scene.isLoaded) return;

        Instantiate(deathParticle, transform.position, Quaternion.identity);
    }
}
