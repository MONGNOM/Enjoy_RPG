using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        InventoryItem droppedItem = dropped.GetComponent<InventoryItem>();

        if (transform.childCount > 0)
        {
            Transform itemInSlot = transform.GetChild(0);
            itemInSlot.SetParent(droppedItem.parentAfterDrag);
            itemInSlot.position = droppedItem.parentAfterDrag.position;
        }

        droppedItem.parentAfterDrag = transform;
    }
}
