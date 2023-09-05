using UnityEngine;

public class TestButton : MonoBehaviour
{
    public Item[] itemsToPickup;

    public void PickpupItem(int num)
    {
        bool result = InventoryManager.Instance.AddItem(itemsToPickup[num]);
        if (result == true)
        {
            Debug.Log("Item Added");
        }
        else
        {
            Debug.Log("Item not Added");
        }
    }
}
