using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidSetup : MonoBehaviour
{
    public GameObject joysticks;
    void Start()
    {
#if UNITY_ANDROID
        EnableAndroidStuff();
#else
        DisableAndroidStuff();
#endif
    }

    public void DisableAndroidStuff()
    {
        joysticks.SetActive(false);
    }

    public void EnableAndroidStuff()
    {
        joysticks.SetActive(true);
    }
}