using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    public GameObject mapPanel;
    public GameObject playerMarker;
    public RectTransform mapArea;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (mapPanel.activeSelf == false)
            {
                OpenMap();
            }
            else
            {
                CloseMap();
            }
        }
    }
    
    void OpenMap()
    {
        mapPanel.SetActive(true);
        playerMarker.SetActive(true);
        Time.timeScale = 0f;
    }

    void CloseMap()
    {
        playerMarker.SetActive(false);
        mapPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
