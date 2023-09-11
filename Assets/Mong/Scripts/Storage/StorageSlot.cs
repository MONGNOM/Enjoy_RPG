using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

public class StorageSlot : MonoBehaviour, IDropHandler
{
    //���丮�������� ������ �����ϰ� ����� ����Ұ�   


    public void OnDrop(PointerEventData eventData)
    {
        // drop�� �ߴµ� ��� �߳�? null�� ��� ������ �ڿ��� �ε����� �׷���?
        StorageItem storageItem = eventData.pointerDrag.GetComponent<StorageItem>();
        storageItem.parentAfterDrag = transform;
        

        if (storageItem == null)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem.parentAfterDrag = transform;
        }

    }


}
