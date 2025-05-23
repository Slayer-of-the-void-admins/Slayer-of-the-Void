using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeDuration : MonoBehaviour
{
    public WeaponData weaponData;
    private float lifeDuration;
    void Start()
    {
        lifeDuration = weaponData.lifeDuration;
    }

    void Update()
    {
        if (weaponData.hasLifeDuration == false) return;

        lifeDuration -= Time.deltaTime;
        if (lifeDuration <= 0)
        {
            Destroy(gameObject);
        }
    }
}
