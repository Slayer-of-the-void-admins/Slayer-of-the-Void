using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingWeaponScript : MonoBehaviour, IWeaponBehaivour
{
    private WeaponData weaponData;
    private Transform playerTransform;
    private GameObject floatingWeapon;
    private float floatingWeaponTimer;
    private bool isFloatingWeaponActive = false;
    private Camera mainCamera;
    private float cooldownTimer;
    private bool isInCooldown = false;

    public void Initialize(WeaponData weaponData, Transform playerTransform)
    {
        this.weaponData = weaponData;
        this.playerTransform = playerTransform;
        mainCamera = Camera.main;
        ShowFloatingWeapon();
    }


    public void ShowFloatingWeapon()
    {
        Vector3 spawnPosition = playerTransform.position + new Vector3(0, 5f, 0); // oyuncunun üstü
        floatingWeapon = Instantiate(weaponData.weaponPrefab, spawnPosition, Quaternion.identity);
        floatingWeapon.transform.SetParent(playerTransform);
        isFloatingWeaponActive = true;
        floatingWeaponTimer = weaponData.floatingWeaponTimer;
    }

    public void UpdateBehaivour()
    {
        if (isFloatingWeaponActive)
        {
            floatingWeaponTimer += Time.deltaTime;
            if (floatingWeaponTimer >= 3f)
            {
                DestroyVisibleEnemies();
                Destroy(floatingWeapon);
                isFloatingWeaponActive = false;
                isInCooldown = true;
                cooldownTimer = weaponData.cooldownTimer;
            }
        }
        else if (isInCooldown)
        {
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer >= 10f)
            {
                ShowFloatingWeapon();
                isInCooldown = false;
            }
        }
    }
    void DestroyVisibleEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Vector3 viewportPos = mainCamera.WorldToViewportPoint(enemy.transform.position);
            bool isVisible = viewportPos.z > 0 &&
                             viewportPos.x > 0 && viewportPos.x < 1 &&
                             viewportPos.y > 0 && viewportPos.y < 1;

            if (isVisible)
            {
                Destroy(enemy);
            }
        }
    }
}
