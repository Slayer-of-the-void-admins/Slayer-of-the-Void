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
    public ItemBagScript itemBagScript;
    public PlayerExp playerExp;
    public bool isUpgradePanelActive = false;

    void Start()
    {
        StartCoroutine(ShowUpgradePanelDelayed());
    }

    public void ShowUpgradePanel()
    {
        Time.timeScale = 0f;
        upgradePanel.SetActive(true);
        isUpgradePanelActive = true;
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
        isUpgradePanelActive = false;
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
            // değer döndür
            int roll = Random.Range(0, weaponDatas.Count());

            // check for void staff and retry if first
            if (playerExp.level == 1 && weaponDatas[roll].weaponName == "VoidStaff")
            {
                continue;
            }

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
        // oyuncu silaha sahip mi kontrol et
        WeaponScript existingWeapon = null;
        foreach (Transform child in player.transform)
        {
            WeaponScript weaponScript = child.GetComponent<WeaponScript>();
            if (weaponScript != null && weaponScript.weaponData.weaponName == weaponData.weaponName)
            {
                existingWeapon = weaponScript;
                break;
            }
        }

        if (existingWeapon != null)
        {
            // silah seviyesini artır
            existingWeapon.weaponData.weaponLevel++;

            // yeni fire ratleri kullanmaları için projectile silahların invoke larını tekrar başlat
            StraightProjectile straightProjectile = existingWeapon.GetComponent<StraightProjectile>();
            if (straightProjectile != null)
            {
                straightProjectile.ResetInvoke();
                straightProjectile.UpdateAmountOfCollisionBeforeDestroy();
            }
            RandomCurvedProjectile randomCurvedProjectile = existingWeapon.GetComponent<RandomCurvedProjectile>();
            if (randomCurvedProjectile != null)
            {
                randomCurvedProjectile.ResetInvoke();
            }
            NovaWeapon novaWeapon = existingWeapon.GetComponent<NovaWeapon>();
            if (novaWeapon != null)
            {
                novaWeapon.ResetInvoke();
            }
            ShieldBehaviour shieldBehaviour = existingWeapon.GetComponent<ShieldBehaviour>();
            if (shieldBehaviour != null)
            {
                // shieldBehaviour.UpdateAmountOfCollisionBeforeDestroy();
            }

            // item çantası ikon ve yazıları güncelle
            itemBagScript.UpdateItemBagIcons(weaponData);
        }
        else
        {
            // item çantası ikon ve yazıları güncelle
            itemBagScript.UpdateItemBagIcons(weaponData);

            // yeni silah yarat
            GameObject newWeapon = new GameObject(weaponData.weaponName);
            newWeapon.transform.parent = player.transform;
            newWeapon.transform.localPosition = Vector3.zero;

            // weaponscript i aktar
            WeaponScript ws = newWeapon.AddComponent<WeaponScript>();
            ws.weaponData = weaponData;

            // doğru behaivour dosyasını bileşen olarak ekle
            if (weaponData.weaponName == "Shuriken" || weaponData.weaponName == "Fireball")
            {
                newWeapon.AddComponent<StraightProjectile>();
            }
            else if (weaponData.weaponName == "LightningSword" || weaponData.weaponName == "VoidAxe")
            {
                newWeapon.AddComponent<OrbitingWeapon>();
            }
            else if (weaponData.weaponName == "VenomFlask")
            {
                newWeapon.AddComponent<RandomCurvedProjectile>();
            }
            else if (weaponData.weaponName == "VoidStaff")
            {
                newWeapon.AddComponent<FloatingWeaponScript>();
            }
            else if (weaponData.weaponName == "FrostNova")
            {
                newWeapon.AddComponent<NovaWeapon>();
            }
            else if (weaponData.weaponName == "ProtectionNecklace")
            {
                newWeapon.AddComponent<ShieldBehaviour>();
            }
        }
    }
}
