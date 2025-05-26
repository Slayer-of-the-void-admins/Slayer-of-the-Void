using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidSetup : MonoBehaviour
{
    public GameObject mobileStuff;
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
        mobileStuff.SetActive(false);
    }

    public void EnableAndroidStuff()
    {
        mobileStuff.SetActive(true);
    }
}