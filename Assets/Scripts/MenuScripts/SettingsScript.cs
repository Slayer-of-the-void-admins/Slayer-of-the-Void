using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsScript : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetSFX(float value)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(value) * 20f);
    }

    public void SetMusic(float value)
    {
        audioMixer.SetFloat("Music", Mathf.Log10(value) * 20f);
    }
}