using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemBagScript : MonoBehaviour
{
    
    public void UpdateItemBagIcons(WeaponData weaponData)
    {
        bool frameExists = false;
        foreach (Transform child in transform)
        {
            if (weaponData.weaponName + " Frame(Clone)" == child.name)
            {
                TextMeshProUGUI weaponLevelText = child.GetComponentInChildren<TextMeshProUGUI>();
                if (!weaponData.isMaxLevel)
                {
                    weaponLevelText.text = "Lv: " + weaponData.weaponLevel.ToString();
                }
                else
                {
                    weaponLevelText.text = "MAX";
                }

                frameExists = true;
                break;
            }
        }

        // weaponFrame i yerleştir, yerleştiremiyorsan nulla
        GameObject weaponFrame;
        if (frameExists == false)
            weaponFrame = Instantiate(weaponData.weaponIconPrefab, gameObject.transform);
    }
}
