using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SingleTon<InventoryManager>
{
    [SerializeField] private GameObject inventoryGroup;
    [SerializeField] private Item[] initItems;
    [SerializeField] private InventorySlot[] inventorySlots;
    [SerializeField] private GameObject inventoryItemPrefab;
    [SerializeField] private int maxStackedItem = 99;

    private void Start()
    {
        foreach (var item in initItems) 
        {
            AddItem(item);
        }
    }

    public bool AddItem(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();

            if (null != itemInSlot && itemInSlot.item == item && 
                itemInSlot.count < maxStackedItem && true == itemInSlot.item.isStackable)
            {
                itemInSlot.count++;
                itemInSlot.UpdateCount();
                return true;
            }
        }

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();

            if (null == itemInSlot)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }
        return false;
    }

    private void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItem = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItem.GetComponent<InventoryItem>();
        inventoryItem.InitItem(item);
    }

    public void OnClickOpenInventoryButton()
    {
        inventoryGroup.SetActive(true);
    }

    public void OnClickCloseInventoryButton()
    {
        inventoryGroup.SetActive(false);
    }
}
