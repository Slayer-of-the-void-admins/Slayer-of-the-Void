using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LateUpdate() 
    {
        // kameranın pozisyonunu oyuncunun posizsyonuna göre bir aralıkla değiştir
        transform.position = player.position + offset;    
    }
}
