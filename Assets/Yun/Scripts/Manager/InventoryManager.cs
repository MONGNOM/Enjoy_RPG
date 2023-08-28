using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SingleTon<InventoryManager>
{
    private InventoryUI inventoryUI;
    public List<InventoryItem> items = new List<InventoryItem>();

    private void Start()
    {
        inventoryUI = FindObjectOfType<InventoryUI>();
        inventoryUI.UpdateUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryUI.gameObject.activeSelf)
            {
                inventoryUI.gameObject.SetActive(false);
            }
            else
            {
                inventoryUI.gameObject.SetActive(true);
            }
        }
    }

    public void AddItem(InventoryItem inventoryitem)
    {
        items.Add(inventoryitem);
        inventoryUI.UpdateUI();
    }

    public void DropItem(InventoryItem inventoryItem)
    {
        items.Remove(inventoryItem);
        inventoryUI.UpdateUI();
        Instantiate(inventoryItem.data.prefab);
    }
}
