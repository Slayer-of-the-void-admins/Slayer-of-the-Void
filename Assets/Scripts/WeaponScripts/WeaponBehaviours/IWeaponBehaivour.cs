using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponBehaivour
{
    void Initialize(WeaponData weaponData, Transform playerTransform);

    void UpdateBehaivour();
}
