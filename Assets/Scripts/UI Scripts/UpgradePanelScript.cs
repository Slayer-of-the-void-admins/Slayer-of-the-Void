using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class UpgradePanelScript : MonoBehaviour
{
    public GameObject player;
    public GameObject upgradePanel;
    public Transform upgradePanelTransform;
    public WeaponData[] weaponDatas;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowUpgradePanelDelayed());
    }

    public void ShowUpgradePanel()
    {
        Time.timeScale = 0f;
        upgradePanel.SetActive(true);
        FillUpgradePanel();
    }

    IEnumerator ShowUpgradePanelDelayed()
    {
        yield return new WaitForEndOfFrame();
        ShowUpgradePanel();
    }

    public void HideUpgradePanel()
    {
        upgradePanel.SetActive(false);
        ClearUpgradePanel();
        Time.timeScale = 1f;
    }

    void ClearUpgradePanel()
    {
        foreach (Transform child in upgradePanelTransform)
        {
            Destroy(child.gameObject);
        }
    }
    
    void FillUpgradePanel()
    {
        List<int> usedRolls = new List<int>();
        for (int i = 1; i <= 4;)
        {
            int roll = Random.Range(0, weaponDatas.Count());
            if (usedRolls.Contains(roll))
            {
                continue;
            }
            usedRolls.Add(roll);
            i++;

            WeaponData weaponData = weaponDatas[roll];

            GameObject upgradeCard = Instantiate(weaponData.upgradeCardPrefab, upgradePanelTransform);
            Button upgradeCardButton = upgradeCard.GetComponent<Button>();
            upgradeCardButton.onClick.AddListener(() => AddWeapon(weaponData));
            upgradeCardButton.onClick.AddListener(() => HideUpgradePanel());
        }
    }

    public void AddWeapon(WeaponData weaponData)
    {
        // oyuncu silaha zaten sahipse yenisini yerleştirmek yerine silahın seviyesini artır
        WeaponScript existingWeapon = player.GetComponentInChildren<WeaponScript>();
        if (existingWeapon != null && existingWeapon.weaponData.weaponName == weaponData.weaponName)
        {
            // silah seviyesini artır
            existingWeapon.weaponData.weaponLevel++;
        }
        else
        {
            // yeni silah yarat
            GameObject newWeapon = new GameObject(weaponData.weaponName);
            newWeapon.transform.parent = player.transform;
            newWeapon.transform.localPosition = Vector3.zero;

            WeaponScript ws = newWeapon.AddComponent<WeaponScript>();
            ws.weaponData = weaponData;
        }
    }
}
