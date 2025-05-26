using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PullEnemies : MonoBehaviour
{

    public LingeringEffectData lingeringEffectData;
    private float sizeX;
    public float pullRadius = 5f;
    private float pullForce = 10f;
    private float duration = 3f;
    private List<EnemyMovement> pulledEnemies = new List<EnemyMovement>();

    void Awake()
    {
        pullForce = lingeringEffectData.pullForce;
        duration = lingeringEffectData.duration;
    }

    void Start()
    {
        sizeX = gameObject.transform.localScale.x;
        Debug.Log(sizeX);
        pullRadius *= sizeX/5;

        StartCoroutine(BlackholeRoutine());
    }

    void Update()
    {

    }
    
    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     // halkaya girenleri sabitle
    //     if (collision.CompareTag("Enemy"))
    //     {
    //         EnemyMovement enemyMovement = collision.GetComponent<EnemyMovement>();
    //         if (enemyMovement != null)
    //         {
    //             enemyMovement.enabled = false;
    //             pulledEnemies.Add(enemyMovement);
    //         }
    //     }
    // }

    private IEnumerator BlackholeRoutine()
    {
        float timer = 0f;

        // halkaladakileri bir süre boyunca merkeze çek
        while (timer < duration)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, pullRadius);
            foreach (Collider2D col in colliders)
            {
                if (col.CompareTag("Enemy"))
                {
                    EnemyMovement enemyMovement = col.GetComponent<EnemyMovement>();
                    if (enemyMovement != null && !pulledEnemies.Contains(enemyMovement))
                    {
                        enemyMovement.enabled = false;
                        pulledEnemies.Add(enemyMovement);
                    }

                    Rigidbody2D rb = col.GetComponent<Rigidbody2D>();
                    if (rb != null)
                    {
                        Vector2 direction = (transform.position - col.transform.position).normalized;
                        rb.MovePosition(rb.position + direction * pullForce * Time.deltaTime);
                    }


                }
            }
            timer += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }

        // kara deliği yok et
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        // Kara deliğin etkisi bittikten sonra düşman hareketlerini tekrar aç
        foreach (var movement in pulledEnemies)
        {
            if (movement != null)
                movement.enabled = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, pullRadius);
    }
}
