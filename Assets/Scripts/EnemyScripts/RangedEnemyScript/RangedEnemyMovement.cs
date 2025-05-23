using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyMovement : MonoBehaviour
{
    public Transform player;
    public EnemyData enemyData;
    public EnemyWeaponData enemyWeaponData;
    public bool isStunned = false;

    private SpriteRenderer spriteRenderer;
    private float lastTimeFire;
    public Transform firePoint;

    bool lookingRight;
    private Animator enemyAnimator;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyAnimator = GetComponent<Animator>();

    }

    void Update()
    {
        if (player == null || isStunned == true)
        {
            if (enemyAnimator != null)
            {
                if (enemyAnimator.speed != 0)
                    enemyAnimator.speed = 0;
            }
            return;
        }

        if (enemyAnimator != null)
        {
            if (enemyAnimator.speed != 1)
                enemyAnimator.speed = 1;
        }


        float distancePlayer = Vector2.Distance(transform.position, player.position);
        Vector3 direction = (player.position - transform.position).normalized;

        if (distancePlayer < enemyData.retreatRange)
        {
            transform.position -= direction * enemyData.moveSpeed * Time.deltaTime;
        }
        else if (distancePlayer <= enemyData.attackRange)
        {
            if (Time.time - lastTimeFire > enemyData.fireCooldown)
            {
                FireProjectile(direction);
                lastTimeFire = Time.time;
            }
        }
        else
        {
            transform.position += direction * enemyData.moveSpeed * Time.deltaTime;
        }

        if (direction.x > 0)
        {
            spriteRenderer.flipX = lookingRight;
        }
        else if (direction.x < 0)
        {
            spriteRenderer.flipX = !lookingRight;
        }
    }

    void FireProjectile(Vector3 direction)
    {
        GameObject projectile = Instantiate(enemyWeaponData.weaponPrefab, firePoint.position, Quaternion.identity);

        EnemyStraightProjectile projectileScript = projectile.GetComponent<EnemyStraightProjectile>();

        if (projectileScript != null)
        {

            projectileScript.Initialize(enemyWeaponData, direction);

        }
        else
        {
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction.normalized * enemyWeaponData.projectileSpeed;
            }
            else
            {
                Debug.LogWarning("Projectile prefab'�nda EnemyStraightProjectile veya Rigidbody2D yok!");
            }
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

    // public void Stun(float stunDuration)
    // {
    //     if (isStunned) return;
    //     StartCoroutine(StunCoroutine(stunDuration));
    // }

    // private IEnumerator StunCoroutine(float stunDuration)
    // {
    //     isStunned = true;
    //     yield return new WaitForSeconds(stunDuration);
    //     isStunned = false;
    // }    
}
