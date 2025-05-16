using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCurvedProjectile : MonoBehaviour, IWeaponBehaivour
{
    private WeaponData weaponData;
    private Transform playerTransform;
    private GameObject randomCurvedProjectile;

    public void Initialize(WeaponData weaponData, Transform playerTransform)
    {
        this.weaponData = weaponData;
        this.playerTransform = playerTransform;
        InvokeRepeating(nameof(Shoot), 1f, 1f / weaponData.GetFireRate());
    }

    public void UpdateBehaivour()
    {

    }

    void Shoot()
    {
        // oyuncu etrafında rastgele pozisyon seç
        Vector3 randomPos = (Vector2)playerTransform.position + Random.insideUnitCircle.normalized * Random.Range(weaponData.minAimRange, weaponData.maxAimRange);
        randomPos.z = 0;

        // yönü bul
        Vector3 direction = (randomPos - playerTransform.position).normalized;

        // silahı çağır
        randomCurvedProjectile = Instantiate(weaponData.weaponPrefab, playerTransform.position + direction, Quaternion.identity);

        // silah gidecek yöne baksın
        randomCurvedProjectile.transform.rotation = Quaternion.LookRotation(Vector3.back, randomCurvedProjectile.transform.position - playerTransform.position);

        Rigidbody2D rb = randomCurvedProjectile.GetComponent<Rigidbody2D>();
        StartCoroutine(MoveAndDestroy(rb, randomPos));
    }

    private IEnumerator MoveAndDestroy(Rigidbody2D rb, Vector2 targetPosition)
    {
        float distance = Vector2.Distance(rb.position, targetPosition);
        float speed = weaponData.GetSpeed();
        while (distance > 0.1f)
        {
            Vector2 direction = (targetPosition - rb.position).normalized;
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
            distance = Vector2.Distance(rb.position, targetPosition);
            yield return new WaitForFixedUpdate();
        }

        Destroy(randomCurvedProjectile);
    }
}

// shoot mantığı bir kıvrım olayına sahip değil. ilerde uğraşılacak