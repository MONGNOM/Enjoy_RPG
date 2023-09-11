using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StorageManager : SingleTon<StorageManager>
{

    public List<StorageItem> items = new List<StorageItem>();

    public StorageSlot slot;
    public StorageItem storageItem;

    private void Start()
    {
        InsertItem(storageItem);
    }
    public void InsertItem(StorageItem item)
    {
        items.Add(storageItem);
        //처음에 아이템을 여러개 집어넣는 코드
    }

    public void RemoveItem(StorageItem item)
    {
        items.Remove(item);
        // 인벤토리에 add아이템 해주는 코드
    }

}
