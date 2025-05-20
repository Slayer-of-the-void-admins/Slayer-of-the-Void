using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnce : MonoBehaviour
{
    [HideInInspector] public AudioClip clip;
    void Start()
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
        Destroy(gameObject, clip.length);
    }
}
