using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class MapScript : MonoBehaviour
{
    public GameObject mapPanel;
    public RectTransform mapArea;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (Time.timeScale == 1f)
            {
                OpenMap();
            }
            else if (mapPanel.activeSelf == true)
            {
                CloseMap();
            }
        }
    }
    
    public void OpenMap()
    {
        mapPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseMap()
    {
        mapPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
