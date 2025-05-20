using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestPickup : MonoBehaviour
{
    public int baseEssenceReward = 10;
    public float essenceAmountMultipler = 1.5f;
    public PlayerExp playerExp;
    public PlayerStats playerStats;

    void Start()
    {
        playerExp = GameObject.FindWithTag("Player").GetComponent<PlayerExp>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerStats.LoadVoidEssenceAmount();
            playerStats.voidEssenceAmount += Mathf.RoundToInt(baseEssenceReward * Mathf.Pow(essenceAmountMultipler, playerExp.level));
            playerStats.SaveVoidEssenceAmount();
        }
    }
}
