using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUnit : MonoBehaviour
{
    private InventoryItem InventoryItem;

    [SerializeField]
    private Button useButton;

    [SerializeField]
    private TextMeshProUGUI textUI;

    public void AddItem(InventoryItem inventoryItem)
    {
        useButton.interactable = true;
        InventoryItem = inventoryItem;
        textUI.text = inventoryItem.data.name;
    }

    public void UseItem()
    {
        InventoryItem.Use();
    }

    public void RemoveItem()
    {
        useButton.interactable = false;
        textUI.text = "";
    }

 
}
