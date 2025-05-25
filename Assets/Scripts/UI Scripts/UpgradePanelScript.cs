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

    private List<string> ownedWeaponNames = new List<string>();

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
        WeaponData[] filteredWeaponDatas;
        WeaponData[] mainDatas;
        
        // silah sayısı 5'e eşit ya da büyükse sadece aynı silahları getir değilse tüm silahları getir
        // eğer silah max lvl ise o silahı getirme
        if (ownedWeaponNames.Count >= 5)
        {
            filteredWeaponDatas = weaponDatas
                .Where(wd => ownedWeaponNames.Contains(wd.weaponName))
                .ToArray();

            filteredWeaponDatas = filteredWeaponDatas
                .Where(wd => wd.weaponLevel < 5)
                .ToArray();
        }
        else
        {
            mainDatas = weaponDatas.Where(weaponData => weaponData.weaponLevel < 5).ToArray();
            filteredWeaponDatas = mainDatas;
        }
        int upgradeCardCounter = 4;

        // silah sayısı 3'e düşerse upgradeCardPanelde 3 kart gözüksün
        if (filteredWeaponDatas.Length <= 4)
        {
            upgradeCardCounter = filteredWeaponDatas.Length;
        }
        
        // tüm silahlar max level olduysa ekranı gösterme
        if (filteredWeaponDatas.Length == 0)
        {
            HideUpgradePanel();
            return;
        }

        List<int> usedRolls = new List<int>();
        for (int i = 1; i <= upgradeCardCounter;)
        {
            // değer döndür
            int roll = Random.Range(0, filteredWeaponDatas.Length);

            // check for void staff and retry if first
            if (playerExp.level == 1 && weaponDatas[roll].weaponName == "VoidStaff")
            {
                continue;
            }

            // check for protection necklace and retry if first
            if (playerExp.level == 1 && weaponDatas[roll].weaponName == "ProtectionRing")
            {
                continue;
            }

            // check for black hole and retry if first
            if (playerExp.level == 1 && weaponDatas[roll].weaponName == "BlackHole")
            {
                continue;
            }

            if (usedRolls.Contains(roll))
            {
                continue;

            }
            usedRolls.Add(roll);
            i++;

            WeaponData weaponData = filteredWeaponDatas[roll];

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
        // silah sayısı 5 değil ise o silahın adını listeye ekle
        if (!ownedWeaponNames.Contains(weaponData.weaponName))
        {
            if (ownedWeaponNames.Count < 5)
            {
                ownedWeaponNames.Add(weaponData.weaponName);
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
                shieldBehaviour.UpdateAmountOfCollisionBeforeDestroy();
                if (shieldBehaviour.shield != null)
                {
                    shieldBehaviour.ChargeShield();
                }
                else
                {
                    shieldBehaviour.SummonShield();
                }
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
            else if (weaponData.weaponName == "VenomFlask" || weaponData.weaponName == "BlackHole")
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
            else if (weaponData.weaponName == "ProtectionRing")
            {
                newWeapon.AddComponent<ShieldBehaviour>();
            }

        }
    }
}
