using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightProjectile : MonoBehaviour, IWeaponBehaivour
{
    private WeaponData weaponData;
    private Transform playerTransform;
    private GameObject straightProjectile;
    public FixedJoystick fixedJoystick;

    public void Initialize(WeaponData weaponData, Transform playerTransform)
    {
        this.weaponData = weaponData;
        this.playerTransform = playerTransform;
        fixedJoystick = GameObject.FindWithTag("AimJoystick")?.GetComponent<FixedJoystick>();
        InvokeRepeating(nameof(Shoot), 1f, 1f / weaponData.GetFireRate());
    }

    public void UpdateBehaivour() { }

    void Shoot()
    {
        // imleç pozisyonunu kullanarak yön belirle
        Vector3 playerPos = playerTransform.position;
        Vector3 aimDirection;

#if UNITY_ANDROID
    // Android platformu için joystick kontrolü
        Vector2 joystickInput = new Vector2(fixedJoystick.Horizontal, fixedJoystick.Vertical);

        if (joystickInput.magnitude >= 0.1f)
        {
            aimDirection = joystickInput.normalized;
        }
        else
        {
            // Joystick hareket yoksa atış yapma
            return;
        }
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
}
