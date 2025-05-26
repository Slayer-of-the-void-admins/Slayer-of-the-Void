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
            // shieldbehaviour miktarı ayarlıyor
        }
        else
        {
            amountOfCollisionBeforeDestroy = weaponData.amountOfCollisionBeforeDestroy;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
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
}
