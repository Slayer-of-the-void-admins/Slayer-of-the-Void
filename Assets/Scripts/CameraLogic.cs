using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    public Transform player;

    public Vector3 offset;

    public Vector2 minBounds;

    public Vector2 maxBounds;

    public float camHalfHeight;

    public float camHalfWidth;

    void Start()
    {
        Camera cam = Camera.main; // main camerayı değişkene aktar
        camHalfHeight = cam.orthographicSize; // kamera büyüklüğü yüksekliğin yarısı
        camHalfWidth = camHalfHeight * cam.aspect; // kamera genişliği çözünürlük oranıyla çarpılır
    }

    void LateUpdate()
    {
        Vector3 camPosition = player.position + offset;

        // sınırlandırılacak pozisyon, minimum sınır, maksimum sınır
        camPosition.x = Mathf.Clamp(camPosition.x, minBounds.x + camHalfWidth, maxBounds.x - camHalfWidth);
        camPosition.y = Mathf.Clamp(camPosition.y, minBounds.y + camHalfHeight, maxBounds.y - camHalfHeight);

        transform.position = camPosition;
    }
}
