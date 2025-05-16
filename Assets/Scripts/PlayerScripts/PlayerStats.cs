using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "PlayerData")]
public class PlayerStats : ScriptableObject
{
    // can olayları
    public float playerHealth = 100f;
    public float healthMultiplier = 1f;
    public float GetPlayerHealth()
    {
        return playerHealth *= healthMultiplier;
    }

    // direnç olayları
    public float resistance = 0f;
    public float resistanceAdditive = 1f;
    public float GetResistance()
    {
        return resistance += resistanceAdditive;
    }


    public float damageMultiplier = 1f;
    public float moveSpeedMultiplier = 1f;
    public float weaponSpeedMultiplier = 1f;
    public float fireRateMultiplier = 1f;
}
