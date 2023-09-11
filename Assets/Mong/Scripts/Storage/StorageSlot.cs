using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

public class StorageSlot : MonoBehaviour, IDropHandler
{
    //스토리지아이템 정보를 저장하고 드랍앤 드롭할곳   


    public void OnDrop(PointerEventData eventData)
    {
        // drop을 했는데 없어서 뜨나? null이 뜬다 이유가 뒤에서 부딪혀서 그런가?
        StorageItem storageItem = eventData.pointerDrag.GetComponent<StorageItem>();
        storageItem.parentAfterDrag = transform;
        

        if (storageItem == null)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem.parentAfterDrag = transform;
        }

    }


}
