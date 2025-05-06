using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public EnemyData enemyData;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        // oyuncu ve düşman pozisyonlarını değişkene aktar
        Vector3 playerPos = player.position;
        Vector3 enemyPos = transform.position;

        Vector3 direction = (playerPos - enemyPos).normalized; // yönü oyuncunun pozisyonundan düşmanın pozisyonunu çıkartarak bul ve genişliği sabit tut
        enemyPos += direction * enemyData.moveSpeed * Time.deltaTime; // bulunan yönde düşmanı hareket ettir
        transform.position = enemyPos;
    }
}
