using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public EnemyData enemyData;
    public bool isStunned = false;
    private SpriteRenderer spriteRenderer;
    bool lookingRight;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        lookingRight = spriteRenderer.flipX;
    }

    void Update()
    {
        if (player == null || isStunned == true) return;

        // oyuncu ve düşman pozisyonlarını değişkene aktar
        Vector3 playerPos = player.position;
        Vector3 enemyPos = transform.position;

        Vector3 direction = (playerPos - enemyPos).normalized; // yönü oyuncunun pozisyonundan düşmanın pozisyonunu çıkartarak bul ve genişliği sabit tut
        enemyPos += direction * enemyData.moveSpeed * Time.deltaTime; // bulunan yönde düşmanı hareket ettir
        transform.position = enemyPos;

        // sağa sola bakma
        if (direction.x > 0) 
        {
            spriteRenderer.flipX = lookingRight; // sağa döndür
        }
        else if (direction.x < 0)
        {
            spriteRenderer.flipX = !lookingRight; // sola döndür
        }
    }

    public void Stun(float stunDuration)
    {
        if (isStunned == true) return;
        StartCoroutine(StunCoroutine(stunDuration));
    }

    private IEnumerator StunCoroutine(float stunDuration)
    {
        isStunned = true;
        yield return new WaitForSeconds(stunDuration);
        isStunned = false;
    }
}
