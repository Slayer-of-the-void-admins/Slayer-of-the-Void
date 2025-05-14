using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 movement;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // yatay = x ekseninde hareket ve dikey = y ekseninde hareket için input alınır
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // sprite ı yatay harekete göre sağa ve sola döndür
        if (movement.x > 0)
        {
            spriteRenderer.flipX = false; // sağa döndür
        }
        else if (movement.x < 0)
        {
            spriteRenderer.flipX = true; // sola döndür
        }
    }

    void FixedUpdate()
    {
        // rb nesnesinin pozisyonuna değişen movement nesnesindeki değer eklenerek rb hareket ettirilir
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
