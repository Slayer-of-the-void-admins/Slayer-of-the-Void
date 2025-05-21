using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LootSound : MonoBehaviour
{
    public GameObject audioPrefab;
    public AudioMixerGroup audioMixerGroup;
    public AudioClip lootSound;


    private bool isQuitting = false;
    private void OnApplicationQuit()
    {
        isQuitting = true;
    }
    void OnDestroy()
    {
        if (!gameObject.scene.isLoaded || isQuitting) return;

        if (audioPrefab != null)
        {
            GameObject lootSFX = Instantiate(audioPrefab, transform.position, Quaternion.identity);
            var playAudioOnce = lootSFX.GetComponent<PlayAudioOnce>();
            playAudioOnce.clip = lootSound;
            playAudioOnce.outputMixerGroup = audioMixerGroup;
        }
    }
}
