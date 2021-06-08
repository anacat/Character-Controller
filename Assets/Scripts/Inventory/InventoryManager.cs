using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public Transform inventoryContent;
    public GameObject itemPrefab;

    [Header("Item Info")]
    public CanvasGroup infoGroup;
    public Image itemIcon;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDescription;

    [Header("Inventory")]
    public InventoryHolder inventory;

    private List<InventorySlotUI> itemUI = new List<InventorySlotUI>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        foreach (InventoryItem item in inventory.itemList)
        {
            InventorySlotUI i = Instantiate(itemPrefab, inventoryContent).GetComponent<InventorySlotUI>();
            i.SetSlot(item, this);

            itemUI.Add(i);
        }
    }

    public void UpdateItemInfo(InventoryItem item)
    {
        infoGroup.alpha = 1f;

        itemIcon.sprite = item.itemIcon;
        itemName.text = item.itemName;
        itemDescription.text = item.description;
    }

    public void UpdateInventory(InventoryItem item)
    {
        InventorySlotUI i = Instantiate(itemPrefab, inventoryContent).GetComponent<InventorySlotUI>();
        i.SetSlot(item, this);
        itemUI.Add(i);
    }

    public void DeleteItemFromInventory(InventoryItem item, InventorySlotUI itemSlot)
    {
        inventory.RemoveItem(item);

        Destroy(itemSlot.gameObject);
        itemUI.Remove(itemSlot);        
    }
}
