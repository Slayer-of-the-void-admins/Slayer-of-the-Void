using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCurvedProjectile : MonoBehaviour, IWeaponBehaivour
{
    private WeaponData weaponData;
    private Transform playerTransform;

    public void Initialize(WeaponData weaponData, Transform playerTransform)
    {
        this.weaponData = weaponData;
        this.playerTransform = playerTransform;
        InvokeRepeating(nameof(Shoot), 1f, 1f / weaponData.GetFireRate());
    }

    public void UpdateBehaivour() { }

    void Shoot()
    {
        // oyuncu etrafında rastgele pozisyon seç
        Vector3 randomPos = (Vector2)playerTransform.position + Random.insideUnitCircle.normalized * Random.Range(weaponData.minAimRange, weaponData.maxAimRange);
        randomPos.z = 0;

        // yönü bul
        Vector3 direction = (randomPos - playerTransform.position).normalized;

        // silahı çağır
        GameObject projectile = Instantiate(weaponData.weaponPrefab, playerTransform.position + direction, Quaternion.identity);

        // silah gidecek yöne baksın
        projectile.transform.rotation = Quaternion.LookRotation(Vector3.back, projectile.transform.position - playerTransform.position);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        StartCoroutine(MoveAndDestroy(rb, randomPos, projectile));
    }

    private IEnumerator MoveAndDestroy(Rigidbody2D rb, Vector2 targetPosition, GameObject projectile)
    {
        float distance = Vector2.Distance(rb.position, targetPosition);
        float speed = weaponData.GetSpeed();
        float timeout = 10f; // Timeout after 5 seconds

        while (distance > 0.5f && rb != null && timeout > 0)
        {
            Vector2 direction = (targetPosition - rb.position).normalized;
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
            distance = Vector2.Distance(rb.position, targetPosition);
            timeout -= Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        if (projectile != null)
        {
            Destroy(projectile);
        }
    }
    
    public void ResetInvoke()
    {
        CancelInvoke(nameof(Shoot));
        InvokeRepeating(nameof(Shoot), 1f / weaponData.GetFireRate(), 1f / weaponData.GetFireRate());
    }
}

// shoot mantığı bir kıvrım olayına sahip değil. ilerde uğraşılacak
