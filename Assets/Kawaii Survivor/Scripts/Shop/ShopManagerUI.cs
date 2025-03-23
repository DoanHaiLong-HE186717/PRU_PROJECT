using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManagerUI : MonoBehaviour
{
    [Header(" Player Stats Elements ")]
    [SerializeField] private GameObject playerStatsPanel;
    [SerializeField] private GameObject playerStatsClosePanel;


    [Header(" Inventory Elements ")]
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject inventoryClosePanel;

    [Header(" Item Info Elements ")]
    [SerializeField] private GameObject itemInfoSlidePanel;

    [NaughtyAttributes.Button]
    public void ShowPlayerStats()
    {
        playerStatsPanel.SetActive(true);
        playerStatsClosePanel.SetActive(true);
    }

    [NaughtyAttributes.Button]
    public void HidePlayerStats()
    {
        playerStatsPanel.SetActive(false);
        playerStatsClosePanel.SetActive(false);

    }

    [NaughtyAttributes.Button]
    public void ShowInventory()
    {
        inventoryPanel.SetActive(true);
        inventoryClosePanel.SetActive(true);
    }

    [NaughtyAttributes.Button]
    public void HideInventory(bool hideItemInfo = true)
    {
        inventoryPanel.SetActive(false);
        inventoryClosePanel.SetActive(false);

        if (hideItemInfo)
            HideItemInfo();
    }



    [NaughtyAttributes.Button]
    public void ShowItemInfo()
    {
        itemInfoSlidePanel.SetActive(true);

    }

    [NaughtyAttributes.Button]
    public void HideItemInfo()
    {
        itemInfoSlidePanel.SetActive(false);
    }
}
