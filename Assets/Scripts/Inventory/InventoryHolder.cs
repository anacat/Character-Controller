using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName ="Data/Inventory/Inventory Holder")]
public class InventoryHolder : ScriptableObject
{
    public List<InventoryItem> itemList = new List<InventoryItem>();

    public void AddItem(InventoryItem item)
    {
        itemList.Add(item);
    }

    public void RemoveItem(InventoryItem item)
    {
        itemList.Remove(item);
    }
}
