using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class StorageSlot : MonoBehaviour, IDropHandler
{


    public void OnDrop(PointerEventData eventData)
    {
        StorageItem storageItem = eventData.pointerDrag.GetComponent<StorageItem>();
        storageItem.parentAfterDrag = transform;
        

        if (storageItem == null)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem.parentAfterDrag = transform;
        }
    }


}
