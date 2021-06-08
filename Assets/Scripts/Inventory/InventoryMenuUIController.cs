using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenuUIController : MonoBehaviour
{
    public CanvasGroup inventoryUI;
    public InventoryManager inventoryUIManager;

    private bool _inventoryShowing;

    void Start()
    {
        inventoryUI.alpha = 0f;
        inventoryUI.blocksRaycasts = false;
        inventoryUI.interactable = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            _inventoryShowing = !_inventoryShowing;

            if (_inventoryShowing)
            {
                inventoryUI.alpha = 1f;
                inventoryUI.blocksRaycasts = true;
                inventoryUI.interactable = true;
            }
            else
            {
                inventoryUI.alpha = 0f;
                inventoryUI.blocksRaycasts = false;
                inventoryUI.interactable = false;
            }
        }
    }
}
