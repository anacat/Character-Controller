using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlotUI : MonoBehaviour
{
    public Image itemIcon;
    public TextMeshProUGUI itemName;

    public InventoryManager inventoryManager;

    private InventoryItem _item;

    public void SetSlot(InventoryItem item, InventoryManager inventoryManager)
    {
        this.inventoryManager = inventoryManager;

        itemIcon.sprite = item.itemIcon;
        itemName.text = item.itemName;

        _item = item;
    }

    public void OnPointerClick()
    {
        inventoryManager.UpdateItemInfo(_item);
    }
}
