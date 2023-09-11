using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StorageItem : MonoBehaviour , IBeginDragHandler , IEndDragHandler , IDragHandler, IPointerClickHandler
{
    [SerializeField]
    private Image itemPrefabs;

    [HideInInspector]
    public Item item;

    [HideInInspector]
    public Vector2 defaultPos;

    [HideInInspector]
    public Transform parentAfterDrag;

    //아이템에 대한 정보를 가져올 곳
    public void addItem(Item item)
    {
        itemPrefabs.sprite = item.image;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        defaultPos = this.gameObject.transform.position;
        parentAfterDrag = this.gameObject.transform.parent;
        itemPrefabs.raycastTarget = false;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemPrefabs.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
        gameObject.transform.position = parentAfterDrag.position;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        StorageSlot slot = transform.GetComponentInParent<StorageSlot>();
        // 슬롯 포지션에 위치에 없으면 retrun
        if (!slot)
        {
            Debug.Log("삭제안됌");
            return;
        }
        else
        {
            StorageManager.Instance.RemoveItem(this);
            Destroy(gameObject);
        }
    }

}
