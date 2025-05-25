using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public WeaponData weaponData;
    public int amountOfCollisionBeforeDestroy;

    void Start()
    {
        if (weaponData.weaponName == "ProtectionRing")
        {
            // shieldbehaviour handles the amount
        }
        else
        {
            amountOfCollisionBeforeDestroy = weaponData.amountOfCollisionBeforeDestroy;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (weaponData.weaponName == "ProtectionRing")
        {
            if (weaponData.targetTags.Contains(collision.tag) && weaponData.destroySelfOnCollision == true)
            {
                amountOfCollisionBeforeDestroy--;
                if (amountOfCollisionBeforeDestroy <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            if (collision.CompareTag(weaponData.targetTags[0]) && weaponData.destroySelfOnCollision == true)
            {
                amountOfCollisionBeforeDestroy--;
                if (amountOfCollisionBeforeDestroy <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
