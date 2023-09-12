using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StorageManager : SingleTon<StorageManager>
{
    public GameObject itemPrefab;
    public List<Item> startItems = new List<Item>();
    public List<StorageSlot> slots = new List<StorageSlot>();
    
    private void Start()
    {
        foreach (var item in startItems)
        {
            InsertItem(item);
        }
        
    }
    public void InsertItem(Item item)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            StorageSlot slot = slots[i];
            StorageItem storage = slot.GetComponentInChildren<StorageItem>();

            if (storage == null )
            {
                MakeItem(item, slot);
            }
        }
        
    }

    public void MakeItem(Item item, StorageSlot slot)
    {
        GameObject makeItem = Instantiate(itemPrefab, slot.transform);
        StorageItem storageItem = makeItem.GetComponent<StorageItem>();
        storageItem.addItem(item);
    }

    public void RemoveItem(Item item)
    {
        InventoryManager.Instance.AddItem(item);
        // 인벤토리에 add아이템 해주는 코드
    }

}
