using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Collections;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public float damageAmount = 10f;
    public bool destroySelf = false;
    public string targetTag = "Player";
    public GameObject player;
    public float pushForce = 100f;
    public float pushDuration = 1.5f;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag(targetTag) == true) // dokunduğu objenin tagi targetTag ise çalış
        {
            HealthScript health = other.GetComponent<HealthScript>();
            if (health != null)
            {
                health.TakeDamage(damageAmount);
                if (destroySelf == true)
                {
                    Destroy(gameObject);
                }
            }

            if (targetTag == "Player") // hedef alınan tag player olan sadece düşmanlar için çalışan ittirme sistemi
            {
                Vector3 dealerPosition = gameObject.transform.position;
                Vector3 playerPosition = player.transform.position;

                Vector3 direction = (dealerPosition - playerPosition).normalized;

                StartCoroutine(pushBack(direction));
            }
            
        }
        else
        {
            return;
        }
    }

    private IEnumerator pushBack(Vector3 direction) // düşmanı adım adım geri ışınlayarak itme ilüzyonunu sağlayan coroutine
    {
        int steps = 10;
        float stepDistance = .5f;
        float stepDelay = 0.01f;

        for (int i = 1; i <= steps; i++)
        {
            transform.position += direction * stepDistance;
            // dealerPosition += direction * .25f;
            // gameObject.transform.position = dealerPosition;
            yield return new WaitForSeconds(stepDelay);
        }
    }
}
