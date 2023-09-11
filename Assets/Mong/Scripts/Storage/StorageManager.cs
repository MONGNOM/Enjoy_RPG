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
        //ó���� �������� ������ ����ִ� �ڵ�
    }

    public void RemoveItem(StorageItem item)
    {
        items.Remove(item);
        // �κ��丮�� add������ ���ִ� �ڵ�
    }

}
