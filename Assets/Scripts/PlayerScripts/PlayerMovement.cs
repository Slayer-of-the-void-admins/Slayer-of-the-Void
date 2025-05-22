using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    [HideInInspector] public float moveSpeedUpgradeModifier = 1f;
    private Vector2 movement;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator playerAnimator;

    public FixedJoystick joystick;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
#if UNITY_ANDROID
        // Joystick'ten değer al (mobil)
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;
#else
        // Klavyeden değer al (masaüstü)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
#endif
        // sprite ı yatay harekete göre sağa ve sola döndür
        if (movement.x > 0)
        {
            spriteRenderer.flipX = false; // sağa döndür
        }
        else if (movement.x < 0)
        {
            spriteRenderer.flipX = true; // sola döndür
        }

        // player animatörünün parametresini oyuncu hareketi ile doldur
        playerAnimator.SetFloat("moveSpeed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        // rb nesnesinin pozisyonuna değişen movement nesnesindeki değer eklenerek rb hareket ettirilir
        float finalSpeed = moveSpeed * moveSpeedUpgradeModifier;
        rb.MovePosition(rb.position + movement * finalSpeed * Time.fixedDeltaTime);
    }
}
