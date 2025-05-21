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

    public Slider uiSlider;
    public void SetUI(float value)
    {
        audioMixer.SetFloat("UI", Mathf.Log10(value) * 20f);
        SaveSoundPrefs();
    }

    // gameinitalizer da çağır
    public void LoadSoundPrefs()
    {
        float sfx = PlayerPrefs.GetFloat("SFX", 0.75f);
        sfxSlider.SetValueWithoutNotify(sfx);
        audioMixer.SetFloat("SFX", Mathf.Log10(sfx) * 20f);

        float music = PlayerPrefs.GetFloat("Music", 0.75f);
        musicSlider.SetValueWithoutNotify(music);
        audioMixer.SetFloat("Music", Mathf.Log10(music) * 20f);

        float ui = PlayerPrefs.GetFloat("UI", 0.75f);
        uiSlider.SetValueWithoutNotify(ui);
        audioMixer.SetFloat("UI", Mathf.Log10(ui) * 20f);
    }

    public void SaveSoundPrefs()
    {
        PlayerPrefs.SetFloat("SFX", sfxSlider.value);
        PlayerPrefs.SetFloat("Music", musicSlider.value);
        PlayerPrefs.SetFloat("UI", uiSlider.value);
        PlayerPrefs.Save();
    }
}