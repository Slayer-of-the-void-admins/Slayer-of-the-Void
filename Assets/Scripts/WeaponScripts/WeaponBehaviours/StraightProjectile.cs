using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StraightProjectile : MonoBehaviour, IWeaponBehaivour
{
    private WeaponData weaponData;
    private Transform playerTransform;
    private GameObject straightProjectile;
    public FixedJoystick fixedJoystick;

    private Vector3 lastAimDirection = Vector3.right; // varsayılan yön
    public GameObject aimMarkerPrefab;
    private GameObject aimMarkerInstance;
    private Camera mainCamera;
    private Vector3 lastAimOffset = Vector3.right * 15f; // default offset


    public void Initialize(WeaponData weaponData, Transform playerTransform)
    {
        this.weaponData = weaponData;
        this.playerTransform = playerTransform;
        mainCamera = Camera.main;

        fixedJoystick = GameObject.FindWithTag("AimJoystick")?.GetComponent<FixedJoystick>();
        aimMarkerPrefab = GameObject.FindWithTag("AimMarker");

#if UNITY_ANDROID
        if (aimMarkerPrefab != null)
        {
            aimMarkerInstance = Instantiate(aimMarkerPrefab);
            // aimMarkerInstance.transform.SetParent(mobileStuff);
        }
#endif

        InvokeRepeating(nameof(Shoot), 1f, 1f / weaponData.GetFireRate());
    }

    public void UpdateBehaivour()
    {
    #if UNITY_ANDROID
        Vector2 joystickInput = new Vector2(fixedJoystick.Horizontal, fixedJoystick.Vertical);

        // aimstick inputunu effective magnitude ile lastaimoffsete aktar (0 a inmesin)
        if (joystickInput.sqrMagnitude > 0.0001f)
        {
            lastAimDirection = joystickInput.normalized;
            float effectiveMagnitude = Mathf.Clamp01(joystickInput.magnitude);

            lastAimOffset = lastAimDirection * effectiveMagnitude * 50f;
        }

        // lastaimoffset ile aim pozisyonunu bul ve markera at
        if (aimMarkerInstance != null)
        {
            Vector3 rawAimPos = playerTransform.position + lastAimOffset;

            // dünyadan viewporta at ve kameraya sınırla
            Vector3 viewportPos = mainCamera.WorldToViewportPoint(rawAimPos);
            viewportPos.x = Mathf.Clamp(viewportPos.x, 0.05f, 0.95f);
            viewportPos.y = Mathf.Clamp(viewportPos.y, 0.05f, 0.95f);

            // sınırlanan pozisyonu dünyaya aktar
            Vector3 clampedWorldPos = mainCamera.ViewportToWorldPoint(viewportPos);
            clampedWorldPos.z = 0f;

            aimMarkerInstance.transform.position = clampedWorldPos;
        }
    #endif
    }

    void Shoot()
    {
        // imleç pozisyonunu kullanarak yön belirle
        Vector3 playerPos = playerTransform.position;
        Vector3 aimDirection;

#if UNITY_ANDROID
        aimDirection = lastAimDirection;
#else
        // Diğer platformlar için mouse pozisyonu
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        aimDirection = (mousePos - playerPos).normalized;
#endif

        // silahı çağır
        straightProjectile = Instantiate(weaponData.weaponPrefab, playerPos + aimDirection, Quaternion.identity);

        // silah oyuncunun tersi yönüne baksın
        straightProjectile.transform.rotation = Quaternion.LookRotation(Vector3.back, straightProjectile.transform.position - playerPos);

        // silah ilerlesin
        Rigidbody2D rb = straightProjectile.GetComponent<Rigidbody2D>();
        rb.velocity = aimDirection * weaponData.GetSpeed();
    }

    public void ResetInvoke()
    {
        CancelInvoke(nameof(Shoot));
        InvokeRepeating(nameof(Shoot), 1f / weaponData.GetFireRate(), 1f / weaponData.GetFireRate());
    }

    public void UpdateAmountOfCollisionBeforeDestroy()
    {
        weaponData.amountOfCollisionBeforeDestroy = weaponData.GetAmountOfCollisionBeforeDestroy();
    }
}
