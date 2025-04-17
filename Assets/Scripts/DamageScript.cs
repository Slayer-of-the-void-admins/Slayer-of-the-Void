using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public float damageAmount = 10f;
    public bool destroySelf = false;
    public string targetTag = "Player";
    public GameObject player;

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

            if (targetTag == "Player") // temp push system - learn rigidbody force and rewrite
            {
                Vector3 dealerPosition = gameObject.transform.position;
                Vector3 playerPosition = player.transform.position;

                Vector3 direction = (dealerPosition - playerPosition).normalized;

                dealerPosition += direction * 5f;
                gameObject.transform.position = dealerPosition;
            }
            
        }
        else
        {
            return;
        }
    }
}
