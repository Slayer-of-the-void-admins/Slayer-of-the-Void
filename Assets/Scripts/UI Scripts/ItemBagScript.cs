using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemBagScript : MonoBehaviour
{
    public void UpdateItemBagIcons(WeaponData weaponData)
    {
        // add the picked weapons icon
        GameObject weaponFrame = Instantiate(weaponData.weaponIconPrefab, gameObject.transform);

        // update the level text
        TextMeshProUGUI weaponLevelText = weaponFrame.GetComponentInChildren<TextMeshProUGUI>();
        if (!weaponData.isMaxLevel)
        {
            weaponLevelText.text = "Lv: " + weaponData.weaponLevel.ToString();
        }
        else
        {
            weaponLevelText.text = "MAX";
        }
    }

    public void UpdateItemBagLevelTexts()
    {
        // iterate between all children of image bag
        foreach (Transform child in transform)
        {
            
        }
    }
}
