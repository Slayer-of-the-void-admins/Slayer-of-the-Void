using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Scripting.APIUpdating;

public class DamageScript : MonoBehaviour
{
    private GameObject player;
    public EnemyData enemyData;
    public WeaponData weaponData;
    public string targetTag;
    public float damageAmount;

    void Start() // targetTag ve damageAmount değişkenleri objenin türüne göre seç
    {
        player = GameObject.FindWithTag("Player");
        if (weaponData != null)
        {
            targetTag = weaponData.targetTag; // "Enemy"
            damageAmount = weaponData.GetDamage();
            // oyuncu hasar multiplierını çarp
        }
        else if (enemyData != null)
        {
            targetTag = enemyData.targetTag; // "Player"
            damageAmount = enemyData.damageAmount;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag(targetTag) == true) // dokunduğu objenin tagi targetTag ise çalış
        {
            // çarpılan objenin canına hasar ver. çarpan silah yok olmalıysa yok et
            HealthScript health = other.GetComponent<HealthScript>();
            if (health != null)
            {
                if (targetTag == "Enemy")
                {
                    health.TakeDamage(damageAmount, weaponData);
                }
                else if (targetTag == "Player")
                {
                    health.TakeDamage(damageAmount);
                }
                
                // if (weaponData?.destroySelfOnCollision == true)
                // {
                //     Destroy(gameObject);
                // }
            }

            // düşmanlar oyuncuya çarpınca hafif geri zıplasın
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
            yield return new WaitForSeconds(stepDelay);
        }
    }
}
