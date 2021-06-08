using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Item", menuName ="Data/Inventory/Item")]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;

    [Multiline]
    public string description;
}
