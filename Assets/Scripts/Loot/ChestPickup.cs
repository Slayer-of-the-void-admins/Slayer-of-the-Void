using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ChestPickup : MonoBehaviour
{
    public int baseEssenceReward = 10;
    public float essenceAmountMultipler = 1.25f;
    [HideInInspector] public PlayerExp playerExp;
    public PlayerStats playerStats;
    [HideInInspector] public TextMeshProUGUI voidEssenceCounter;

    void Start()
    {
        playerExp = GameObject.FindWithTag("Player")?.GetComponent<PlayerExp>();
        voidEssenceCounter = GameObject.FindWithTag("VoidEssenceCounterText").GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && playerExp != null)
        {
            playerStats.LoadVoidEssenceAmount();

            int lootedAmount = Mathf.RoundToInt(baseEssenceReward * Mathf.Pow(essenceAmountMultipler, playerExp.level - 1));
            int countedAmount = int.Parse(voidEssenceCounter.text);

            voidEssenceCounter.text = (countedAmount + lootedAmount).ToString();

            playerStats.voidEssenceAmount += lootedAmount;

            playerStats.SaveVoidEssenceAmount();
            Destroy(gameObject);
        }
    }
}
