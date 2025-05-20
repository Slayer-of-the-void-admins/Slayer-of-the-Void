using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    private bool isQuitting = false;
    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    public GameObject audioPrefab;
    public WeaponData weaponData;

    void Start()
    {
        if (weaponData.playAudioOnShoot)
        {
            if (audioPrefab != null && weaponData != null)
            {
                GameObject sfx = Instantiate(audioPrefab, transform.position, Quaternion.identity);
                sfx.GetComponent<PlayAudioOnce>().clip = weaponData.weaponShootSound;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (weaponData.playAudioOnCollision)
        {
            if (collision.CompareTag("Enemy"))
            {
                if (audioPrefab != null && weaponData != null)
                {
                    GameObject sfx = Instantiate(audioPrefab, transform.position, Quaternion.identity);
                    sfx.GetComponent<PlayAudioOnce>().clip = weaponData.weaponCollisionSound;
                }

                if (weaponData.destroySelfOnCollision)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    void OnDestroy()
    {
        if (!gameObject.scene.isLoaded || isQuitting) return;

        if (weaponData.playAudioOnDestroy)
        {
            if (audioPrefab != null && weaponData != null)
            {
                GameObject sfx = Instantiate(audioPrefab, transform.position, Quaternion.identity);
                sfx.GetComponent<PlayAudioOnce>().clip = weaponData.weaponDestroySound;
            }
        }
    }
}
