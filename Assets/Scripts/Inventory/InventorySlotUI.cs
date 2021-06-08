using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IDropHandler, IPointerUpHandler
{
    public Image itemIcon;
    public TextMeshProUGUI itemName;
    public Button deleteItem;

    public InventoryManager inventoryManager;

    private InventoryItem _item;
    private Vector3 _initialPosition;

    private IEnumerator Start()
    {
        deleteItem.gameObject.SetActive(false);

        yield return new WaitForEndOfFrame();

        _initialPosition = transform.position;
    }

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

    public void OnDeleteClick()
    {
        inventoryManager.DeleteItemFromInventory(_item, this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        deleteItem.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        deleteItem.gameObject.SetActive(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnDrop(PointerEventData eventData)
    {
        foreach (GameObject g in eventData.hovered)
        {
            if (g.GetComponent<InventorySlotUI>() != null)
            {
                Debug.Log(g.name);
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.position = _initialPosition;
    }
}
