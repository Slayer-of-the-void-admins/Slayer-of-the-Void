using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public WeaponData weaponData;
    private IWeaponBehaivour weaponBehaivour;

    void Start()
    {
        weaponBehaivour = GetComponent<IWeaponBehaivour>();
        if (weaponBehaivour != null)
        {
            weaponBehaivour.Initialize(weaponData, transform.parent); // parent = player
        }
    }

    void Update()
    {
        weaponBehaivour?.UpdateBehaivour();
    }
}
