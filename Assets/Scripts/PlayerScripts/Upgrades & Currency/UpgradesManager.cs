using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    public GameObject healthPanel;
    public GameObject resistancePanel;
    public GameObject damagePanel;
    public GameObject moveSpeedPanel;
    public GameObject weaponSpeedPanel;
    public GameObject fireRatePanel;

    public void CloseAllPanels()
    {
        healthPanel.SetActive(false);
        resistancePanel.SetActive(false);
        damagePanel.SetActive(false);
        moveSpeedPanel.SetActive(false);
        weaponSpeedPanel.SetActive(false);
        fireRatePanel.SetActive(false);
    }

    public void OpenHealthPanel()
    {
        CloseAllPanels();
        healthPanel.SetActive(true);
    }

    public void OpenResistancePanel()
    {
        CloseAllPanels();
        resistancePanel.SetActive(true);
    }

    public void OpenDamagePanel()
    {
        CloseAllPanels();
        damagePanel.SetActive(true);
    }

    public void OpenMoveSpeedPanel()
    {
        CloseAllPanels();
        moveSpeedPanel.SetActive(true);
    }

    public void OpenWeaponSpeedPanel()
    {
        CloseAllPanels();
        weaponSpeedPanel.SetActive(true);
    }

    public void OpenFireRatePanel()
    {
        CloseAllPanels();
        fireRatePanel.SetActive(true);
    }
}
