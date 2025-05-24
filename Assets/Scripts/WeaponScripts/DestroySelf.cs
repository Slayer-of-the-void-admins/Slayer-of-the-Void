using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public WeaponData weaponData;
    private int amountOfCollisionBeforeDestroy;

    void Start()
    {
        amountOfCollisionBeforeDestroy = weaponData.amountOfCollisionBeforeDestroy;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(weaponData.targetTag) && weaponData.destroySelfOnCollision == true)
        {
            amountOfCollisionBeforeDestroy--;
            if (amountOfCollisionBeforeDestroy <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void UpdateAmountOfCollisionBeforeDestroy()
    {
        weaponData.amountOfCollisionBeforeDestroy = weaponData.GetAmountOfCollisionBeforeDestroy();
    }
}
