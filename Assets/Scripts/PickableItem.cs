using UnityEngine;

public class PickableItem : MonoBehaviour
{
    public InventoryItem item;
    public InventoryHolder inventory;

    private void Awake()
    {
        if(inventory.itemList.Contains(item))
        {
            Destroy(gameObject);
        }
    }
    
    private void OnMouseDown()
    {
        inventory.AddItem(item);
        InventoryManager.Instance.UpdateInventory(item);

        Destroy(gameObject);
    }
}
