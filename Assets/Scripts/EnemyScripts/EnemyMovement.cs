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
    private Animator enemyAnimator;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        lookingRight = spriteRenderer.flipX;
        enemyAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player == null || isStunned == true)
        {
            enemyAnimator.speed = 0;
            return;
        }
        enemyAnimator.speed = 1;

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

    private Coroutine stunCoroutine;
    private float stunEndTime = 0f;

    public void Stun(float stunDuration)
    {
        float newEndTime = Time.time + stunDuration;
        if (newEndTime > stunEndTime)
        {
            stunEndTime = newEndTime;

            if (stunCoroutine != null)
            {
                StopCoroutine(stunCoroutine);
            }
            stunCoroutine = StartCoroutine(StunCoroutine());
        }
    }

    private IEnumerator StunCoroutine()
    {
        isStunned = true;

        while (Time.time < stunEndTime)
        {
            yield return null;
        }

        isStunned = false;
        stunCoroutine = null;
    }
}
