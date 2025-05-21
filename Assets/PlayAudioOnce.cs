using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class PlayAudioOnce : MonoBehaviour
{
    // değişkenler collisionsound.cs te obje yaratılırken doluyor
    [HideInInspector] public AudioClip clip;
    [HideInInspector] public AudioMixerGroup outputMixerGroup;
    void Start()
    {
        // audiosource component ı doldur
        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.clip = clip;
        source.outputAudioMixerGroup = outputMixerGroup;

        // sesi başlat ve ses bitince objeyi yok et
        source.Play();
        Destroy(gameObject, clip.length);
    }
}
