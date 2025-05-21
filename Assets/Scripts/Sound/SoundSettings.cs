using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider sfxSlider;
    public void SetSFX(float value)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(value) * 20f);
        SaveSoundPrefs();
    }

    public Slider musicSlider;
    public void SetMusic(float value)
    {
        audioMixer.SetFloat("Music", Mathf.Log10(value) * 20f);
        SaveSoundPrefs();
    }

    // gameinitalizer da çağır
    public void LoadSoundPrefs()
    {
        float sfx = PlayerPrefs.GetFloat("SFX", 0.75f);
        sfxSlider.value = sfx;
        SetSFX(sfx);

        float music = PlayerPrefs.GetFloat("Music", 0.75f);
        musicSlider.value = music;
        SetMusic(music);
    }

    public void SaveSoundPrefs()
    {
        PlayerPrefs.SetFloat("SFX", sfxSlider.value);
        PlayerPrefs.SetFloat("Music", musicSlider.value);
        PlayerPrefs.Save();
    }
}