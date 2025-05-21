using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class WeaponSound : MonoBehaviour
{
    public GameObject audioPrefab;
    public WeaponData weaponData;

    void Start()
    {
        if (weaponData.playAudioOnShoot)
        {
            if (audioPrefab != null && weaponData != null)
            {
                CreateSoundObject(weaponData, weaponData.weaponShootSound);
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
                    CreateSoundObject(weaponData, weaponData.weaponCollisionSound);
                }

                if (weaponData.destroySelfOnCollision)
                {
                    Destroy(gameObject);
                }
            }
        }
    }


    private bool isQuitting = false;
    private void OnApplicationQuit()
    {
        isQuitting = true;
    }
    void OnDestroy()
    {
        if (!gameObject.scene.isLoaded || isQuitting) return;

        if (weaponData.playAudioOnDestroy)
        {
            if (audioPrefab != null && weaponData != null)
            {
                CreateSoundObject(weaponData, weaponData.weaponDestroySound);
            }
        }
    }

    private void CreateSoundObject(WeaponData weaponData, AudioClip weaponSound)
    {
        GameObject sfx = Instantiate(audioPrefab, transform.position, Quaternion.identity);
        var playAudioOnce = sfx.GetComponent<PlayAudioOnce>();
        playAudioOnce.clip = weaponSound;
        playAudioOnce.outputMixerGroup = weaponData.audioMixerGroup;
    }
}
